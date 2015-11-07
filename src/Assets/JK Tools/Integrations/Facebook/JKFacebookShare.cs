using System;
using UnityEngine;
using Facebook.Unity;
using JK.Patterns;

namespace JK.Integrations
{
	public class JKFacebookShare : JKSingleton<JKFacebookShare> 
	{
		private const string Score = "point";
		//private string m_contentUrl = string.Format("http://apps.facebook.com/{0}/?challenge_hrag={1}", FB.AppId, (FB.IsLoggedIn ? FB.UserId : "guest"));
		private string m_contentUrl = string.Format("http://apps.facebook.com/{0}/?challenge_hrag={1}", FB.AppId, "guest");

		private Uri m_contentUri;
		private Uri m_photoUri;

		[SerializeField] private string m_photoUrl;
		[SerializeField] private string m_contentTitle;
		[SerializeField] private string m_contentDescription;
		[SerializeField] private string m_resultTitle;
		[SerializeField] private string m_resultText;

		void Start()
		{
			m_contentUri = new Uri (Instance.m_contentUrl);
			m_photoUri = new Uri (Instance.m_photoUrl);
		}

		public static void OnShare()
		{	
			JKFacebookService.ShareAPICall (Instance.m_contentUri, Instance.m_contentTitle, Instance.m_contentDescription, Instance.m_photoUri);
		}

		public static void OnShareResult(int currentScore)
		{
			int previous = JKFacebookUserInfo.PreviousScore;
			int score = currentScore > previous ? currentScore : previous;

			string scoreText = Score;
			if (score > 1) scoreText += "s";

			string resultDescription = string.Format(Instance.m_resultText, score, scoreText);

			JKFacebookService.ShareAPICall (Instance.m_contentUri, Instance.m_resultTitle, resultDescription, Instance.m_photoUri);
		}
	}
}