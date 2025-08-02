using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinChip : MonoBehaviour
{
    public int value;
    public TextMeshProUGUI label;

    public void SetValue(int amount)
    {
        value = amount;
        label.text = FormatValue(amount);
    }

    private string FormatValue(int val)
    {
        if (val >= 1000)
            return (val / 1000).ToString() + "K";
        return val.ToString();
    }

    public void OnClick()
    {
        Debug.Log("Selected bet: " + value);
        // You can pass this to your bet manager
        FindObjectOfType<BetManager>().SetCurrentBet(value);
    }
}
