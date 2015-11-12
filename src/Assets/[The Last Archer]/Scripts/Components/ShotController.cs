using System;
using System.Collections;
using UnityEngine;

namespace TheLastArcher
{
	public class ShotController : AttackController, IAttackController
	{
		public ShotController (IMotorController controller, Transform parent, GameObject prefab) : base (controller, parent, prefab)
		{
		}

		#region IAttackController implementation

		public void DoAttack ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}