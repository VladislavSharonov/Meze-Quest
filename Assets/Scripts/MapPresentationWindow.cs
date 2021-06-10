using UnityEngine;

public class MapPresentationWindow : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}
