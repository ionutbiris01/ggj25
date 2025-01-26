using Convai.Scripts.Runtime.Core;
using UnityEngine;

namespace _Project._Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Range(0, 1)]
        [SerializeField]
        private float _coffeCupIntensity;
        private bool _isOptionsPanelActive;
        private bool _isResultPanelActive;
        private bool _finalResult;

        public float CoffeCupIntensity
        {
            get => _coffeCupIntensity;
            set
            {
                if (Mathf.Approximately(_coffeCupIntensity, value)) return; 
                _coffeCupIntensity = value;
                EventManager.ChangeCoffeCupIntensity(_coffeCupIntensity);
            }
        }
        
        [ContextMenu("TestIntensityModified  0.8")]
        public void ModifyIntensity()
        {
            // CoffeCupIntensity = 0.9f;
            EventManager.ChangeCoffeCupIntensity(0.8f);
        }
        
        [ContextMenu("TestIntensityModified  0")]
        public void ModifyIntensityTo0()
        {
            // CoffeCupIntensity = 0.9f;
            EventManager.ChangeCoffeCupIntensity(0.01f);
        }
        
        
        private void OnEnable()
        {
            ConvaiNPCManager.Instance.OnActiveNPCChanged += npc =>
            {
                EventManager.TriggerConvaiTriggered(Enums.ConvaiTriggerType.T_Introduction);
            };

            EventManager.OnResultsPanelToggle += GetEndGameStatus;
        }
        private void OnDisable()
        {
            ConvaiNPCManager.Instance.OnActiveNPCChanged -= npc =>
            {
                EventManager.TriggerConvaiTriggered(Enums.ConvaiTriggerType.T_Introduction);
            };
            
            EventManager.OnResultsPanelToggle -= GetEndGameStatus;
        }
        
        void Start()
        {
            EventManager.ChangeCursorVisibility(false);
            EventManager.ToggleOptionsPanel(false);
            EventManager.ToggleResultsPanel(false, false);
            EventManager.ChangeCoffeCupIntensity(0.01f);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isOptionsPanelActive = !_isOptionsPanelActive;
                EventManager.ChangeCursorVisibility(_isOptionsPanelActive);
                EventManager.ToggleOptionsPanel(_isOptionsPanelActive);
                EventManager.ToggleResultsPanel(false, _finalResult);
            }
        }

        private void GetEndGameStatus(bool state, bool result)
        {
            _isResultPanelActive = state;
            _finalResult = result;
        }
    }
}
