using UnityEditor;
using UnityEngine;

namespace StackFall.ParticleSystems
{
	public class ParticleSystemSpawner
	{
		private readonly ParticleSystem _particleSystemPrefab;

		public ParticleSystemSpawner(ParticleSystem particleSystemPrefab)
		{
			_particleSystemPrefab = particleSystemPrefab;
		}

		public void Spawn(Transform parent, Vector3 position)
		{
			var particleSystem = (ParticleSystem) PrefabUtility.InstantiatePrefab(_particleSystemPrefab, parent);
			particleSystem.transform.localPosition = position;
			particleSystem.Play();
		}
	}
}