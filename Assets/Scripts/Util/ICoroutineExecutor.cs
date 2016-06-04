using System.Collections;

namespace Util
{
	public interface ICoroutineExecutor
	{
		void StartCoroutine(IEnumerator coroutine);
	}
}