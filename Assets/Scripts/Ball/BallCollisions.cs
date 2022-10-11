using UnityEngine;
namespace Arcade
{
    public class BallCollisions : MonoBehaviour
    {
        [SerializeField] private BallMove _ball;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _ball.MoveCollision(collision);

            if (collision.gameObject.TryGetComponent(out Block block))
            {
                block.ApplyDamage();
            }
        }
    }
}
