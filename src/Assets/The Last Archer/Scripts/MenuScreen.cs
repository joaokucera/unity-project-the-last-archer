using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheLastArcher
{
	public class MenuScreen : MonoBehaviour 
	{
		public void NewGame() 
		{
			SceneManager.LoadScene ("Level");
		}

		public void Continue() 
		{
			Debug.Log ("Continue");
		}

		public void Options() 
		{
			Debug.Log ("Options");
		}

		public void Leaderboard() 
		{
			Debug.Log ("Leaderboard");
		}
	}
}