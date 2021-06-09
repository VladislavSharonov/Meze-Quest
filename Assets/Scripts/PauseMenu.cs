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

    public void Pause()
    {
        window.SetActive(true);
        Time.timeScale = 0f;
        IsInPauseMenu = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        IsInPauseMenu = false;
        window.SetActive(false);
    }

    public void ToMenu()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("MainMenu");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
            if (IsInPauseMenu)
                Resume();
            else
                Pause();
		}
    }
}
