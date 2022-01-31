using System;
using StackFall.TubeSystem.Shapes;
using StackFall.TubeSystem.Shapes.Parts;
using UnityEngine;

namespace StackFall.PlayerSystem
{
	[RequireComponent(typeof(Rigidbody))]
	[SelectionBase]
	public class Player : MonoBehaviour
	{
		private Rigidbody _rigidbody;
		private PlayerConfig _playerConfig;
		private CustomGravity _customGravity;

		private bool _isNotFallingDown = true;

		public event Action OnPlayerDied;
		public event Action OnPlayerWon;

		public void Initialize(PlayerConfig playerConfig)
		{
			_rigidbody = GetComponent<Rigidbody>();
			_customGravity = GetComponent<CustomGravity>();
			_playerConfig = playerConfig;
			
			_customGravity.Initialize();
			_customGravity.InitGravityScale(playerConfig.GravityScale);
		}
		
		private void OnCollisionEnter(Collision collision)
		{
			if (_isNotFallingDown) 
				return;
			
			if (IsNotCollidedWith(collision, out ShapePart shapePart)) 
				return;

			HandleCollisionWith(shapePart);

			if (IsNotCollidedWith(collision, out WinPlatform winPlatform)) 
				return;
			
			HandleCollisionWith(winPlatform);
		}

		private void OnCollisionStay()
		{
			Jump();
		}

		public void ApplyGravity()
		{
			_customGravity.ApplyGravity();
		}

		public void FallDown()
		{
			_rigidbody.velocity = new Vector3(0f, -_playerConfig.FallDownSpeed, 0f);
			_isNotFallingDown = false;
		}

		private void Jump()
		{
			_rigidbody.velocity = new Vector3(0f, _playerConfig.JumpPower, 0f);
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
			OnPlayerWon?.Invoke();
		}

		private void HandleCollisionWith(ShapePart shapePart)
		{
			if (shapePart.IsBlack)
				OnPlayerDied?.Invoke();
			else
				shapePart.GetComponentInParent<Shape>().Explode();
			
			_isNotFallingDown = true;
		}
	}
}