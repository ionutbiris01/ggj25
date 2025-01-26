using UnityEngine;

namespace _Project._Scripts
{
    public class NpCReference : MonoBehaviour
    {
        public static NpCReference Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
