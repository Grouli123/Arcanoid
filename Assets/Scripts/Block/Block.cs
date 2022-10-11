using System;
using System.Collections.Generic;
using UnityEngine;
using Scriptable;
using static UnityEngine.ParticleSystem;

namespace Arcade
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private IntegerVariable _coinCounter;
        private static int _count = 0;
        private List<Sprite> _sprites;
        private int _score;
        private SpriteRenderer _spriteRenderer;
        private int _life;
        public static event Action OnEnded;
        public static event Action<int> OnDestroyed;

        public void SetData(BlockData blockData)
        {
            _sprites = new List<Sprite>(blockData.Sprites);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _life = _sprites.Count;
            _spriteRenderer.sprite = _sprites[_life - 1];
            MainModule main = GetComponent<ParticleSystem>().main;
            main.startColor = _spriteRenderer.color = blockData.BaseColor;
        }

        public void ApplyDamage()
        {
            _life--;
            if( _life < 1 )
            {
                _spriteRenderer.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<ParticleSystem>().Play();
                _coinCounter.ApplyChange(1);
            }
            else
            {
                _spriteRenderer.sprite = _sprites[_life - 1];
            }
        }

        private void OnEnable()
        {
            _count++;
        }

        private void OnDisable()
        {
            _count--;

            OnDestroyed?.Invoke(_score);

            if(_count <1)
            {
                OnEnded?.Invoke();
            }
        }
    }
}
