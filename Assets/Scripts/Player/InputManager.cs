using UnityEngine;
using TMPro;

namespace Player
{
    class InputManager : MonoBehaviour
    {
        [SerializeField] GameObject _joystickWithButtons;
        [SerializeField] GameObject _onlyButtons;
        [SerializeField] GameObject _onlyJoystick;
        [SerializeField] private TMP_Dropdown _selectDropdown;

        private static Vector2 _direction;

        public static void SetDirectionX(float x)
        {
            _direction.x = x;
        }

        public static void SetDirectionY(float y)
        {
            _direction.y = y;
        }

        public void SetMethodMove()
        {
            _joystickWithButtons.SetActive(_selectDropdown.value == 0);
            _onlyButtons.SetActive(_selectDropdown.value == 1);
            _onlyJoystick.SetActive(_selectDropdown.value == 2);
        }

        public static Vector2 Direction
        {
            get => _direction;
            set => _direction = value;
        }
    }
}