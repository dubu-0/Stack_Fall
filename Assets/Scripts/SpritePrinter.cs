using UnityEngine;

namespace StackFall
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpritePrinter : MonoBehaviour
	{
		private SpriteRenderer _spriteRenderer;

		public void Initialize()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}
		
		public void Print(Transform container, Vector3 position)
		{
			var print = Instantiate(_spriteRenderer, container, false);
			Debug.Log(print.color);
			print.transform.position = position;
			print.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
			print.transform.position += new Vector3(0f, 0.25f, 0f);

			var randomRotation = Random.rotation.eulerAngles;
			var rotation = print.transform.rotation;
			rotation.eulerAngles = new Vector3(90f, randomRotation.y, randomRotation.z);
			print.transform.rotation = rotation;
		}
	}
}