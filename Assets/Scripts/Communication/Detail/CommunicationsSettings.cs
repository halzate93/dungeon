using UnityEngine;
using UnityEditor;
using Util;

namespace Communication.Detail
{
    public class CommunicationsSettings: ScriptableObject, ICommunicationsSettings
    {
        [SerializeField]
        private string serverUrl;
        
        [SerializeField]
        private string contentType;

        public string ServerURL
        {
            get
            {
                return serverUrl;
            }
        }

        public string ContentType
        {
            get
            {
                return contentType;
            }
        }
        
        [MenuItem("Assets/Create/Settings/Communication")]
        public static void CreateAsset ()
        {
            ScriptableObjectUtility.CreateAsset<CommunicationsSettings> ();
        }
    }
}