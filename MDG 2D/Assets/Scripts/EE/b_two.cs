using UnityEngine;
using UnityEngine.UI;

public class b_two : MonoBehaviour
{
    private void Start()
    {
        if (opt.case_lang != 4) GetComponent<ScrollRect>().enabled = false;
    }
}
