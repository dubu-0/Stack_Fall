using System;
using StackFall.Shapes;
using StackFall.Shapes.Parts;
using UnityEngine;

namespace StackFall.PlayerSystem
{
	public class PlayerCollisionHandler : MonoBehaviour
	{
		private Player _player;

		private void OnCollisionStay(Collision collisionInfo)
		{
			if (_player.IsNotFallingDown)
			{
				if (collisionInfo.gameObject.TryGetComponent<ShapePart>(out var shapePart))
				{
					OnShapePartTouched?.Invoke(shapePart.transform,
						shapePart.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
				}
				
				_player.Jump();
			}
			
			if (collisionInfo.gameObject.GetComponentInParent<WinPlatform>()) 
				HandleCollisionWithWinPlatform();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<WinPlatform>(out _))
			{
				HandleCollisionWithWinPlatform();
				return;
			}

			if (_player.IsNotFallingDown)
				return;

			if (other.gameObject.TryGetComponent<ShapePart>(out var shapePart)) 
				HandleFallWith(shapePart);
		}

		public void Initialize()
		{
			_player = GetComponent<Player>();
		}

		public event Action OnBlackPartTouched;
		public event Action OnWinPlatformTouched;
		public event Action<Transform, Vector3> OnShapePartTouched;
		public event Action<float> OnShapePartBroken;

		private void HandleCollisionWithWinPlatform()
		{
			OnWinPlatformTouched?.Invoke();
			OnWinPlatformTouched = null;
			_player.enabled = false;
		}

		private void HandleFallWith(ShapePart shapePart)
		{
			if (_player.BurningCoroutine != default)
			{
				shapePart.GetComponentInParent<Shape>().Explode();
				OnShapePartBroken?.Invoke(1 - shapePart.transform.position.y / _player.PlayerConfig.SpawnPosition.y);
			}
			else
			{
				if (shapePart.IsBlack)
				{
					OnBlackPartTouched?.Invoke();
					_player.gameObject.SetActive(false);
					OnBlackPartTouched = null;
				}
				else
				{
					shapePart.GetComponentInParent<Shape>().Explode();
					OnShapePartBroken?.Invoke(1 - shapePart.transform.position.y /
						_player.PlayerConfig.SpawnPosition.y);
				}
			}
		}
	}
}