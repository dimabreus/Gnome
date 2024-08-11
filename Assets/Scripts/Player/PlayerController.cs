using UnityEngine;

namespace Player
{
	internal class PlayerController : CreatureController
	{
		[SerializeField] private Joystick _joystick;
		[SerializeField] private float _jumpForce = 5;
		[SerializeField] private float _distanceYForCanJump = 0.1f;
		[SerializeField] private LayerMask _layerMask;

		public override void Death()
		{
			Healing(MaxHealth);
		}

		public override void Move()
		{
			Vector2 move = InputManager.Direction * speedDefault;

			rb.velocity = transform.TransformDirection(move.x, rb.velocity.y, 0);

			if (move.y > 0.5f && Physics2D.Raycast(transform.position, Vector2.down, _distanceYForCanJump, _layerMask))
			{
				rb.velocity =  Vector2.up * _jumpForce;
			}
		}
	}
}