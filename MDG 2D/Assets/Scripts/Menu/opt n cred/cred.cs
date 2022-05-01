using UnityEngine;

public class cred : MonoBehaviour
{
    //METHODS
    #region Animation

    //variables
    [SerializeField] public Animator animator;

    //display all the credits and the easter egg
    public void PlayCredits()
    {
        animator.Play("Credit Anim");
    }

    #endregion

    #region Close

    //variables
    [SerializeField] public GameObject credit_panel;
    [SerializeField] public GameObject buttons;

    //closing the credits menu and activing the other buttons
    public void Close()
    {
        credit_panel.SetActive(false);
        buttons.SetActive(true);    
    }

    #endregion
}
