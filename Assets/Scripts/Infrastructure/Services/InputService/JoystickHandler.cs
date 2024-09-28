using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _joystickBackground;
        [SerializeField] private Image _joystick;

        private RectTransform _backgroundRectTransform;
        private RectTransform _joystickRectTransform;

        protected Vector2 _inputVector;

        private void Start()
        {
            _backgroundRectTransform = _joystickBackground.rectTransform;
            _joystickRectTransform = _joystick.rectTransform;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 joystickPosition;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
            {
                float scaleFactorX = 2f / _backgroundRectTransform.sizeDelta.x;
                float scaleFactorY = 2f / _backgroundRectTransform.sizeDelta.y;

                joystickPosition.x *= scaleFactorX;
                joystickPosition.y *= scaleFactorY;

                _inputVector = joystickPosition;
                _inputVector = Vector2.ClampMagnitude(_inputVector, 1f);

                _joystickRectTransform.anchoredPosition = new Vector2(
                    _inputVector.x * (_backgroundRectTransform.sizeDelta.x / 2), 
                    _inputVector.y * (_backgroundRectTransform.sizeDelta.y / 2)
                    );
            }
        }

        public void OnPointerDown(PointerEventData eventData) => 
            OnDrag(eventData);

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputVector = Vector2.zero;
            if (_joystick != null)
                _joystickRectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
