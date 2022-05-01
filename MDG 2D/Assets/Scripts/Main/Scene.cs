using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    //VARIABLES
    [SerializeField] public Animator transition;
    [SerializeField] public GameObject buttons;

    //METHODS
    //when the game is first opened, wait until the animation has succefully ended
    private void Start()
    {
        StartCoroutine(WaitA());
    }

    //change scene
    public void Menu()
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

        //enable the buttons
        buttons.SetActive(true);
    }
    IEnumerator WaitB()
    {
        yield return new WaitForSeconds(1.1f);

        //change scene
        SceneManager.LoadScene("MENU");
    }
}
