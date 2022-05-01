using UnityEngine;
using UnityEngine.SceneManagement;

public class back_button : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
