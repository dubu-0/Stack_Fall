using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StackFall.Shapes.Config;
using UnityEditor;
using UnityEngine;

namespace StackFall.Shapes
{
    public class ShapeSpawner : MonoBehaviour
    {
        private const int NumShapesBeforeRotation = 10;
        private readonly List<Shape> _shapeInstances = new List<Shape>();
        private List<Shape> _shapePrefabs;
        private List<ShapeType> _shapeTypes;
        private ShapeConfig _shapeConfig;

        public void Initialize(ShapeConfig shapeConfig, List<ShapeType> shapeTypes)
        {
            _shapeConfig = shapeConfig;
            _shapePrefabs = _shapeConfig.GetRandomShapePrefabs;
            _shapeTypes = shapeTypes;
        }

        public void SpawnShapes()
        {
            var randomRotationIndent = _shapeConfig.RotationIndent.GetRandom;

            for (var i = 1; i <= _shapeConfig.Amount; i++)
            {
                var randomShapeIndex = Random.Range((int) _shapeTypes.Min(), (int) _shapeTypes.Max() + 1);
                var shapeInstance = (Shape) PrefabUtility.InstantiatePrefab(_shapePrefabs[randomShapeIndex], transform);
                shapeInstance.transform.localPosition = Vector3.zero;
                shapeInstance.Initialize(_shapeConfig);
                shapeInstance.IndentPosition(i);

                if (i % NumShapesBeforeRotation == 0)
                    shapeInstance.IndentRotation(i, randomRotationIndent + 90 * Random.Range(-10, 10));
                else
                    shapeInstance.IndentRotation(i, randomRotationIndent);
                
                _shapeInstances.Add(shapeInstance);
            }
        }

        public void ResizeShapesWidthTo(float newWidth)
        {
            foreach (var shape in _shapeInstances)
            {
                var currentScale = shape.transform.localScale;
                currentScale.x = newWidth;
                currentScale.z = newWidth;
                shape.transform.localScale = currentScale;   
            }
        }

        public void ResizeShapesHeightTo(float newHeight)
        {
            foreach (var shape in _shapeInstances)
            {
                var currentScale = shape.transform.localScale;
                currentScale.y = newHeight;
                shape.transform.localScale = currentScale;   
            }
        }
        
        public void StartEndlessRotating(float rotationSpeed)
        {
            StartCoroutine(EndlessRotating(rotationSpeed));
        }

        private IEnumerator EndlessRotating(float rotationSpeed)
        {
            while (true)
            {
                // previous: _levelDifficulty.GetRotationSpeedForCurrentDifficulty(_tubeConfig.RotationSpeed)
                var rotation = new Vector3(0, rotationSpeed * Time.deltaTime, 0);
                transform.Rotate(rotation);
                yield return null;
            }
        }
    }
}
