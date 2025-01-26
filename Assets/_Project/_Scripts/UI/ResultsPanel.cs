using System;
using _Project._Scripts.Managers;
using UnityEngine;

namespace _Project._Scripts.UI
{
    public class ResultsPanel : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.OnResultsPanelToggle += TogglePanel;
        }
        
        private void OnDisable()
        {
            EventManager.OnResultsPanelToggle -= TogglePanel;
        }

        private void TogglePanel(bool toggleValue)
        {
            transform.GetChild(0).gameObject.SetActive(toggleValue);
        }
    }
}
