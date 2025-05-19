using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame
{
    public class MiniGameSetter : MonoBehaviour
    {
        [SerializeField]
        private MiniGameCardLogic Logic;
        [SerializeField]
        private VerticalLayoutGroup GridParent;
        [SerializeField]
        private MiniGameCard CardPrefab;

        private MiniGameCard[,] Cards;

        public void SetGridSettings(MiniGameSettings Params)
        {
            int Size = Params.AmountPerSide;

            float AvailibleSide = Mathf.Min(Screen.width, Screen.height) * 0.8f; // Берем только 80% от меньшей из сторон экрана
            Vector2 SizeOfCell = Vector2.one * (AvailibleSide / Size);

            Cards = new MiniGameCard[Size, Size];
            var Set = CreateSetForRandom(Params.UniqueSpritesToUse.Length, Size);

            for (int i = 0; i < Size; i++)
            {
                HorizontalLayoutGroup Line = new GameObject($"Line {i}").AddComponent<HorizontalLayoutGroup>();
                Line.childAlignment = TextAnchor.MiddleCenter;
                Line.childControlWidth = false;
                Line.childControlHeight = false;
                Line.childForceExpandHeight = false;
                Line.childForceExpandWidth = false;
                Line.spacing = 5;

                Line.GetComponent<RectTransform>().sizeDelta = Vector2.one * SizeOfCell.x * Size;
                Line.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SizeOfCell.x);

                Line.transform.parent = GridParent.transform;

                for (int j = 0; j < Size; j++)
                {
                    int RandomElementId = Random.Range(0, Set.Count);

                    MiniGameCard Card = Instantiate(CardPrefab, Line.transform);
                    Card.Init(new Vector2Int(i, j), Set[RandomElementId]);
                    Card.UI.Init(Params.UniqueSpritesToUse[Set[RandomElementId]], SizeOfCell, () => Logic.TurnedCard(Card));
                    Cards[i, j] = Card;

                    Set.RemoveAt(RandomElementId);
                }
            }
        }

        private List<int> CreateSetForRandom(int AvailibleSpritesAmount, int SetSize) // Можно было бы проверять Amount % 2, но это просто тестовое задание
        {
            List<int> Result = new List<int>(SetSize * SetSize);

            for(int i = 0; i < SetSize * SetSize; i+=2)
            {
                int RandomId = Random.Range(0, AvailibleSpritesAmount);
                Result.Add(RandomId);
                Result.Add(RandomId);
            }

            return Result;
        }
    }
}