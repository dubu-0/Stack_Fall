using UnityEngine;

namespace StackFall.Printers
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
			print.transform.position = position;
			var randomScale = Random.Range(0.12f, 0.25f);
			print.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
			print.transform.position += new Vector3(0f, 0.25f, 0f);

			var randomRotation = Random.rotation.eulerAngles;
			var rotation = print.transform.rotation;
			rotation.eulerAngles = new Vector3(90f, randomRotation.y, randomRotation.z);
			print.transform.rotation = rotation;
		}
	}
}