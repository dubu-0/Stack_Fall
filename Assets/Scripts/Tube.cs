using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace StackFall
{
	[SelectionBase]
	public class Tube : MonoBehaviour
	{
		private ShapeCollection _shapeCollection;
		private TubeView _view;
		private FinishPlatform _finishPlatform;
		private TubeConfig _tubeConfig;

		public void Initialize(TubeConfig tubeConfig)
		{
			_tubeConfig = tubeConfig;
			
			_shapeCollection = GetComponentInChildren<ShapeCollection>();
			_view = GetComponentInChildren<TubeView>();
			_finishPlatform = GetComponentInChildren<FinishPlatform>();
			
			_view.SetLocalScale(_tubeConfig.Size);
			_view.MoveUpTo(_tubeConfig.Size.Height);
			
			_finishPlatform.SetLocalScale(_tubeConfig.Size);
		}

		public void ReInitializeShapes(ShapeConfig shapeSpawnConfig)
		{
			_shapeCollection.ReInitializeShapes(shapeSpawnConfig);
		}

		public void SpawnShapes(ShapeConfig shapeSpawnConfig)
		{
			_shapeCollection.SpawnShapes(shapeSpawnConfig);
		}

		public void ResizeShapes(ShapeConfig shapeSpawnConfig)
		{
			_shapeCollection.ResizeShapesWidthTo(_tubeConfig.Size.Width);
			_shapeCollection.ResizeShapesHeightTo(shapeSpawnConfig.Height);
		}

		public void RotateAround()
		{
			StartCoroutine(EndlessRotating());
		}

		private IEnumerator EndlessRotating()
		{
			while (true)
			{
				var rotation = new Vector3(0, _tubeConfig.RotationSpeed * Time.time, 0);
				transform.DORotate(rotation, -1);
				yield return null;
			}
		}
	}
}