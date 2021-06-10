using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player))
            return;
        Time.timeScale = 0;
        winUI.SetActive(true);
        CoinsSystem.AddCoin(player.TakenCoinsCount);
    }
}
