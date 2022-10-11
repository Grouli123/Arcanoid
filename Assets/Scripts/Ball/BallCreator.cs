using UnityEngine;

namespace Arcade
{
    public class BallCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;
        private const float OffsetY = 0.5f;

        private void Start()
        {
            Create();
        }

        private void Create()
        {
            Instantiate(_ballPrefab, new Vector3(transform.position.x, transform.position.y + OffsetY), Quaternion.identity, transform);
        }
    }
}
