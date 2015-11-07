using UnityEngine;
using UnityEngine.UI;

namespace JK.Integrations
{
	public class JKFacebookInviteFriend : MonoBehaviour
	{
		[SerializeField] private Button m_inviteButton;

		[HideInInspector] public string Identifier;

		void Start()
		{
			m_inviteButton.onClick.AddListener(OnInvite);
		}

		private void OnInvite()
		{
			JKFacebookInvite.OnInviteFriend (Identifier);
		}
	}
}