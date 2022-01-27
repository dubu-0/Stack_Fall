using UnityEngine;

namespace StackFall
{
	[SelectionBase]
	public class Shape : MonoBehaviour
	{
		private ShapeConfig _shapeConfig;
		private Collider[] _childColliders;

		public void Initialize(ShapeConfig shapeConfig)
		{
			_shapeConfig = shapeConfig;
			_childColliders = GetComponentsInChildren<Collider>();
		}
		
		public void IndentRotation(float indent)
		{
			transform.Rotate(Vector3.up, indent * _shapeConfig.RotationIndent);
		}

		public void IndentPosition(float indent)
		{
			var currentPosition = transform.position;
			currentPosition.y += indent * _shapeConfig.Prefab.transform.localScale.y;
			transform.position = currentPosition;
		}
		
		public void Explode()
		{
			foreach (Transform child in transform)
			{
				var childRigidbody = child.gameObject.AddComponent<Rigidbody>();
				childRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				childRigidbody.velocity.Set(0f, 0f, 0f);

				childRigidbody.AddRelativeForce(ChooseFlyDirection(child.gameObject) * _shapeConfig.ExplosionForce, _shapeConfig.ExplosionForceMode);
				
				// childRigidbody.AddExplosionForce(
				// 	_shapeConfig.ExplosionForce,
				// 	ChooseFlyDirection(child.gameObject),
				// 	_shapeConfig.ExplosionRadius,
				// 	_shapeConfig.UpwardsModifier,
				// 	_shapeConfig.ExplosionForceMode);
			}

			foreach (var childCollider in _childColliders) 
				childCollider.enabled = false;
			
			transform.SetParent(null);
		}

		private Vector3 ChooseFlyDirection(GameObject shapePart)
		{
			return shapePart.transform.position.x - transform.position.x < 0 ? Vector3.left : Vector3.right;
		}
	}
}