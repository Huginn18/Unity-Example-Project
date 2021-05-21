namespace HoodedCrow.Core.Utils
{
    using UnityEngine;

    /// <summary>
    /// Base example taken from
    /// https://wiki.unity3d.com/index.php/Singleton
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Check to see if we're about to be destroyed.
        private static bool m_ShuttingDown = false;
        private static object m_Lock = new object();
        private static T m_Instance;

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (m_ShuttingDown)
                {
                    m_Instance = (T)FindObjectOfType(typeof(T));

                    if (m_Instance == null)
                        Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");

                    return m_Instance;
                }

                lock (m_Lock)
                {
                    if (m_Instance == null)
                    {
                        // Search for existing instance.
                        m_Instance = (T)FindObjectOfType(typeof(T));
                    }

                    return m_Instance;
                }
            }
        }

        protected void Awake()
        {
            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    m_Instance = GetComponent<T>();
                }
            }
        }


        protected void OnApplicationQuit()
        {
            m_ShuttingDown = true;
        }


        protected void OnDestroy()
        {
            m_ShuttingDown = true;
        }
    }
}
