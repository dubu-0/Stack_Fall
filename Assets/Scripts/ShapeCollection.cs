using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StackFall
{
    public class ShapeCollection : MonoBehaviour
    {
        private readonly List<Shape> _shapes = new List<Shape>();

        public void SpawnShapes(ShapeConfig shapeConfig)
        {
            for (var i = 1; i <= shapeConfig.Amount; i++)
            {
                var shapeInstance = (Shape) PrefabUtility.InstantiatePrefab(shapeConfig.Prefab, transform);
                shapeInstance.transform.localPosition = Vector3.zero;
                shapeInstance.Initialize(shapeConfig);
                shapeInstance.IndentPosition(i);
                shapeInstance.IndentRotation(i);
                _shapes.Add(shapeInstance);
            }
        }

        public void ReInitializeShapes(ShapeConfig shapeConfig)
        {
            foreach (var shape in _shapes)
            {
                shape.Initialize(shapeConfig);
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

        public void ResizeShapesHeightTo(float newHeight)
        {
            foreach (var shape in _shapes)
            {
                var currentScale = shape.transform.localScale;
                currentScale.y = newHeight;
                shape.transform.localScale = currentScale;   
            }
        }

        public void DeactivateShapes()
        {
            foreach (var shape in _shapes)
            {
                shape.gameObject.SetActive(false);
            }
        }
    }
}
