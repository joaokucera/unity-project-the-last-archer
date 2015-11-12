using System;
using System.Collections;
using UnityEngine;

namespace TheLastArcher
{
	public class OverwatchController : AttackController, IAttackController
	{
		public OverwatchController (IMotorController controller, Transform parent, GameObject prefab) : base (controller, parent, prefab)
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
