using System;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

namespace JK.Integrations
{
	public class JKFacebookService : ScriptableObject
	{
		public static void InitAPICall()
		{
			FB.Init (OnInitComplete, OnHideUnity);
		}
		
		public static void ConnectionAPICall()
		{
			if (!FB.IsLoggedIn)
			{
				OnLogin();
			}
			else
			{
				OnLogout();
			}
		}
		
		public static void UserInfoAPICall()
		{
			FB.API("/me?fields=id,first_name,name,gender,friends.limit(100).fields(id,first_name,name)", HttpMethod.GET, UserInfoCallback);
		}
		
		public static void ProfilePictureAPICall()
		{
			FB.API("/me/picture?type=large", HttpMethod.GET, ProfilePictureCallback);
		}

		public static void ShareAPICall (Uri contentURL, string contentTitle, string contentDescription, Uri photoURL)
		{
			FB.ShareLink
			(
				contentURL: contentURL,
				contentTitle: contentTitle,
				contentDescription: contentDescription,
				photoURL: photoURL
			);
		}

		public static void InviteAPICall (string inviteTitle, string inviteMessage)
		{
			FB.AppRequest 
			(
				message: inviteMessage,
				title: inviteTitle
			);
		}

		public static void InviteFriendAPICall (string friendIdentifier, string inviteTitle, string messageFriend, string data)
		{
			string[] recipient = { friendIdentifier };
			
			FB.AppRequest
			(
				message: messageFriend,
				to: recipient,                                     
				filters : null,                                                                                         
				excludeIds : null,                                                                                                 
				maxRecipients : null,                                                                                              
				data: data,
				title: inviteTitle
			);                                                                                                                                                                                                                         
		}

		public static void QueryScoresAPICall()
		{
			FB.API("/app/scores?fields=score,user.limit(100)", HttpMethod.GET, QueryScoresCallback);
		}

		public static void SetScoresAPICall (int score)
		{
			var scoresData = new Dictionary<string, string> ();
			scoresData ["score"] = score.ToString();

			FB.API ("/me/scores", HttpMethod.POST, delegate (IGraphResult result)
			{
				JKFacebookUtil.Log ("Score submit result: " + result.RawResult);
				
				QueryScoresAPICall ();
				
			}, scoresData);
		}

		static void OnInitComplete()
		{
			OnLoggedIn(FB.IsLoggedIn);
		}
		
		static void OnHideUnity(bool isGameShows)
		{
			Time.timeScale = isGameShows ? 1f : 0f;
		}
		
		static void OnLogin()
		{
			var permission = new List<string> () { "email", "publish_actions" };

			FB.LogInWithPublishPermissions(permission, LoginCallback);
		}
		
		static void OnLogout()
		{
			FB.LogOut ();
			
			LogoutCallback ();
		}
		
		static void LoginCallback(ILoginResult result)
		{
			OnLoggedIn(FB.IsLoggedIn);
		}
		
		static void LogoutCallback()
		{
			OnLoggedIn(false);
		}
		
		static void OnLoggedIn(bool isLoggedIn)
		{
			if (isLoggedIn)
			{
				JKFacebookConnection.OnConnect();
			}
			else
			{
				JKFacebookConnection.OnDisconnect();
			}
		}

		static void UserInfoCallback(IGraphResult result)
		{
			if (result.Error != null)
			{
				JKFacebookUtil.LogError("FB userInfo Error: " + result.Error);
				
				UserInfoAPICall();
				
				return;
			}
			
			JKFacebookUserInfo.FillUserInfo (result.RawResult);
		}
		
		static void ProfilePictureCallback(IGraphResult result)
		{
			if (result.Error != null)
			{
				JKFacebookUtil.LogError("FB ProfilePicture Error: " + result.Error);

				ProfilePictureAPICall();
				
				return;
			}

			JKFacebookUserInfo.FillPicture (result.Texture);
		}

		static void QueryScoresCallback(IGraphResult result)
		{
			if (result.Error != null)
			{
				JKFacebookUtil.LogError("FB Scores Error: " + result.Error);
				
				return;
			}

			JKFacebookUserInfo.FillScoresCollection(result.RawResult);
		}
	}
}