using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackFall
{
	[SelectionBase]
	public class Tube : MonoBehaviour
	{
		private ShapeCollection _shapeCollection;
		private TubeView _view;
		private SizeInt _size;
		private SpawnConfig _spawnConfig;
		private float _rotationSpeed;

		public void Initialize(SizeInt size, List<Shape> shapes, SpawnConfig spawnConfig,
			float rotationSpeed, float rotationIndent)
		{
			_size = size;
			_spawnConfig = spawnConfig;
			_rotationSpeed = rotationSpeed;
			_shapeCollection = GetComponentInChildren<ShapeCollection>();
			_view = GetComponentInChildren<TubeView>();
			
			_view.SetLocalScale(_size);

			_shapeCollection.Initialize(shapes, rotationIndent);
			_shapeCollection.SpawnShapes(_spawnConfig);
			_shapeCollection.ResizeShapesWidthTo(_size.Width);
		}

		private void OnValidate()
		{
			if (_view && _shapeCollection)
			{
				_view.SetLocalScale(_size);
				_shapeCollection.ResizeShapesWidthTo(_size.Width);
			}
		}
		
		public void RotateAround()
		{
			StartCoroutine(EndlessRotating());
		}

		private IEnumerator EndlessRotating()
		{
			while (true)
			{
				transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
				yield return null;
			}
		}
	}
}