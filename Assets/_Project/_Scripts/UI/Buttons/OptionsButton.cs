using _Project._Scripts.Managers;
using _Project._Scripts.UI.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace _Project._Scripts.UI.Buttons
{
    public class OptionsButton : ButtonClickEffect
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            
            EventManager.ToggleOptionsPanel(true);
            EventManager.ToggleMainMenuPanel(false);
        }
    }
}
