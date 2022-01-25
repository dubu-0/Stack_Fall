using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StackFall
{
    public class ShapeCollection : MonoBehaviour
    {
        private List<Shape> _shapes;
        private float _rotationIndent = 5;

        public void Initialize(List<Shape> shapes, float rotationIndent)
        {
            _shapes = shapes;
            _rotationIndent = rotationIndent;
        }
        
        public void SpawnShapes(SpawnConfig spawnConfig)
        {
            for (var i = 1; i <= spawnConfig.Amount; i++)
            {
                for (var j = 1; j <= _shapes.Count; j++)
                {
                    var shape = _shapes[j - 1];
                    var shapeInstance = (Shape) PrefabUtility.InstantiatePrefab(shape, transform);
                    shapeInstance.transform.position = spawnConfig.InitialSpawnPoint.position;
                    shapeInstance.IndentPosition(i * shape.transform.localScale.y);
                    shape.IndentRotation(j * _rotationIndent);
                }
            }
        }

        public void ResizeShapesWidthTo(float newWidth)
        {
            foreach (var shape in _shapes)
            {
                var currentScale = shape.transform.localScale;
                currentScale.x = newWidth;
                currentScale.z = newWidth;
                shape.transform.localScale = currentScale;
            }
        }
    }
}
