using Player;
using UnityEngine;

public class JoystickMovementHandler : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private void Update()
    {
        InputManager.SetDirectionX(_joystick.Direction.x);
    }
}
