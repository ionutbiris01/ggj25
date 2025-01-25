using System;
using _Project._Scripts.Managers;
using UnityEngine;

namespace _Project._Scripts.UI
{
    public class MainMenuPanel : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.OnMainMenuPanelToggle += TogglePanel;
        }
        
        private void OnDisable()
        {
            EventManager.OnMainMenuPanelToggle -= TogglePanel;
        }

        private void TogglePanel(bool toggleValue)
        {
            transform.GetChild(0).gameObject.SetActive(toggleValue);
        }
    }
}
