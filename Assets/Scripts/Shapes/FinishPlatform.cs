using StackFall.Ranges.Int;
using UnityEngine;

namespace StackFall.Shapes
{
	public class FinishPlatform : MonoBehaviour
	{
		public void SetLocalScale(SizeInt newLocalScale)
		{
			transform.localScale = new Vector3(newLocalScale.Width, transform.localScale.y, newLocalScale.Width);
		}
	}
}