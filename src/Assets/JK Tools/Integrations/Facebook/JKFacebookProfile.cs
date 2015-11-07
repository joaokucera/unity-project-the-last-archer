using UnityEngine;
using UnityEngine.UI;
using JK.Patterns;

namespace JK.Integrations
{
	public class JKFacebookProfile : JKSingleton<JKFacebookProfile> 
	{
		private Sprite m_defaultPictureSprite;

		[SerializeField] private Text m_nameText;
		[SerializeField] private Image m_pictureImage;

		void Start()
		{
			m_defaultPictureSprite = m_pictureImage.sprite;
		}

		public static void FillData()
		{
			Instance.m_pictureImage.sprite = JKFacebookUserInfo.ProfilePicture;
			Instance.m_nameText.text = JKFacebookUserInfo.Name;
		}

		public static void ClearData()
		{
			Instance.m_pictureImage.sprite = Instance.m_defaultPictureSprite;
			Instance.m_nameText.text = string.Empty;
		}
	}
}