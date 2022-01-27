using UnityEngine;

namespace StackFall
{
	public class FinishPlatform : MonoBehaviour
	{
		public void SetLocalScale(SizeInt newLocalScale)
		{
			transform.localScale = new Vector3(newLocalScale.Width, transform.localScale.y, newLocalScale.Width);
		}
	}
}