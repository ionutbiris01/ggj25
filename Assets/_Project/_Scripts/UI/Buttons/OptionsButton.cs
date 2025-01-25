using _Project._Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace _Project._Scripts.UI.Buttons
{
    public class OptionsButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            EventManager.ToggleOptionsPanel(true);
            EventManager.ToggleMainMenuPanel(false);
        }
    }
}
