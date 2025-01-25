using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project._Scripts.UI.Utility
{
    public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Scaling Settings")]
        [SerializeField] private float scale = 1.1f; // Target scale when hovered
        private Vector3 _originalScale; // Original scale of the button
        
        private void Start()
        {
            // Cache the original scale
            _originalScale = transform.localScale;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale = _originalScale * scale; 
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = _originalScale;
        }
    }
}
