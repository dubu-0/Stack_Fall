using System;
using UnityEngine;

namespace StackFall
{
	[RequireComponent(typeof(Rigidbody))]
	[SelectionBase]
	public class Player : MonoBehaviour
	{
		private Rigidbody _rigidbody;
		private PlayerConfig _playerConfig;

		public void Initialize(PlayerConfig playerConfig)
		{
			_rigidbody = GetComponent<Rigidbody>();
			_playerConfig = playerConfig;
		}

		public void Jump()
		{
			if (!CanJump()) throw new Exception("Cannot jump, velocity.y > 0");
			_rigidbody.velocity = new Vector3(0f, _playerConfig.JumpPower, 0f);
		}

		public bool CanJump()
		{
			return Mathf.Approximately(_rigidbody.velocity.y, 0f);
		}

		public void FallDown()
		{
			_rigidbody.velocity = new Vector3(0f, -_playerConfig.FallDownPower, 0f);
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (!IsFallingDown(collision.impulse.y)) return;

			if (collision.gameObject.CompareTag(ShapePartTags.Black))
			{
				Debug.LogWarning("Black part touched, player died");
			}

			if (collision.gameObject.CompareTag(ShapePartTags.NonBlack))
			{
				collision.gameObject.GetComponentInParent<Shape>().Explode();
			}
		}

		private bool IsFallingDown(float yImpulse)
		{
			return yImpulse >= _playerConfig.FallDownPower / 2;
		}
	}
}