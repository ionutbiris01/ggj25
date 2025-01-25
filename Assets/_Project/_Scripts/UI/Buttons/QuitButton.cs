using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project._Scripts.UI.Buttons
{
    public class QuitButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Application.Quit();
        }
    }
}
