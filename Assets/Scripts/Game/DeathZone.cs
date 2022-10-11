using UnityEngine;

namespace Arcade
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private GameObject _losePannel;
        [SerializeField] private GameObject _WinPannel;

        private void Start()
        {
            Time.timeScale = 1f;
            _losePannel.SetActive(false);
            _WinPannel.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out BallMove ball))
            {
                Destroy(ball.gameObject);
                _losePannel.SetActive(true);
                _WinPannel.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
}
