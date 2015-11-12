using UnityEngine;
using UnityEngine.UI;

namespace TheLastArcher
{
	public interface IHealthController
	{
		void UpdateHeartAt(int index, Sprite sprite);

		void UpdateHealthBar(float amount);
	}
}