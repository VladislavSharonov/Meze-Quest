using TMPro;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label = null;

    private const int Cost = 3;
    private int lastCoinBalance = 0;
    
    
    public void TryBuy()
    {
        if (CoinsSystem.Balance < Cost)
            return;
        
        CoinsSystem.WastCoins(Cost);
        Abilities.ShowMapCount++;
        if (label != null)
            label.text = $"x{Abilities.ShowMapCount}";
    }

    private void Update()
    {
        if (label is null)
            return;
        else if (lastCoinBalance != Abilities.ShowMapCount)
        {
            lastCoinBalance = Abilities.ShowMapCount;
            label.text = $"x{lastCoinBalance}";
        }
    }
}
