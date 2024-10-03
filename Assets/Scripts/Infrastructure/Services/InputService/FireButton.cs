using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Services.InputService
{
    public class FireButton : MonoBehaviour
    {
        public static bool FireAxis { get; private set; }

        private Button _fireButton;

        private void Awake()
        {
            _fireButton = GetComponent<Button>();
            _fireButton.onClick.AddListener(OnButtonPress);
        }

        private void OnButtonPress()
        {
            FireAxis = true;
            Invoke(nameof(ResetFireAxis), 0.1f);
        }

        private void ResetFireAxis() =>
            FireAxis = false;
    }
}