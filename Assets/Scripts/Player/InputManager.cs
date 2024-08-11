using UnityEngine;
using TMPro;

namespace Player
{
    class InputManager : MonoBehaviour
    {
        [SerializeField] GameObject _joystickWithButtons;
        [SerializeField] GameObject _onlyButtons;
        [SerializeField] GameObject _onlyJoystick;
        [SerializeField] private TMP_Dropdown _dropdown;

        private static Vector2 _direction;

        public static void SetDirectionX(float x)
        {
            _direction.x = x;
        }
        public static void SetDirectionlY(float y)
        {
            _direction.y = y;
        }

        public void SetMethodMove()
        {
            _joystickWithButtons.SetActive(_dropdown.value == 0);
            _onlyButtons.SetActive(_dropdown.value == 1);
            _onlyJoystick.SetActive(_dropdown.value == 2);
        }

        public static Vector2 Direction
        {
            get => _direction;
            set => _direction = value;
        }
    }
}