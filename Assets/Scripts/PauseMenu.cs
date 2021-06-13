using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject window;
    
    private bool IsInPauseMenu = false;

    private void Start()
    {
        window.SetActive(false);
    }

    private void Pause()
    {
        window.SetActive(true);
        Time.timeScale = 0f;
        IsInPauseMenu = true;
        Cursor.visible = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        IsInPauseMenu = false;
        window.SetActive(false);
        Cursor.visible = false;
    }

    public void ToMenu()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("MainMenu");
    }
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape) || Time.timeScale < 1e-6) return;
        
        if (IsInPauseMenu)
            Resume();
        else
            Pause();
    }
}
