using UnityEngine;

namespace MiniGame
{
    public class MiniGameCardLogic : MonoBehaviour
    {
        [SerializeField]
        private MiniGameManager MainManager;

        private int RequiredToWin;
        private int CurrentResult;

        private MiniGameCard Card_First;
        private MiniGameCard Card_Second;

        public void Init(int HowMuchToWin)
        {
            RequiredToWin = HowMuchToWin;
            CurrentResult = 0;
        }

        public void TurnedCard(MiniGameCard Card)
        {
            if (!Card_First)
            {
                Card_First = Card;
                return;
            }

            if (Card == Card_First)
                return;

            Card_Second = Card;

            if (Card_First.Id == Card_Second.Id)
            {
                Card_First.UI.DeactivateCard();
                Card_Second.UI.DeactivateCard();

                CurrentResult += 2;
                CheckForWin();
            }
            else
            {
                Card_First.UI.RotateCard(1f);
                Card_Second.UI.RotateCard(1f);
            }

            Card_First = null;
            Card_Second = null;
        }

        private void CheckForWin()
        {
            if (CurrentResult >= RequiredToWin)
                MainManager.End();
        }
    }
}