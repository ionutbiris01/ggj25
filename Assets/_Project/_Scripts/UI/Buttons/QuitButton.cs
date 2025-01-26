using _Project._Scripts.UI.Utility;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project._Scripts.UI.Buttons
{
    public class QuitButton : ButtonClickEffect
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            
            Application.Quit();
        }
    }
}
