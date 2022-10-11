using System.Collections.Generic;
using UnityEngine;

namespace Arcade
{
    [CreateAssetMenu(fileName = "BlockData", menuName = "GameData/Create/BlockData")]
    public class BlockData : ScriptableObject
    {
        public GameObject Prefab;
        public List<Sprite> Sprites;
        public Color BaseColor;
    }
}
