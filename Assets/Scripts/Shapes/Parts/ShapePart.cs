using StackFall.Shapes.Parts.Config;
using UnityEngine;

namespace StackFall.Shapes.Parts
{
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]
	public class ShapePart : MonoBehaviour
	{
		[SerializeField] private bool _isBlack;
		private Collider _collider;
		private Rigidbody _rigidbody;

		private ShapePartConfig _shapePartConfig;

		public bool IsBlack => _isBlack;

		public void Initialize(ShapePartConfig shapePartConfig)
		{
			_shapePartConfig = shapePartConfig;
			_collider = GetComponent<Collider>();
			_rigidbody = GetComponent<Rigidbody>();

			if (_isBlack) return;
			GetComponent<MeshRenderer>().material.color = _shapePartConfig.GetRandomColor();
		}

		public void FlyOff()
		{
			var parentPosition = transform.parent.localPosition;
			var force = ChooseFlyDirection() * _shapePartConfig.FlyOffForce.GetRandom;
			_rigidbody.isKinematic = false;
			_rigidbody.velocity.Set(0f, 0f, 0f);
			_rigidbody.AddForceAtPosition(force, parentPosition, _shapePartConfig.ExplosionForceMode);
			_rigidbody.AddTorque(_shapePartConfig.FlyOffTorque.GetRandom * Vector3.left);
			_collider.enabled = false;
		}

		private Vector3 ChooseFlyDirection()
		{
			var direction = (Vector3.up * _shapePartConfig.UpwardsModifier.GetRandom +
			                 GetNormalizedHorizontalPositionRelativeToParent()).normalized;
			return direction;
		}

		private Vector3 GetNormalizedHorizontalPositionRelativeToParent()
		{
			var parentPosition = transform.parent.position;
			var myPosition = _collider.bounds.center;
			return parentPosition.x - myPosition.x > 0 ? Vector3.left : Vector3.right;
		}
	}
}