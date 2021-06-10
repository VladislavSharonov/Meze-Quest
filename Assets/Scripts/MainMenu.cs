using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static bool isOpen;
    public GameObject window;

    private void Start()
    {
        window.SetActive(false);
    }

    private void Close()
    {
        window.SetActive(false);
        isOpen = false;
    }
    
    private void Open()
    {
        window.SetActive(true);
        isOpen = true;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (isOpen)
            QuitGame();
        else
            Open();
    }
}
