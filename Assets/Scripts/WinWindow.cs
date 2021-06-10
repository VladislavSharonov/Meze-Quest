using UnityEngine;

public class WinWindow : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Cursor.visible = true;
    }
}
