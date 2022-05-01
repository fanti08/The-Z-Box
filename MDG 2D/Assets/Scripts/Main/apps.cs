using UnityEngine;
using UnityEngine.SceneManagement;

public class apps : MonoBehaviour
{
    public void calculator()
    {
        SceneManager.LoadScene("CALCULATOR");
    }
    public void clock()
    {
        SceneManager.LoadScene("CLOCK");
    }
}
