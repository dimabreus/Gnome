using Player;
using UnityEngine;

public class JoystickInputer : MonoBehaviour
{
	[SerializeField] private Joystick _joystick;

	private void Update()
	{
		InputManager.SetDirectionX(_joystick.Direction.x);
		InputManager.SetDirectionlY(_joystick.Direction.y);
	}
}
