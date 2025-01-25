using System;
using _Project._Scripts.Managers;
using UnityEngine;

namespace _Project._Scripts.UI
{
    public class OptionsPanel : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.OnOptionsPanelToggle += TogglePanel;
        }
        
        private void OnDisable()
        {
            EventManager.OnOptionsPanelToggle -= TogglePanel;
        }

        private void TogglePanel(bool toggleValue)
        {
            transform.GetChild(0).gameObject.SetActive(toggleValue);
        }
    }
}
