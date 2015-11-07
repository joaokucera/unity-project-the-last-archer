using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JK.Patterns;
using Random = UnityEngine.Random;

namespace JK.Effects
{
	public class JKSoundManager : JKSingleton<JKSoundManager>
	{
		private Dictionary<string, AudioClip> m_soundDictionary = new Dictionary<string, AudioClip>();

		public static bool MusicEnabled = true;
		public static bool SoundEffectsEnabled = true;
		private static bool DictionaryalreadyCreated = false;

		[SerializeField] private AudioSource m_musicSource;
		[SerializeField] private AudioSource m_sfxSource;
		[SerializeField] private AudioClip[] m_sfxClips;

		void Start()
		{
			if (!DictionaryalreadyCreated)
			{
				DictionaryalreadyCreated = true;

				CreateSoundsDictionary ();
			}
		}

		public static void PlayMusic(AudioClip newMusic)
		{
			if (Instance.m_musicSource.clip == null)
			{
				Instance.StartCoroutine(Instance.PlayingMusic(newMusic));
			}
			else if (!Instance.m_musicSource.clip.name.Equals(newMusic.name))
			{
				Instance.StartCoroutine(Instance.StoppingMusic (newMusic));
			}
		}

		public static void PlayMusicImmediate(AudioClip newMusic)
		{
			Instance.m_musicSource.Stop ();
			
			Instance.StartCoroutine (Instance.PlayingMusic (newMusic));
		}

		public static void PlaySoundEffect(string clipName)
		{
			Instance.PlayingSoundEffect (clipName);
		}

		public static void RandomSoundEffect(params string[] clipNamesArray)
		{
			int index = Random.Range (0, clipNamesArray.Length);
			string clipName = clipNamesArray [index];

			Instance.PlayingSoundEffect (clipName);
		}

		public static void ActiveMusic(Action callback)
		{
			MusicEnabled = !MusicEnabled;
			
			if (MusicEnabled)
			{
				Instance.ContinueMusic ();
			}
			else
			{
				Instance.PauseMusic();
			}
			
			callback();
		}
		
		public static void ActiveSoundEffects(Action callback)
		{
			SoundEffectsEnabled = !SoundEffectsEnabled;
			
			callback();
		}
		
		public static void ActiveMusicFade(Action callback, float waitTime)
		{
			Instance.StartCoroutine(Instance.MusicFade (callback, waitTime));
		}

		IEnumerator MusicFade(Action callback, float waitTime)
		{
			while (m_musicSource.volume > 0.1f)
			{
				m_musicSource.volume -= Time.deltaTime;
				
				yield return null;
			}

			callback ();
			yield return new WaitForSeconds (waitTime);

			while (m_musicSource.volume < 0.9f)
			{
				m_musicSource.volume += Time.deltaTime;
				
				yield return null;
			}
		}

		void CreateSoundsDictionary()
		{
			for (int i = 0; i < m_sfxClips.Length; i++) 
			{
				m_soundDictionary.Add(m_sfxClips[i].name, m_sfxClips[i]);
			}
		}

		void PauseMusic()
		{
			if (m_musicSource.isPlaying)
			{
				m_musicSource.Pause();
			}
		}
		
		void ContinueMusic()
		{
			if (!m_musicSource.isPlaying)
			{
				m_musicSource.Play();
			}
		}

		IEnumerator PlayingMusic(AudioClip newMusic)
		{
			m_musicSource.clip = newMusic;
			m_musicSource.volume = 0f;

			if (MusicEnabled)
			{
				m_musicSource.Play();
			}
			
			while (m_musicSource.volume < 0.9f)
			{
				m_musicSource.volume += Time.deltaTime;
				
				yield return null;
			}
		}

		IEnumerator StoppingMusic(AudioClip newMusic)
		{
			while (m_musicSource.volume > 0.1f)
			{
				m_musicSource.volume -= Time.deltaTime;
				
				yield return null;
			}

			m_musicSource.Stop ();

			StartCoroutine (PlayingMusic (newMusic));
		}

		void PlayingSoundEffect (string clipName)
		{
			if (!SoundEffectsEnabled) 
			{
				return;
			}
			
			AudioClip originalClip;
			
			if (Instance.m_soundDictionary.TryGetValue (clipName, out originalClip)) 
			{
				Instance.MakeSoundEffect (originalClip);
			}
		}

		void MakeSoundEffect(AudioClip originalClip)
		{
			m_sfxSource.PlayOneShot(originalClip);
		}
	}
}