using UnityEngine;

namespace StackFall
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
				shapePart.Initialize(shapeConfig.ShapePartConfig);
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
			foreach (var shapePart in _parts)
			{
				shapePart.FlyOff();
			}

			transform.SetParent(null);
		}
	}
}