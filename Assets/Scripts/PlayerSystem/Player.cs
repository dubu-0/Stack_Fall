using System;
using System.Collections;
using StackFall.Gravity;
using UnityEngine;

namespace StackFall.PlayerSystem
{
	[RequireComponent(typeof(Rigidbody))]
	[SelectionBase]
	public class Player : MonoBehaviour
	{
		private static readonly int Speed = Animator.StringToHash("Speed");
		private Animator _animator;
		private CustomGravity _customGravity;
		private float _fallingTime;
		private ParticleSystem _onFire;
		private Rigidbody _rigidbody;

		public PlayerConfig PlayerConfig { get; private set; }
		public Collider Collider { get; private set; }
		public bool IsNotFallingDown => Collider.isTrigger == false;
		public Coroutine BurningCoroutine { get; private set; }
		
		public event Action<float> OnFallingTimeChanged;
		public event Action OnBurned;

		public void Initialize(PlayerConfig playerConfig)
		{
			PlayerConfig = playerConfig;
			_rigidbody = GetComponent<Rigidbody>();
			_customGravity = GetComponent<CustomGravity>();
			_animator = GetComponent<Animator>();
			_onFire = GetComponentInChildren<ParticleSystem>(true);
			Collider = GetComponentInChildren<Collider>();

			_customGravity.Initialize();
			_customGravity.InitGravityScale(playerConfig.GravityScale);
		}

		private void Update()
		{
			if (Input.GetMouseButton(0))
			{
				FallDown();

				if (BurningCoroutine == default)
				{
					_fallingTime += Time.deltaTime;
					OnFallingTimeChanged?.Invoke(_fallingTime / PlayerConfig.BurnDelay);
				}
			}
			else
			{
				Collider.isTrigger = false;

				if (BurningCoroutine == default)
				{
					_fallingTime = Mathf.Clamp(_fallingTime - Time.deltaTime * PlayerConfig.BurnReduction, 0,
						_fallingTime);
					OnFallingTimeChanged?.Invoke(_fallingTime / PlayerConfig.BurnDelay);
				}
			}

			if (_fallingTime > PlayerConfig.BurnDelay && BurningCoroutine == default)
				BurningCoroutine = StartCoroutine(Burning());

			if (BurningCoroutine != default)
			{
				_fallingTime =
					Mathf.Clamp(_fallingTime - Time.deltaTime * PlayerConfig.BurnDelay / PlayerConfig.BurnDuration, 0,
						_fallingTime);
				OnFallingTimeChanged?.Invoke(_fallingTime / PlayerConfig.BurnDelay);
			}

			AnimateScale();
		}

		public void Jump()
		{
			_rigidbody.velocity = new Vector3(0f, PlayerConfig.JumpPower, 0f);
		}

		private void AnimateScale()
		{
			_animator.SetFloat(Speed, _rigidbody.velocity.magnitude);
		}

		private void FallDown()
		{
			_rigidbody.velocity = new Vector3(0f, -PlayerConfig.FallDownSpeed, 0f);
			Collider.isTrigger = true;
		}

		private IEnumerator Burning()
		{
			_onFire.gameObject.SetActive(true);
			OnBurned?.Invoke();
			yield return new WaitForSeconds(PlayerConfig.BurnDuration);
			_onFire.gameObject.SetActive(false);
			BurningCoroutine = default;
		}
	}
}