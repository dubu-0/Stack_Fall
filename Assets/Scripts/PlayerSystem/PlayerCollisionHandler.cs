using System;
using StackFall.TubeSystem.Shapes;
using StackFall.TubeSystem.Shapes.Parts;
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
				return;
			
			OnShapePartTouched?.Invoke(collision.transform, collision.GetContact(collision.contactCount - 1).point);
			
			if (_player.IsNotFallingDown) 
				return;

			HandleFallWith(shapePart);

			if (IsNotCollidedWith(collision, out WinPlatform winPlatform)) 
				return;
			
			HandleCollisionWith(winPlatform);
		}
		
		private void OnCollisionStay()
		{
			_player.Jump();
		}
		
		private bool IsNotCollidedWith(Collision collision, out ShapePart shapePart)
		{
			if (!collision.gameObject.TryGetComponent(out shapePart)) return true;
			return false;
		}

		private bool IsNotCollidedWith(Collision collision, out WinPlatform winPlatform)
		{
			if (!collision.gameObject.TryGetComponent(out winPlatform)) return true;
			return false;
		}

		private void HandleCollisionWith(WinPlatform winPlatform)
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