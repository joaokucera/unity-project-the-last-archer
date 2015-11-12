﻿using System;
using System.Collections;
using UnityEngine;

namespace TheLastArcher
{
	public class SpecialController : AttackController, IAttackController
	{
		public SpecialController (IMotorController controller, Transform parent, GameObject prefab) : base (controller, parent, prefab)
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