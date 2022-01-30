using System;
using StackFall.Player;
using StackFall.Tube;
using StackFall.Tube.Shapes.Config;
using UnityEngine;

namespace StackFall
{
	[CreateAssetMenu(menuName = "Configs/Create LevelConfig", fileName = "LevelConfig", order = 0)]
	[Serializable]
	public class LevelConfig : ScriptableObject
	{
		[field: SerializeField] public TubeConfig TubeConfig { get; private set; }
		[field: Space]
		[field: SerializeField] public ShapeConfig ShapeConfig { get; private set; }
		[field: SerializeField] public ShapePrefabsProvider ShapePrefabsProvider { get; private set; }
		[field: Space] 
		[field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
	}
}