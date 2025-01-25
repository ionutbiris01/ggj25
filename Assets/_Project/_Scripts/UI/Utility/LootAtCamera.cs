using UnityEngine;

namespace _Project._Scripts.UI.Utility
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera;

        private void Start()
        {
            if (targetCamera == null)
            {
                targetCamera = Camera.main;
            }
        }

        private void LateUpdate()
        {
            if (targetCamera == null) return;
            
            var rotation = targetCamera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward,
                rotation * Vector3.up);
        }
    }
}