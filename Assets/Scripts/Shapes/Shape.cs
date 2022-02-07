using StackFall.Shapes.Config;
using StackFall.Shapes.Parts;
using UnityEngine;

namespace StackFall.Shapes
{
	[SelectionBase]
	public class Shape : MonoBehaviour
	{
		private MeshRenderer _meshRenderer;
		private ShapePart[] _parts;
		private ShapeConfig _shapeConfig;

		public void Initialize(ShapeConfig shapeConfig)
		{
			_shapeConfig = shapeConfig;
			_parts = GetComponentsInChildren<ShapePart>();
			_meshRenderer = GetComponentInChildren<MeshRenderer>();
			_shapeConfig.Height = _meshRenderer.bounds.size.y;

			foreach (var shapePart in _parts)
				shapePart.Initialize(_shapeConfig.ShapePartConfig);
		}

		public void IndentRotation(float indent, float angle)
		{
			transform.Rotate(Vector3.up, indent * angle);
		}

		public void IndentPosition(float indent)
		{
			var currentPosition = transform.position;
			currentPosition.y += indent * _meshRenderer.bounds.size.y;
			transform.position = currentPosition;
		}

		public void Explode()
		{
			foreach (var shapePart in _parts) shapePart.FlyOff();

			transform.SetParent(null);
			Destroy(gameObject, 1f);
		}
	}
}