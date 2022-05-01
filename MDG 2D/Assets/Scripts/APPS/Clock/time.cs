using UnityEngine;
using TMPro;

public class time : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timeAt;

    private void Update()
    {
        int secs = int.Parse(System.DateTime.Now.ToString("ss"));
        int mins = int.Parse(System.DateTime.Now.ToString("mm"));
        int hrs = int.Parse(System.DateTime.Now.ToString("hh"));

        timeAt.text = hrs + ":" + mins+ ":" + secs;
    }
}
