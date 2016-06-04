using Communication.Detail;
using UnityEngine;
using Zenject;

namespace Communication
{
    public class CommunicationInstaller : MonoInstaller
    {
		[SerializeField]
		private CommunicationsSettings settings;
		
        public override void InstallBindings()
        {
            Container.Bind<ICommunicationsSettings>().ToInstance(settings);
			Container.Bind<ICommunicationManager>().ToSingle<CommunicationManager>();
        }
    }
}