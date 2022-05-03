using UnityEngine;
using TMPro;
using System;
using System.Globalization;
using System.Linq;

public class calcu : MonoBehaviour
{
    [SerializeField] private float result;
    [SerializeField] private float saved;
    [SerializeField] public TextMeshProUGUI txt_result;
    [SerializeField] private string theOperation;
    [SerializeField] public TMP_FontAsset LiberationSans;
    [SerializeField] public TMP_FontAsset Junegull;
    [SerializeField] private float storedNum;

    private void Update()
    {
        if (txt_result.text != "+" && txt_result.text != "-" && txt_result.text != "x" && txt_result.text != "÷" && txt_result.text != "√" && txt_result.text != "^")
        {
            txt_result.font = Junegull;
            txt_result.fontStyle = FontStyles.Normal;
        }
        else
        {
            txt_result.font = LiberationSans;
            txt_result.fontStyle = FontStyles.Bold;
        }

        print(result);
    }

    float multiplier()
    {
        int lenght = txt_result.text.Split('.').Count() > 1 ? txt_result.text.Substring(txt_result.text.IndexOf(".")).Length : 0;
        float mp = 1;
        for (int i = lenght; i > 0; i--) mp *= .1f;
        return mp;
    }
    
    public void period()
    {
        if (multiplier() > .2)
        {
            txt_result.text = result.ToString("G", CultureInfo.InvariantCulture);
            txt_result.text = result.ToString("F1", CultureInfo.InvariantCulture);
            txt_result.text = txt_result.text.Substring(0, txt_result.text.Length - 1);
        }
    }

    public void numbers(int num)
    {
        txt_result.text += num.ToString();
        result = float.Parse(txt_result.text);

        txt_result.text = result.ToString("G", CultureInfo.InvariantCulture);
    }

    public void operation(string op)
    {
        theOperation = op;
        if (result != 0) saved = result;
        result = 0;
        txt_result.text = theOperation;
    }

    public void store_restore(string s_r)
    {
        if (s_r == "s") storedNum = float.Parse(txt_result.text);
        if (s_r == "r")
        {
            result = storedNum;
            txt_result.text = result.ToString("G", CultureInfo.InvariantCulture);
        }
    }

    public void equals()
    {
        switch (theOperation)
        {
            case "+":
                result = saved + result;
                break;
            case "-":
                result = saved - result;
                break;
            case "x":
                result = saved * result;
                break;
            case "÷":
                result = saved / result;
                break;
            case "√":
                result = (float)Math.Sqrt(result);
                break;
            case "^":
                result = (float)Math.Pow(saved, result);
                break;
        }
        
        txt_result.text = result.ToString("G", CultureInfo.InvariantCulture);
        multiplier().Equals(1);
        saved = result;
        result = 0;
    }

    public void delete()
    {
        if (txt_result.text != "+" && txt_result.text != "-" && txt_result.text != "x" && txt_result.text != "÷" && txt_result.text != "√" && txt_result.text != "^")
        {
            if (txt_result.text.Length > 0) txt_result.text = txt_result.text.Substring(0, txt_result.text.Length - 1);
            if (txt_result.text.Length == 0 || result == 0)
            {
                txt_result.text = "0";
                saved = 0;
            }

            result = float.Parse(txt_result.text);
            print(theOperation);
        }

        else
        {
            theOperation = "";
            result = saved;
            txt_result.text = result.ToString("G", CultureInfo.InvariantCulture);
        }
    }
}