using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void ToMainMenu()
    {
        SaveSystem.Save();
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ToGame()
    {
        SaveSystem.Save();
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Game");
    }
    
    public void ToLevelSelectionMenu()
    {
        SaveSystem.Save();
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("LevelSelectionMenu");
    }

    public void Exit()
    {
        SaveSystem.Save();
        Application.Quit();
    }
}
