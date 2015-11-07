using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace JK.Integrations
{
	public class JKUnityAnalyticsService : ScriptableObject
	{
		public static void SendFacebookError(string error)
		{
			Analytics.CustomEvent("facebookError", new Dictionary<string, object>
			{
				{ "error", error }
			});
		}

		public static void SendFacebookConnection(string name, string gender)
		{
			Analytics.CustomEvent("facebookConnection", new Dictionary<string, object>
			{
				{ "name", name }
			});

			SendGender (gender);
		}

		static void SendGender(string genderName)
		{
			Gender gender = Gender.Unknown;
			if (genderName == "MALE") gender = Gender.Male;
			if (genderName == "FEMALE") gender = Gender.Female;

			Analytics.SetUserGender (gender);
		}

		public static void SendFacebookShare()
		{
			Analytics.CustomEvent("facebookShare", new Dictionary<string, object>
			{
			});
		}

		public static void SendFacebookInvite()
		{
			Analytics.CustomEvent("facebookInvite", new Dictionary<string, object>
			{
			});
		}

		public static void SendGameError(string error)
		{
			Analytics.CustomEvent("gameError", new Dictionary<string, object>
			{
				{ "error", error }
			});
		}

		public static void SendGameOver(int round, int bestScore, int currentScore, TimeSpan timePlaying)
		{
			Analytics.CustomEvent("gameOver", new Dictionary<string, object>
			{
				{ "round", round },
				{ "bestScore", bestScore },
				{ "currentScore", currentScore },
				{ "totalSecondsPlaying", (int)timePlaying.TotalSeconds }
			});
		}
	}
}