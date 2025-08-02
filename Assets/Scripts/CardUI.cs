using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public RectTransform rectTransform;
    public GameObject face;
    public GameObject back;
    public Image faceImage;

    private bool isFaceUp = false;

    public void SetFaceSprite(Sprite sprite)
    {
        faceImage.sprite = sprite;
    }

    public void Flip(bool faceUp)
    {
        rectTransform.DOScaleX(0f, 0.2f).OnComplete(() =>
        {
            face.SetActive(faceUp);
            back.SetActive(!faceUp);
            rectTransform.DOScaleX(1f, 0.2f);
            isFaceUp = faceUp;
        });
    }

    public void ToggleFlip()
    {
        Flip(!isFaceUp);
    }
}
