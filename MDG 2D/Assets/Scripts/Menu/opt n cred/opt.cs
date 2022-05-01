using UnityEngine;
using TMPro;

public class opt : MonoBehaviour
{
    //METHODS
    #region Volume
    //see "volume" script
    #endregion

    #region Language

    //variables
    [SerializeField] public GameObject select_button;
    [SerializeField] public GameObject scroll;
    [SerializeField] public TextMeshProUGUI langs;
    [SerializeField] public static int case_lang;

    [SerializeField] public TextMeshProUGUI credits;
    [SerializeField] public TextMeshProUGUI play;
    [SerializeField] public TextMeshProUGUI options;
    [SerializeField] public TextMeshProUGUI opts;
    [SerializeField] public TextMeshProUGUI back;
    [SerializeField] public TextMeshProUGUI volume;
    [SerializeField] public TextMeshProUGUI language;
    [SerializeField] public TextMeshProUGUI support;

    //setting the language to what the player chose, or to english by default
    private void Start()
    {
        case_lang = PlayerPrefs.GetInt("Case Language", 0);

        switch (case_lang)
        {
            case 0:
                langs.text = "english";
                English();
                break;
            case 1:
                langs.text = "italiano";
                Italiano();
                break;
            case 2:
                langs.text = "espanol";
                Espanol();
                break;
            case 3:
                langs.text = "francais";
                Francais();
                break;
            case 4:
                langs.text = "deutsch";
                Deutsch();
                break;
        }
    }

    //opening the scrollable menu with the list of the languages
    public void Select()
    {
        select_button.SetActive(false);
        scroll.SetActive(true);
    }

    //setting the language with PlayerPrefs
    public void Language(int lang)
    {
        select_button.SetActive(true);
        scroll.SetActive(false);
        case_lang = lang;
        PlayerPrefs.SetInt("Case Language", case_lang);

        switch(case_lang)
        {
            case 0:
                langs.text = "english";
                English();
                break;
            case 1:
                langs.text = "italiano";
                Italiano();
                break;
            case 2:
                langs.text = "espanol";
                Espanol();
                break;
            case 3:
                langs.text = "francais";
                Francais();
                break;
            case 4:
                langs.text = "deutsch";
                Deutsch();
                break;
        }
    }

    //making all writing matching the language chosen by the player
    private void English()
    {
        credits.text = "credits";
        play.text = "play";
        options.text = "settings";
        opts.text = "settings";
        back.text = "<-- back";
        volume.text = "volume";
        language.text = "language";
        support.text = "contact us";
    }
    private void Italiano()
    {
        credits.text = "crediti";
        play.text = "gioca";
        options.text = "opzioni";
        opts.text = "opzioni";
        back.text = "<-- indietro";
        volume.text = "volume";
        language.text = "lingua";
        support.text = "contattaci";
    }
    private void Espanol()
    {
        credits.text = "creditos";
        play.text = "jugar";
        options.text = "ajustes";
        opts.text = "ajustes";
        back.text = "<-- regresar";
        volume.text = "volumen";
        language.text = "idioma";
        support.text = "contactanos";
    }
    private void Francais()
    {
        credits.text = "credit";
        play.text = "jouer";
        options.text = "parametres";
        opts.text = "parametres";
        back.text = "<-- arriere";
        volume.text = "son";
        language.text = "langue";
        support.text = "contactez-nous";
    }
    private void Deutsch()
    {
        credits.text = "anerkennung";
        play.text = "spielen";
        options.text = "einstellungen";
        opts.text = "einstellungen";
        back.text = "<-- zuruck";
        volume.text = "volumen";
        language.text = "sprache";
        support.text = "kontaktiere uns";
    }

    #endregion

    #region Support
    //coming soon...
    #endregion

    #region Back

    //variables
    [SerializeField] public GameObject opt_panel;
    [SerializeField] public GameObject buttons;

    //closing the settings menu and activing the other buttons
    public void Back()
    {
        opt_panel.SetActive(false);
        buttons.SetActive(true);
    }

    #endregion
}
