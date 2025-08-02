using UnityEngine;

public class GameEventHandler : MonoBehaviour
{
    public PokerGameManager gameManager;

    public void OnMessageReceived(string command)
    {
        switch (command)
        {
            case "start_game":
                gameManager.StartGame();
                break;

            case "shuffle":
                gameManager.ShuffleDeck();
                break;

            case "deal_cards":
                gameManager.DealCommunityCards();
                break;

            default:
                Debug.LogWarning("Unknown command: " + command);
                break;
        }
    }
}
