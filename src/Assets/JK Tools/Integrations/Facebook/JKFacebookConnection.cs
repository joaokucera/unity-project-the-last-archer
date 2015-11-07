using JK.Patterns;

namespace JK.Integrations
{
	public class JKFacebookConnection : JKSingleton<JKFacebookConnection> 
	{
		public static void OnConnect()
		{
			JKFacebookService.UserInfoAPICall();
			JKFacebookService.ProfilePictureAPICall();
			JKFacebookService.QueryScoresAPICall();

			JKFacebookProfile.FillData ();
		}

		public static void OnDisconnect()
		{
			JKFacebookProfile.ClearData();
		}
	}
}