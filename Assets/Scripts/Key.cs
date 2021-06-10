using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (!other.transform.TryGetComponent(out Player player)) return;
        Destroy(gameObject);
        player.IsKeyTaken = true;
    }
}
