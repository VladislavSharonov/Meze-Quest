using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private long denomination = 1;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private Vector3 rotationVector = Vector3.zero;
    [SerializeField] private float verticalAmplitude;
    [SerializeField] private float verticalSpeed;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * rotationVector);

        var verticalOffset = Mathf.Cos(Time.time * verticalSpeed) * verticalAmplitude * Time.deltaTime;
        transform.Translate(new Vector3(0f, verticalOffset, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        
        Destroy(gameObject);
        player.TakenCoinsCount += (int)denomination;
    }
}
