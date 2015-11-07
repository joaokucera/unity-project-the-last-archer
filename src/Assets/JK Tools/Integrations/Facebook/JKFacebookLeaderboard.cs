using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using JK.Patterns;

namespace JK.Integrations
{
	public class JKFacebookLeaderboard : JKSingleton<JKFacebookLeaderboard> 
	{
		private const string Score = "point";

		[SerializeField] private GameObject friendScorePrefab;

		public static void SetLeaderboard (List<JKFacebookPlayerScore> playerScores)
		{
			Instance.StartCoroutine(Instance.CleanLeaderboard (playerScores));
		}

		IEnumerator CleanLeaderboard(List<JKFacebookPlayerScore> playerScores)
		{
			foreach (Transform entry in transform)
			{
				Destroy(entry.gameObject);
			}

			while (transform.childCount > 0) 
			{
				yield return null;
			}

			FillLeaderboard (playerScores);
		}

		void FillLeaderboard(List<JKFacebookPlayerScore> playerScores)
		{
			int position = 0;

			foreach (var score in playerScores)
			{
				var friendScore = GameObject.Instantiate(friendScorePrefab) as GameObject;
				friendScore.transform.SetParent(transform, false);
				
				Image thisFriendAvatarImage = friendScore.transform.FindChild("Picture").GetComponentInChildren<Image>();
				FB.API("/" + score.Id + "/picture?type=large", HttpMethod.GET, delegate(IGraphResult friendPic)
				{
					if (friendPic.Error != null)
					{
						JKFacebookUtil.Log("FB FriendPicture Error: " + friendPic.Error);
						
						return;
					}
					
					// Friend PICTURE.
					thisFriendAvatarImage.sprite = Sprite.Create(friendPic.Texture, new Rect(0, 0, friendPic.Texture.width, friendPic.Texture.height), Vector2.zero);
				});

				// Friend POSITON.
				Text thisPositionText = friendScore.transform.FindChild("Position").GetComponentInChildren<Text>();
				thisPositionText.text = string.Format("{0}º", ++position);

				// Friend NAME.
				Text thisFriendNameText = friendScore.transform.FindChild("Name").GetComponentInChildren<Text>();
				thisFriendNameText.text = score.Name.ToUpper();
				
				// Friend SCORE.
				Text thisFriendScoreText = friendScore.transform.FindChild("Score").GetComponentInChildren<Text>();
				string scoreText = Score;
				if (score.Score > 1) scoreText += "S";
				thisFriendScoreText.text = string.Format("{0} {1}", score.Score.ToString(), scoreText);

				// Friend BUTTON Invite.
				var thisInviteButton = friendScore.transform.FindChild("Invite Button").GetComponentInChildren<JKFacebookInviteFriend>();

				// Isn't the player.
				if (score.Id != JKFacebookUserInfo.Identifier)
				{
					thisInviteButton.Identifier = score.Id;
				}
			}
		}
	}
}