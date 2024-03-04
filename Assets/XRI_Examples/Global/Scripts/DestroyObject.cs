namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// Destroys GameObject after a few seconds.
    /// </summary>
    public class DestroyObject : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Time before destroying in seconds.")]
        public float m_Lifetime = 5f;

        public bool shouldBeDestroyed = true;

        private float time = 0.0f;

        void Start()
        {
            //Destroy(gameObject, m_Lifetime);
        }

        void Update()
        {
            time += Time.deltaTime;
            if (shouldBeDestroyed && time > m_Lifetime)
            {
                time = time - m_Lifetime;
                Destroy(gameObject);
            }
        }
    }
}
