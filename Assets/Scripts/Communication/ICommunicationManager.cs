using System;

namespace Communication
{
	public interface ICommunicationManager
	{
        void Send<T, K>(string endPoint, T request, Action<K> onGotResponse, Action onFailed = null);

        void Send<T>(string endPoint, T request, Action onGotResponse, Action onFailed = null);

        void Fetch<K>(string endPoint, Action<K> onGotResponse, Action onFailed = null);
    }
}