using UnityEngine.UI;
using UnityEngine;

public class volume : MonoBehaviour
{
    //VARIABLES
    [SerializeField] Slider vol_slider;

    //METHODS
    //methods that allow data to be saved even if the app is closed
    private void Start()
    {
        Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = vol_slider.value;
        Save();
    }

    private void Load()
    {
        if(!PlayerPrefs.HasKey("volume")) PlayerPrefs.SetFloat("volume", .75f);
        else vol_slider.value = PlayerPrefs.GetFloat("volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", vol_slider.value);
    }

}
