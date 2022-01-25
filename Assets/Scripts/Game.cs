using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StackFall
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Tube _tubePrefab;
        [SerializeField] private SizeInt _tubeSize;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private List<Shape> _shapes;
        [SerializeField, Range(0.5f, 5f)] private float rotationIndent = 3;
        [SerializeField] private SpawnConfig _spawnConfig;

        private Tube _tube;
        
        private void Awake()
        {
            _tube = (Tube) PrefabUtility.InstantiatePrefab(_tubePrefab);
            
            _tube.Initialize(_tubeSize, _shapes, _spawnConfig, _rotationSpeed, rotationIndent);
            _tube.RotateAround();
        }
    }
}
