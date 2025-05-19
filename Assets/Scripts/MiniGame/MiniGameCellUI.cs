using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame
{
    public class MiniGameCellUI : MonoBehaviour
    {
        [SerializeField]
        private Sprite CardBack;
        [SerializeField]
        private Image Image;
        [SerializeField]
        private Button Button;

        private Sprite Card;

        private IEnumerator RotatingCoroutine;
        private bool FacingBack;

        private const float HalfRotation = 0.08f;

        public void Init(Sprite Sprite, Vector2 Size, UnityEngine.Events.UnityAction CallOnClick, bool back_at_start = true)
        {
            Card = Sprite;
            GetComponent<RectTransform>().sizeDelta = Size;
            FacingBack = back_at_start;

            if (!back_at_start)
                Image.sprite = Card;

            Button.onClick.AddListener(() => RotateCard(0f));
            Button.onClick.AddListener(() => StartCoroutine(AwaitToInformLogic(HalfRotation * 2, CallOnClick)));
        }

        public void RotateCard(float Delay = 0f)
        {
            FacingBack = !FacingBack;

            if (RotatingCoroutine != null)
                StopCoroutine(RotatingCoroutine);

            StartCoroutine(RotatingCoroutine = RotateCardVisually(FacingBack ? CardBack : Card, HalfRotation, Delay));
        }

        private IEnumerator RotateCardVisually(Sprite EndSprite, float HalfTime, float delay = 0f)
        {
            float t = 0f;
            yield return new WaitForSeconds(delay);

            Vector3 CurrentScale = transform.localScale;

            while(t < HalfTime)
            {
                t += Time.deltaTime;

                transform.localScale = Vector3.Lerp(CurrentScale, Vector3.up, t / HalfTime);

                yield return null;
            }

            Image.sprite = EndSprite;
            t = 0f;

            while (t < HalfTime)
            {
                t += Time.deltaTime;

                transform.localScale = Vector3.Lerp(Vector3.up, Vector3.one, t / HalfTime);

                yield return null;
            }
        }

        private IEnumerator AwaitToInformLogic(float TimeToWait, UnityEngine.Events.UnityAction CallOnClick)
        {
            yield return new WaitForSeconds(TimeToWait);

            CallOnClick?.Invoke();
        }

        public void DeactivateCard()
        {
            Button.interactable = false;
        }
    }
}