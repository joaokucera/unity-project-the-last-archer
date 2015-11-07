using UnityEngine;
using Facebook.Unity;
using JK.Patterns;

namespace JK.Integrations
{
	public class JKFacebookInvite : JKSingleton<JKFacebookInvite> 
	{
		private const string Score = "point";

		[SerializeField] private string m_inviteTitle;
		[SerializeField] private string m_inviteMessage;
		[SerializeField] private string m_inviteChallenge;
		[SerializeField] private string m_inviteFriendMessage;
		[SerializeField] private string m_invitePoints;
		[SerializeField] private string m_inviteResult;

		public static void OnInvite()
		{
			JKFacebookService.InviteAPICall (Instance.m_inviteTitle, Instance.m_inviteMessage);
		}

		public static void OnInviteFriend(string friendIdentifier)
		{
			int previous = JKFacebookUserInfo.PreviousScore;
			string title, friendMessage;
			string data = "{\"challenge_score\": " + previous + " }";

			JKFacebookPlayerScore friend = JKFacebookUserInfo.GetFriendPlayerScore(friendIdentifier);

			if (previous > friend.Score)
			{
				title = string.Format(Instance.m_inviteChallenge, friend.Name);

				string previousText = Score;
				if (previous > 1) previousText += "s";

				int diff = previous - friend.Score;
				string diffText = Score;
				if (diff > 1) diffText += "s";

				friendMessage = string.Format(Instance.m_invitePoints, previous, previousText, diff, diffText);
			}
			else
			{
				title = string.Format(Instance.m_inviteFriendMessage, friend.Name);

				string previousText = Score;
				if (previous > 1) previousText += "s";

				friendMessage = string.Format(Instance.m_inviteResult, previous, previousText);
			}

			JKFacebookService.InviteFriendAPICall (friendIdentifier, title, friendMessage, data);
		}
	}
}