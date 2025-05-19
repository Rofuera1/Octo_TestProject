using Naninovel;
using UnityEngine;

namespace MiniGame
{
    public class MiniGameManager : MonoBehaviour
    {
        [SerializeField]
        private MiniGameCardLogic Logic;
        [SerializeField]
        private MiniGameSetter Setter;
        [SerializeField]
        private MiniGameSettings Settings;

        private void Awake()
        {
            Logic.Init(Settings.AmountPerSide * Settings.AmountPerSide);
            Setter.SetGridSettings(Settings);
        }

        public void End()
        {
            Engine.GetService<MiniGameService>().CompleteMiniGame();
        }
    }
}