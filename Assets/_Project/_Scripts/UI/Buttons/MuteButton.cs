using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project._Scripts.UI.Buttons
{
    public class MuteButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Sprite[] sprites;
        
        private bool _isMuted;
        private Image _image;
        
        private void Start()
        {
            _image = GetComponent<Image>();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _isMuted = !_isMuted;
            _image.sprite = _isMuted ? sprites[1] : sprites[0];
            
            //todo trigger event
        }
    }
}
