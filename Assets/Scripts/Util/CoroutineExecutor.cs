using System.Collections;
using UnityEngine;
using Zenject;

namespace Util.Detail
{
    public class CoroutineExecutor : MonoBehaviour, ICoroutineExecutor
    {
        void ICoroutineExecutor.StartCoroutine(IEnumerator coroutine)
        {
            base.StartCoroutine(coroutine);
        }
    }
}