using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace _Project._Scripts.UI.Buttons
{
    public class StartButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
