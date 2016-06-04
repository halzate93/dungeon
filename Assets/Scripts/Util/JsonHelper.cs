using System.Collections.Generic;
using System;
using UnityEngine;

namespace Util
{
    public class JsonHelper
    {
        public static List<T> FromJson<T>(string json)
        {
            string newJson = "{ \"list\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
            return wrapper.list;
        }
    
        [Serializable]
        private class Wrapper<T>
        {
            #pragma warning disable 649
            public List<T> list;
            #pragma warning restore 649
        }
    }
}