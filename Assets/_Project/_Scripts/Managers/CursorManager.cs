using UnityEngine;

namespace _Project._Scripts.Managers
{
    public class CursorManager : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.OnCursorVisibilityChanged += ChangeCursorVisibility;
        }
        
        private void OnDisable()
        {
            EventManager.OnCursorVisibilityChanged -= ChangeCursorVisibility;
        }

        private void ChangeCursorVisibility(bool value)
        {
            Cursor.visible = value;
            Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
