using DG.Tweening;
using TMPro;
using UnityEngine;

namespace StackFall
{
	
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TextAnimation : MonoBehaviour
	{
		[SerializeField] private float _scale;
		[SerializeField, Range(0.1f, 5f)] private float _duration;

		private Tween _tween;
		
		private void Awake()
		{
			transform.DORewind();
			_tween = transform.DOScale(_scale, _duration).SetLoops(-1, LoopType.Yoyo);
		}

		private void OnDisable()
		{
			_tween.Kill();
		}
	}
}
