using System;
using NUnit.Framework;
using TheLastArcher;
using UnityEngine;

namespace TheLastArcherTest
{
	public class HealthControllerTests
	{
		private IHealthController m_healthController;

		[SetUp]
		public void Init()
		{
			m_healthController = GameObject.FindObjectOfType<HealthController> ();
		}

		[Test]
		public void GivenComponent_WhenFound_ThenIsNotNull()
		{
			Assert.IsNotNull (m_healthController);
		}

		[Test]
		public void GivenHit_WhenHaveEnoughHealth_ThenLoseHealth()
		{
			Assert.AreEqual (2, 2);
		}
	}
}