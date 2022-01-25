using UnityEngine;

namespace StackFall
{
	[SelectionBase]
	public class Shape : MonoBehaviour
	{
		public void IndentRotation(float value)
		{
			transform.Rotate(Vector3.up, value);
		}

		public void IndentPosition(float value)
		{
			var currentPosition = transform.position;
			currentPosition.y += value;
			transform.position = currentPosition;
		}
	}
}