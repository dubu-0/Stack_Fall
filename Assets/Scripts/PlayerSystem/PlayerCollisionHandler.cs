using System;
using StackFall.Shapes;
using StackFall.Shapes.Parts;
using UnityEngine;

namespace StackFall.PlayerSystem
{
	public class PlayerCollisionHandler : MonoBehaviour
	{
		private Player _player;

		public void Initialize()
		{
			_player = GetComponent<Player>();
		}
		
		public event Action OnBlackPartTouched;
		public event Action OnWinPlatformTouched;
		public event Action<Transform, Vector3> OnShapePartTouched;
		
		private void OnCollisionEnter(Collision collision)
		{
			if (IsNotCollidedWith(collision, out ShapePart shapePart))
			{
				HandleCollisionWithWinPlatform();
				return;
			}

			OnShapePartTouched?.Invoke(shapePart.transform, collision.GetContact(0).point);
			
			if (_player.IsNotFallingDown) 
				return;

			HandleFallWith(shapePart);
		}
		
		private void OnCollisionStay()
		{
			_player.Jump();
		}

		private bool IsNotCollidedWith(Collision collision, out ShapePart shapePart)
		{
			return !collision.gameObject.TryGetComponent(out shapePart);
		}

		private void HandleCollisionWithWinPlatform()
		{
			OnWinPlatformTouched?.Invoke();
		}

		private void HandleFallWith(ShapePart shapePart)
		{
			if (shapePart.IsBlack)
				OnBlackPartTouched?.Invoke();
			else
				shapePart.GetComponentInParent<Shape>().Explode();

			_player.IsNotFallingDown = true;
		}
	}
}