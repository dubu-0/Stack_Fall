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
				OnShapePartTouched?.Invoke(collisionInfo.transform,
					collisionInfo.collider.ClosestPointOnBounds(transform.position));
				_player.Jump();
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (IsNotCollidedWith(other, out var shapePart))
			{
				HandleCollisionWithWinPlatform();
				return;
			}

			if (_player.IsNotFallingDown)
				return;

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

		private bool IsNotCollidedWith(Collider other, out ShapePart shapePart)
		{
			return !other.gameObject.TryGetComponent(out shapePart);
		}

		private void HandleCollisionWithWinPlatform()
		{
			OnWinPlatformTouched?.Invoke();
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