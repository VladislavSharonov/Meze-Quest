using UnityEngine;
using UnityEngine.SceneManagement;

public class StartApplication : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        SaveSystem.LoadSave();
        SceneManager.LoadScene("MainMenu");
    }
}
