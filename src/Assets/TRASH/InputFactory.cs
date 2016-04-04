﻿using UnityEngine;

namespace TheLastArcher
{
	public static class InputFactory
	{
		public static IInputController GetCurrentInput()
		{
	#if UNITY_EDITOR || UNITY_WEBGL
			return new InputMouseController ();
	#elif 
			return new InputTouchController()
	#endif
		}
	}
}