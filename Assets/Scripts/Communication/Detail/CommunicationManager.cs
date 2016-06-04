using System;
using System.Collections;
using System.Text;
using Util;
using UnityEngine;
using UnityEngine.Experimental.Networking;
using Zenject;

namespace Communication.Detail
{
    public class CommunicationManager: ICommunicationManager
    {        
        [Inject]
        private ICoroutineExecutor coroutines;
        
        [Inject]
        private ICommunicationsSettings settings;
        
        public void Send<T, K>(string endPoint, T request, Action<K> onGotResponse, Action onFailed = null)
        {
            string body = JsonUtility.ToJson(request);
            string url = settings.ServerURL + "/" + endPoint;
            coroutines.StartCoroutine(MakeRequest(url, UnityWebRequest.kHttpVerbPOST, (response) => { ProcessResponse<K>(response, onGotResponse, onFailed); }, onFailed, body));
        }

        public void Send<T>(string endPoint, T request, Action onGotResponse, Action onFailed = null)
        {
            string body = JsonUtility.ToJson(request) ;
            string url = settings.ServerURL + "/" + endPoint;
            coroutines.StartCoroutine(MakeRequest(url, UnityWebRequest.kHttpVerbPOST, (response) => { onGotResponse(); }, onFailed, body));
        }

        public void Fetch<K>(string endPoint, Action<K> onGotResponse, Action onFailed = null)
        {
            string url = settings.ServerURL + "/" + endPoint;
            coroutines.StartCoroutine(MakeRequest(url, UnityWebRequest.kHttpVerbGET, (response) => { ProcessResponse<K>(response, onGotResponse, onFailed); }, onFailed ));
        }
        
        private IEnumerator MakeRequest(string url, string httpVerb, Action<string> onGotResponse, Action onFailed, string requestBody = null)
        {
            UnityWebRequest request = new UnityWebRequest(url);
            request.method = httpVerb;
            if(requestBody != null)
                request.uploadHandler = MakeUploadHandler(requestBody);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.Send();
            if (string.IsNullOrEmpty(request.error))
            {
                string responseString = request.downloadHandler.text;
                onGotResponse(responseString);
            }
            else
            {
                Debug.LogWarning(string.Format("Error on request to {0}: {1}", url, request.error));
                if (onFailed != null)
                    onFailed();
            }
        }
        
        private void ProcessResponse<K>(string responseString, Action<K> onGotResponse, Action onFailed)
        {
            if (onGotResponse != null)
            {
                K response;
                if (TryLoadValue(responseString, out response))
                {
                    onGotResponse(response);
                }
                else
                {
                    Debug.LogWarning("Error on parsing response: " + responseString);
                }
            }
        }
        
        private bool TryLoadValue<K>(string responseString, out K response)
        {
            try
            {
                response = JsonUtility.FromJson<K>(responseString);
                return true;
            }
            catch (ArgumentException ex)
            {
                response = default(K);
                return false;
            }
        }
        
        private UploadHandler MakeUploadHandler(string content)
        {
            byte[] data = Encoding.UTF8.GetBytes(content);
            UploadHandlerRaw uploadHandler = new UploadHandlerRaw(data);
            uploadHandler.contentType = settings.ContentType;
            return uploadHandler;
        }
    }
}