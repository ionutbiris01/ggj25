using _Project._Scripts.UI.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project._Scripts.UI.Buttons
{
    public class StartButton : ButtonClickEffect
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            
            SceneManager.LoadScene("Game");
        }
    }
}
