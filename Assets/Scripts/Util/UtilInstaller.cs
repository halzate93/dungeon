using UnityEngine;
using Util.Detail;
using Zenject;

namespace Util
{
    public class UtilInstaller : MonoInstaller
    {
		[SerializeField]
		private CoroutineExecutor coroutineExecutor;
		
        public override void InstallBindings()
        {
			Container.Bind<ICoroutineExecutor>().ToInstance(coroutineExecutor);
        }
    }
}