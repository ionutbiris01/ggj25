using UnityEngine;

namespace _Project._Scripts.Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        private void Start()
        {
            EventManager.ToggleOptionsPanel(false);
            EventManager.ToggleMainMenuPanel(true);
        }
    }
}
