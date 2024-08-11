using UnityEngine;

namespace Player
{
    internal class PlayerController : CreatureController
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private float _jumpForce = 5;

        [Header("Ground Check")]
        [SerializeField] private float _distanceYForCanJump = 0.6f;
        [SerializeField] private LayerMask _groundLayer;

        public override void Death()
        {
            Healing(MaxHealth);
        }

        public override void Move()
        {
            Vector2 move = InputManager.Direction * speedDefault;

            rb.velocity = transform.TransformDirection(move.x, rb.velocity.y, 0);

            if (move.y > 0.5f && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            }
        }

        private bool IsGrounded()
        {
            Vector2 origin = transform.position;
            Vector2 direction = Vector2.down;
            return Physics2D.Raycast(origin, direction, _distanceYForCanJump, _groundLayer);
        }
    }
}