using UnityEngine;
using UnityEngine.UI;

namespace StackFall.PlayerSystem
{
	public class PlayerBurnIndicator : MonoBehaviour
	{
		[SerializeField] private Image _ring;

		public void ChangeValue(float value)
		{
			_ring.fillAmount = value;
			gameObject.SetActive(value > 0.01f);
		}
	}
}