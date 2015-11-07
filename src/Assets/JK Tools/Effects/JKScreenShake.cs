using System.Collections;
using UnityEngine;
using JK.Patterns;

namespace JK.Effects
{
    public class JKScreenShake : JKSingleton<JKScreenShake>
    {
		[SerializeField] private Camera m_camera;
		[SerializeField] private float m_shakeDecay = 0.001f;
		[SerializeField] private float m_shakeCoefIntensity = 0.01f;
		[SerializeField] private float m_multiplier = 0.1f;

		void Start()
		{
			if (m_camera == null) m_camera = Camera.main;
		}

        public static void Shake()
        {
			Instance.StartCoroutine (Instance.UpdateShake ());
        }

        IEnumerator UpdateShake()
        {
			var originRotation = m_camera.transform.rotation;

			var shakeIntensity = m_shakeCoefIntensity;

			while (shakeIntensity > 0)
            {
				m_camera.transform.position = m_camera.transform.position + Random.insideUnitSphere * shakeIntensity;

				m_camera.transform.rotation = new Quaternion
                (
					originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * m_multiplier,
					originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * m_multiplier,
					originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * m_multiplier,
					originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * m_multiplier
                );

				shakeIntensity -= m_shakeDecay;

                yield return null;
            }

			m_camera.transform.rotation = originRotation;
        }
    }
}