using UnityEngine;

namespace _Project._Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Range(0,1)] public float coffeCupIntensity = 0;
        
        private bool _isOptionsPanelActive;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            EventManager.ChangeCursorVisibility(false);
            EventManager.ToggleOptionsPanel(false);
        }

        // Update is called once per frame
        void Update()
        {
            EventManager.ChangeCoffeCupIntensity(coffeCupIntensity);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isOptionsPanelActive = !_isOptionsPanelActive;
                EventManager.ChangeCursorVisibility(_isOptionsPanelActive);
                EventManager.ToggleOptionsPanel(_isOptionsPanelActive);
            }
        }
    }
}
