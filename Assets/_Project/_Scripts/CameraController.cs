using UnityEngine;

namespace _Project._Scripts
{
    public class CameraController : MonoBehaviour
    {
        [Header("Rotation Settings")]
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private float minVerticalAngle = -60f; // Minimum vertical angle (looking down)
        [SerializeField] private float maxVerticalAngle = 60f;  // Maximum vertical angle (looking up)

        private float _verticalRotation = 0f; // Tracks the vertical rotation

        private void Update()
        {
            HandleRotation();
        }

        private void HandleRotation()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            // Horizontal rotation (free rotation around Y-axis)
            transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime, Space.World);

            // Vertical rotation with clamping (only affects the local X-axis)
            _verticalRotation -= mouseY * rotationSpeed * Time.deltaTime;
            _verticalRotation = Mathf.Clamp(_verticalRotation, minVerticalAngle, maxVerticalAngle);

            var cameraTransform = transform;
            var currentRotation = cameraTransform.localEulerAngles;
            currentRotation.x = _verticalRotation;
            cameraTransform.localEulerAngles = new Vector3(_verticalRotation, currentRotation.y, currentRotation.z);
        }
    }
}