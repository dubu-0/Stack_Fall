using System.Collections.Generic;
using System.Linq;
using StackFall.Tube.Shapes.Config;
using UnityEditor;
using UnityEngine;

namespace StackFall.Tube.Shapes
{
    public class ShapeSpawner : MonoBehaviour
    {
        private List<Shape> _shapePrefabs;
        private const int NumShapesBeforeRotation = 10;

        public void Initialize(List<Shape> shapePrefabs)
        {
            _shapePrefabs = shapePrefabs;
        }

        public void SpawnShapes(ShapeConfig shapeConfig, Transform parent, LevelDifficulty levelDifficulty)
        {
            var randomRotationIndent = shapeConfig.RotationIndent.GetRandom;
            var shapeTypes = levelDifficulty.GetShapeTypesForCurrentDifficulty();

            for (var i = 1; i <= shapeConfig.Amount; i++)
            {
                var randomShapeIndex = Random.Range((int) shapeTypes.Min(), (int) shapeTypes.Max() + 1);
                var shapeInstance = (Shape) PrefabUtility.InstantiatePrefab(_shapePrefabs[randomShapeIndex], parent);
                shapeInstance.transform.localPosition = Vector3.zero;
                shapeInstance.Initialize(shapeConfig);
                shapeInstance.IndentPosition(i);

                if (i % NumShapesBeforeRotation == 0)
                    shapeInstance.IndentRotation(i, randomRotationIndent + 90 * Random.Range(-10, 10));
                else
                    shapeInstance.IndentRotation(i, randomRotationIndent);
            }
        }
        
        public void ResizeShapesWidthTo(float newWidth)
        {
            foreach (var shape in _shapePrefabs)
            {
                var currentScale = shape.transform.localScale;
                currentScale.x = newWidth;
                currentScale.z = newWidth;
                shape.transform.localScale = currentScale;   
            }
        }

        public void ResizeShapesHeightTo(float newHeight)
        {
            foreach (var shape in _shapePrefabs)
            {
                var currentScale = shape.transform.localScale;
                currentScale.y = newHeight;
                shape.transform.localScale = currentScale;   
            }
        }
    }
}
