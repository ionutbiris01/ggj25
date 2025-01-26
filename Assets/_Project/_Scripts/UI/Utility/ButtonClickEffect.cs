using _Project._Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project._Scripts.UI.Utility
{
    public class ButtonClickEffect : MonoBehaviour, IPointerClickHandler
    {
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            EventManager.TriggerPlayButtonClickSFX();
        }
    }
}