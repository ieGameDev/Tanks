using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Infrastructure.Services.InputService
{
    public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public static bool FireAxis { get; private set; }

        [SerializeField] private Image _fireButton;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_fireButton != null)
                FireAxis = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_fireButton != null)
                FireAxis = false;
        }
    }
}