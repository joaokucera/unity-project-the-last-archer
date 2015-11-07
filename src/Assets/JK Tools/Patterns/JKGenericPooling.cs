using System.Collections.Generic;
using UnityEngine;

namespace JK.Patterns
{
    public abstract class JKGenericPooling : MonoBehaviour
    {
		private List<GameObject> m_pool = new List<GameObject>();

        [SerializeField] private GameObject m_prefab;
        [SerializeField] private int m_poolSize = 1;
        [SerializeField] private bool m_poolCanGrow = false;

        void Awake()
        {
            if (m_prefab == null)
            {
                Debug.LogError("Has not been defined a prefab!");
            }

            GeneratePool();
        }

		protected GameObject GetObjectFromPool(bool active = true)
        {
            for (int i = 0; i < m_pool.Count; i++)
            {
                var obj = m_pool[i];

                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(active);

                    return obj;
                }
            }

            if (m_poolCanGrow)
            {
                var obj = CreateNewObject();

                obj.SetActive(active);

                return obj;
            }

            return null;
        }

        protected void DeactivateAll()
        {
            for (int i = 0; i < m_pool.Count; i++)
            {
                m_pool[i].SetActive(false);

                m_pool[i].transform.position = Vector3.zero;
            }
        }

        private void GeneratePool()
        {
            for (int i = 0; i < m_poolSize; i++)
            {
                CreateNewObject();
            }
        }

		private GameObject CreateNewObject()
        {
            var newObject = Instantiate(m_prefab, transform.position, transform.rotation) as GameObject;
            newObject.SetActive(false);
            newObject.transform.SetParent(transform);

            m_pool.Add(newObject);

            return newObject;
        }
    }
}