using UnityEngine;

namespace Player
{
	internal class PlayerController : CreatureController
	{
		[SerializeField] private Joystick _joystick;
		[SerializeField] private KeyCode _keySprint = KeyCode.LeftShift;
		[SerializeField] private KeyCode _keyJump = KeyCode.Space;
		[SerializeField] private float _jumpForce = 5;
		[SerializeField] private float _distanceYForCanJump = 0.1f;
		[SerializeField] private LayerMask _layerMask;

		private float _currentSpeed;

		public override void Death()
		{
			Healing(MaxHealth);
		}

		public override void Move()
		{
			SetCurrentSpeed();

			Vector2 move = _joystick.Direction * _currentSpeed;


			rb.velocity = transform.TransformDirection(move.x, rb.velocity.y, 0);


			if (move.y > 0.5f && Physics2D.Raycast(transform.position, Vector2.down, _distanceYForCanJump, _layerMask))
			{
				rb.velocity =  Vector2.up * _jumpForce;
			}
		}

		private void SetCurrentSpeed()
		{
			_currentSpeed = Input.GetKey(_keySprint) ? speedSprint : speedDefault;
		}
	}
}