using _Project._Scripts.Managers;
using _Project._Scripts.UI.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace _Project._Scripts.UI.Buttons
{
    public class BackButton : ButtonClickEffect
    {
        [SerializeField] private bool isMainMenuItem;
        
        private TextMeshProUGUI _text;
     
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();

            _text.text = isMainMenuItem ? "Back" : "Exit";
        }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            
            EventManager.ToggleOptionsPanel(false);

            if (isMainMenuItem)
            {
                EventManager.ToggleMainMenuPanel(true);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
