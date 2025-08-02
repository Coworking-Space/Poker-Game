using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PokerGameManager : MonoBehaviour
{
    public Transform deckTransform;
    public Transform[] communityCardSlots;
    public GameObject cardPrefab;
    public List<Sprite> cardSprites;

    private List<Sprite> shuffledDeck = new List<Sprite>();

    public void StartGame()
    {
        ShuffleDeck();
        DealCommunityCards();
    }

    public void ShuffleDeck()
    {
        shuffledDeck = new List<Sprite>(cardSprites);
        for (int i = 0; i < shuffledDeck.Count; i++)
        {
            Sprite temp = shuffledDeck[i];
            int randomIndex = Random.Range(i, shuffledDeck.Count);
            shuffledDeck[i] = shuffledDeck[randomIndex];
            shuffledDeck[randomIndex] = temp;
        }
    }

    public void DealCommunityCards()
    {
        StartCoroutine(DealRoutine());
    }

    private IEnumerator DealRoutine()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject cardObj = Instantiate(cardPrefab, deckTransform.position, Quaternion.identity, transform);
            CardUI card = cardObj.GetComponent<CardUI>();
            card.SetFaceSprite(shuffledDeck[i]);

            RectTransform cardRect = cardObj.GetComponent<RectTransform>();
            cardRect.SetParent(communityCardSlots[i], false);
            cardRect.DOAnchorPos(Vector2.zero, 0.4f).SetEase(Ease.OutQuad);

            yield return new WaitForSeconds(0.5f);
            card.Flip(true);
        }
    }
}
