using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public class LevelConfig
	{
		[field: SerializeField] public TubeConfig TubeConfig { get; private set; }
		[field: Space]
		[field: SerializeField] public ShapeConfig ShapeConfig { get; private set; }
		[field: Space] 
		[field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
	}
}