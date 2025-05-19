using UnityEngine;

namespace MiniGame
{
    [CreateAssetMenu(menuName = "MiniGame")]
    public class MiniGameSettings : ScriptableObject
    {
        public int AmountPerSide;
        public Sprite[] UniqueSpritesToUse;
    }
}