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
			var particleSystem = Object.Instantiate(_particleSystemPrefab, parent, false);
			particleSystem.transform.position = position;
			particleSystem.Play();
		}
	}
}