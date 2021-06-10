using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject loseWindow;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        player.TakeDamage();
    }
}
