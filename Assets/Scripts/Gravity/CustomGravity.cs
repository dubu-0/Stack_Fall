using System;
using UnityEngine;

namespace StackFall.Gravity
{
	[RequireComponent(typeof(Rigidbody))]
	public class CustomGravity : MonoBehaviour
	{
		private readonly Vector3 _globalGravity = Physics.gravity;
		private float _gravityScale;
		private Rigidbody _rigidbody;

		private void FixedUpdate()
		{
			ApplyGravity();
		}

		public void Initialize()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_rigidbody.useGravity = false;
		}

		public void InitGravityScale(float value)
		{
			if (_gravityScale != 0f) throw new Exception("Already inited");
			_gravityScale = value;
		}

		private void ApplyGravity()
		{
			_rigidbody.AddForce(_globalGravity * _gravityScale, ForceMode.Acceleration);
		}
	}
}