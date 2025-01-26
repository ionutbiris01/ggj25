using System;
using _Project._Scripts.Managers;
using UnityEngine;
using TMPro;

namespace _Project._Scripts.UI
{
    public class ResultsPanel : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI resultText;

        private const string DeceptiveText = "Guilty";
        private const string TruthfulText = "Truthful";
        private void OnEnable()
        {
            EventManager.OnResultsPanelToggle += TogglePanel;
        }
        
        private void OnDisable()
        {
            EventManager.OnResultsPanelToggle -= TogglePanel;
        }

        private void TogglePanel(bool toggleValue, bool isDeceptive)
        {
            transform.GetChild(0).gameObject.SetActive(toggleValue);
            resultText.text = isDeceptive ? DeceptiveText : TruthfulText;
        }
    }
}
