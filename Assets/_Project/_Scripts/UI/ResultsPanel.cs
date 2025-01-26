using System;
using _Project._Scripts.Managers;
using UnityEngine;
using TMPro;

namespace _Project._Scripts.UI
{
    public class ResultsPanel : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI resultText;
        [SerializeField] TextMeshProUGUI resultVerdict;

        private const string GuiltyText = "Guilty";
        private const string InnocentText = "Innocent";
        
        private const string InnocentVerdict = "\"The coffee has calmed, the bubbles have subsided, and so has the detective's suspicion.\n You’re free—for now.\"";
        private const string GuiltyVerdict = "\"The coffee bubbles furiously, spilling over as your lies collapse. The truth always comes out,\n doesn’t it?\"";
        
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
            resultText.text = isDeceptive ? GuiltyText : InnocentText;
            resultVerdict.text = isDeceptive ? GuiltyVerdict : InnocentVerdict;
        }
    }
}
