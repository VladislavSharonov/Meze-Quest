using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWindow : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    
    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public static void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        Cursor.visible = true;
    }
}
