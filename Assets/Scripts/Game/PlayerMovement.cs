using UnityEngine;

namespace Arcade
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private float _moveX = 0f;
        private float _speed = 15f;
        private const float _borderPosition = 7.5f;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            float positionX = _rigidbody2D.position.x + _moveX * _speed * Time.fixedDeltaTime;
            positionX = Mathf.Clamp(positionX, -_borderPosition + (_spriteRenderer.size.x / 2), _borderPosition - (_spriteRenderer.size.x / 2));
            _rigidbody2D.MovePosition(new Vector2(positionX, _rigidbody2D.position.y));
        }

        private void OnEnable()
        {
            PlayerInput.OnMove += Move;
        }

        private void OnDisable()
        {
            PlayerInput.OnMove -= Move;
        }

        private void Move(float moveX)
        {
            _moveX = moveX;
        }
    }
}
