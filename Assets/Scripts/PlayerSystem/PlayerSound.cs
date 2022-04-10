using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StackFall.PlayerSystem
{
	[Serializable]
	public class PlayerSound
	{
		[SerializeField] private AudioClip _winSound;
		[SerializeField] private AudioClip _brokeSound;
		[SerializeField] private AudioClip _jumpSound;
		[SerializeField] private AudioClip _onFireSound;

		private AudioSource _audioSource;
		private float _pitch;

		public void Initialize(AudioSource audioSource)
		{
			_audioSource = audioSource;
		}

		public void PlayWinSound()
		{
			_audioSource.pitch = 1f;
			_audioSource.clip = _winSound;
			_audioSource.PlayOneShot(_audioSource.clip);
		}

		public void PlayBrokenSound(float y)
		{
			if (_audioSource.clip == _brokeSound && _pitch < 1.05f)
				_pitch += Time.deltaTime * 0.15f;
			else if (_audioSource.clip != _brokeSound) _pitch = 0.7f;

			_audioSource.clip = _brokeSound;
			_audioSource.pitch = _pitch;
			_audioSource.PlayOneShot(_audioSource.clip);
		}

		public void PlayJumpSound(Transform parent, Vector3 position)
		{
			_audioSource.pitch = Random.Range(0.9f, 1.1f);
			_audioSource.clip = _jumpSound;
			_audioSource.PlayOneShot(_audioSource.clip);
		}

		public void PlayFireSound()
		{
			_audioSource.pitch = 1f;
			_audioSource.clip = _onFireSound;
			_audioSource.PlayOneShot(_audioSource.clip);
		}
	}
}