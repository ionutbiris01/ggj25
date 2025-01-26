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
        
        [ContextMenu("TestIntensityModified")]
        public void ModifyIntensity()
        {
            CoffeCupIntensity = 0.9f;
        }
        
        
        private void OnEnable()
        {
            ConvaiNPCManager.Instance.OnActiveNPCChanged += npc =>
            {
                EventManager.TriggerConvaiTriggered(Enums.ConvaiTriggerType.T_Introduction);
            };
        }
        private void OnDisable()
        {
            ConvaiNPCManager.Instance.OnActiveNPCChanged -= npc =>
            {
                EventManager.TriggerConvaiTriggered(Enums.ConvaiTriggerType.T_Introduction);
            };
        }
        void Start()
        {
            EventManager.ChangeCursorVisibility(false);
            EventManager.ToggleOptionsPanel(false);
            EventManager.ToggleResultsPanel(false);
        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isOptionsPanelActive = !_isOptionsPanelActive;
                EventManager.ChangeCursorVisibility(_isOptionsPanelActive);
                EventManager.ToggleOptionsPanel(_isOptionsPanelActive);
            }
        }
    }
}
