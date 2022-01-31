using UnityEngine;

namespace StackFall
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpritePrinter : MonoBehaviour
	{
		private SpriteRenderer _spriteRenderer;
		private Transform _printInvoker;

		public void Initialize(Transform printInvoker)
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_printInvoker = printInvoker;
		}
		
		public void Print()
		{
			var print = Instantiate(_spriteRenderer, _printInvoker, false);
			print.transform.localPosition = Vector3.zero;
			print.transform.Rotate(90f, 0f, 0f);
			print.transform.SetParent(null);
		}
	}
}