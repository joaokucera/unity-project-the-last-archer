using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using JK.Patterns;
using Random = UnityEngine.Random;

namespace JK.Integrations
{
	public class JKFacebookUserInfo : JKSingleton<JKFacebookUserInfo> 
	{
		private Dictionary<string, string> m_profileDictionary;
		private List<object> m_friendsCollection;
		private List<JKFacebookPlayerScore> m_scoresCollection;

		public static Sprite ProfilePicture;
		public static string Identifier;
		public static string FirstName;
		public static string Name;
		public static string Gender;

		public static List<object> FriendsCollection { get { return Instance.m_friendsCollection; } }
		public static List<JKFacebookPlayerScore> ScoresCollection { get { return Instance.m_scoresCollection; } }

		public static string GetName 
		{ 
			get 
			{  
				if (String.IsNullOrEmpty(Name)) return "GUEST";
				
				return Name;
			} 
		}
		public static int PreviousScore 
		{ 
			get 
			{
				int score = 0;

				if (Instance.m_scoresCollection != null && Instance.m_scoresCollection.Count > 0)
					score = Instance.m_scoresCollection.Where(s => s.Id == Identifier).Select(s => s.Score).Single(); 

				return score;
			} 
		}

		public static void FillUserInfo(string resultText)
		{
			Instance.m_profileDictionary = JKFacebookUtil.DeserializeJSONProfile (resultText);
			Instance.m_friendsCollection = JKFacebookUtil.DeserializeJSONFriends (resultText);

			Identifier = Instance.m_profileDictionary ["id"];
			FirstName = Instance.m_profileDictionary["first_name"].ToUpper();
			Name = Instance.m_profileDictionary["name"].ToUpper();
			Gender = Instance.m_profileDictionary["gender"].ToUpper();
		}

		public static void FillPicture(Texture2D resultTexture)
		{
			ProfilePicture = Sprite.Create (resultTexture, new Rect (0, 0, resultTexture.width, resultTexture.height), Vector2.zero);
		}

		public static void FillScoresCollection(string resultText)
		{
			List<object> scoresData = JKFacebookUtil.DeserializeScores(resultText);
			
			Instance.m_scoresCollection = new List<JKFacebookPlayerScore>();
			
			foreach (var score in scoresData)
			{
				var entry = (Dictionary<string, object>)score;
				var user = (Dictionary<string, object>)entry["user"];
				
				Instance.m_scoresCollection.Add(new JKFacebookPlayerScore
				{
					Id = user["id"].ToString(),
					Name = user["name"].ToString(),
					Score = Convert.ToInt32(entry["score"])
				});
			}
		}

		public static JKFacebookPlayerScore GetFriendPlayerScore(string friendIdentifier)
		{
			return Instance.m_scoresCollection.Single(s => s.Id == friendIdentifier);
		}
	}
}