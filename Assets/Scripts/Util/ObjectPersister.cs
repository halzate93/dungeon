using UnityEngine;
using System.Collections;

namespace Utils.Detail
{
	public class ObjectPersister : MonoBehaviour 
	{
		private void Awake ()
		{
			DontDestroyOnLoad (gameObject);
		}
	}	
}