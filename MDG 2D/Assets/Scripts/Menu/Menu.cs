using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    //VARIABLES
    [SerializeField] public GameObject buttons;

    //METHODS
    #region Play

    [SerializeField] public Animator transition;

    //when the game is first opened, wait until the animation has succefully ended
    private void Start()
    {
        StartCoroutine(WaitA());
    }

    //change scene
    public void Play()
    {
        //disable all the buttons to make transition clear
        buttons.SetActive(false);

        //play animation
        transition.SetTrigger("start");

        StartCoroutine(WaitB());
    }

    //count 1.1 seconds before changing scene in order to give enough time to the button to play its sound effect and to play the transition animation
    IEnumerator WaitA()
    {
        yield return new WaitForSeconds(1.2f);

        //active the buttons
        buttons.SetActive(true);
    }
    IEnumerator WaitB()
    {
        yield return new WaitForSeconds(1.1f);

        //change scene
        SceneManager.LoadScene("MAIN");
    }

    #endregion

    #region Options

    //variables
    [SerializeField] public GameObject opt;

    //opening the settings menu and disabling the other buttons if the settings menu is cliccked
    public void Options()
    {
        opt.SetActive(true);
        buttons.SetActive(false);
    }

    #endregion

    #region Credits

    //variables
    [SerializeField] public GameObject cred;

    //opening the credits menu and disabling the other buttons if the credits menu is cliccked
    public void Credits()
    {
        cred.SetActive(true);
        buttons.SetActive(false);
    }

    #endregion
}
