using UnityEngine;
using TMPro;

public class BetManager : MonoBehaviour
{
    public int currentBet;
    public TextMeshProUGUI currentBetText;

    public void SetCurrentBet(int amount)
    {
        currentBet = amount;
        currentBetText.text = "Current Bet: " + FormatValue(currentBet);
    }

    private string FormatValue(int val)
    {
        if (val >= 1000)
            return (val / 1000).ToString() + "K";
        return val.ToString();
    }
}
