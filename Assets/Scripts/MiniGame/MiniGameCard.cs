using UnityEngine;

namespace MiniGame
{
    [RequireComponent(typeof(MiniGameCellUI))]
    public class MiniGameCard : MonoBehaviour
    {
        public MiniGameCellUI UI { get; private set; }
        public Vector2Int Location { get; private set; }
        public int Id { get; private set; }

        public void Init(Vector2Int Location, int Id)
        {
            this.Location = Location;
            this.Id = Id;
            UI = GetComponent<MiniGameCellUI>();
        }
    }
}