using StackFall.Tube.Shapes;
using StackFall.Tube.Shapes.Parts;
using UnityEngine;

namespace StackFall.Player
{
	[RequireComponent(typeof(Rigidbody))]
	[SelectionBase]
	public class PlayerSystem : MonoBehaviour
	{
		private Rigidbody _rigidbody;
		private PlayerConfig _playerConfig;
		private CustomGravity _customGravity;

		private bool _isFallingDown;

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
			Jump();
			
			if (!_isFallingDown) return;
			if (!collision.gameObject.TryGetComponent(out ShapePart shapePart)) return;
			
			switch (shapePart.IsBlack)
			{
				case true:
					Debug.LogWarning("Black part touched, player died");
					break;
				case false:
					shapePart.GetComponentInParent<Shape>().Explode();
					break;
			}

			_isFallingDown = false;
		}

		public void ApplyGravity()
		{
			_customGravity.ApplyGravity();
		}

		public void FallDown()
		{
			_rigidbody.velocity = new Vector3(0f, -_playerConfig.FallDownSpeed, 0f);
			_isFallingDown = true;
		}

		private void Jump()
		{
			_rigidbody.velocity = new Vector3(0f, _playerConfig.JumpPower, 0f);
		}
	}
}