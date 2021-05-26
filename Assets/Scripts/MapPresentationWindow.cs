using UnityEngine;

public class MapPresentationWindow : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
