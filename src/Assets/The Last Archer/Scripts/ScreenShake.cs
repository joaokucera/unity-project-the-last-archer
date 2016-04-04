using System.Collections;
using UnityEngine;

namespace TheLastArcher
{
    public class ScreenShake : Singleton<ScreenShake>
    {
		[Header("Shake Settings")]
		[Range(0f, 1f)] [SerializeField] private float m_shakeDecay = 0.005f;
		[Range(0f, 1f)] [SerializeField] private float m_shakeCoefIntensity = 0.05f;
		[Range(0f, 1f)] [SerializeField] private float m_multiplier = 0.5f;

        public static void Shake()
        {
			Instance.StartCoroutine (Instance.UpdateShake ());
        }

        IEnumerator UpdateShake()
        {
			var camera = GlobalVariables.MainCamera;

			var originPosition = camera.transform.position;
			var originRotation = camera.transform.rotation;

			var shakeIntensity = m_shakeCoefIntensity;

			while (shakeIntensity > 0)
            {
				camera.transform.position = camera.transform.position + Random.insideUnitSphere * shakeIntensity;

				camera.transform.rotation = new Quaternion
                (
					originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * m_multiplier,
					originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * m_multiplier,
					originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * m_multiplier,
					originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * m_multiplier
                );

				shakeIntensity -= m_shakeDecay;

                yield return null;
            }

			camera.transform.position = originPosition;
			camera.transform.rotation = originRotation;
        }
    }
}