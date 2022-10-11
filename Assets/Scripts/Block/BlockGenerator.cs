using System.Collections.Generic;
using UnityEngine;

namespace Arcade
{
    public class BlockGenerator : MonoBehaviour
    {
        [SerializeField] private List<BlockData> _blocks;
        [SerializeField] private GameObject _winPannel;
       
        private void Start()
        {
            Time.timeScale = 1f;
            for (int i = 0; i < _blocks.Count; i++)
            {
                GameObject game = Instantiate(_blocks[i].Prefab, new Vector3(0 + i, 0, 0), Quaternion.identity);
                GameObject game1 = Instantiate(_blocks[i].Prefab, new Vector3(0 - i, 0, 0), Quaternion.identity);

                if (game.TryGetComponent(out Block block))
                { 
                    block.SetData(_blocks[i]);
                }
                if (game1.TryGetComponent(out Block block1))
                {
                    block1.SetData(_blocks[i]);
                }
            }
        }

        private void OnEnable()
        {
            Block.OnEnded += EndGame;
        }

        private void OnDisable()
        {
            Block.OnEnded -= EndGame;
        }

        private void EndGame()
        {
            _winPannel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
