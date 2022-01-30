using StackFall.Tube.Shapes.Config;
using StackFall.Tube.Shapes.Parts;
using UnityEngine;

namespace StackFall.Tube.Shapes
{
	[SelectionBase]
	public class Shape : MonoBehaviour
	{
		private ShapeConfig _shapeConfig;
		private ShapePart[] _parts;

		public void Initialize(ShapeConfig shapeConfig)
		{
			_shapeConfig = shapeConfig;
			_parts = GetComponentsInChildren<ShapePart>();
			
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
			currentPosition.y += indent * transform.localScale.y * 0.45f;
			transform.position = currentPosition;
		}

		public void Explode()
		{
			foreach (var shapePart in _parts)
			{
				shapePart.FlyOff();
			}

			transform.SetParent(null);
		}
	}
}