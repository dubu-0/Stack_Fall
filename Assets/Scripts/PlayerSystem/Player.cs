using StackFall.Gravity;
using UnityEngine;

namespace StackFall.PlayerSystem
{
	[RequireComponent(typeof(Rigidbody))]
	[SelectionBase]
	public class Player : MonoBehaviour
	{
		private Rigidbody _rigidbody;
		private PlayerConfig _playerConfig;
		private CustomGravity _customGravity;

		public bool IsNotFallingDown { get; set; } = true;

		public void Initialize(PlayerConfig playerConfig)
		{
			_rigidbody = GetComponent<Rigidbody>();
			_customGravity = GetComponent<CustomGravity>();
			_playerConfig = playerConfig;
			
			_customGravity.Initialize();
			_customGravity.InitGravityScale(playerConfig.GravityScale);
		}

		private void Update()
		{
			if (Input.GetMouseButton(0)) 
				FallDown();

			if (Input.GetMouseButtonUp(0)) 
				IsNotFallingDown = true;
		}

		public void Jump()
		{
			_rigidbody.velocity = new Vector3(0f, _playerConfig.JumpPower, 0f);
		}

		private void FallDown()
		{
			_rigidbody.velocity = new Vector3(0f, -_playerConfig.FallDownSpeed, 0f);
			IsNotFallingDown = false;
		}
	}
}