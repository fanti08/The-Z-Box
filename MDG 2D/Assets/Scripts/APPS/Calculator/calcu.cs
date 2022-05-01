using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class calcu : MonoBehaviour
{
    [SerializeField] private float result;
    [SerializeField] private float saved;
    [SerializeField] public TextMeshProUGUI txt_result;
    [SerializeField] private float multiplier = 1;
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
    }

    public void period()
    {
        if (multiplier > .2)
        {
            multiplier = .1f;
            txt_result.text = result.ToString("F1", CultureInfo.InvariantCulture);/*/
            if (txt_result.text != "+" && txt_result.text != "-" && txt_result.text != "x" && txt_result.text != "÷" && txt_result.text != "√" && txt_result.text != "^") txt_result.text += ".";
            else
            {
                txt_result.text = result.ToString("F2", CultureInfo.InvariantCulture);
                txt_result.text += ".";
            }/*/
        }
    }

    public void zero()
    {
        if (multiplier < .2) txt_result.text += "0";
    }

    public void numbers(int num)
    {
        if (multiplier > .2)
        {
            result *= 10;
            result += num;
        }

        else
        {
            result += num * multiplier;
            multiplier *= .1f;
        }

        if (num != 0 || multiplier > .2) txt_result.text = result.ToString();
    }

    public void operation(string op)
    {
        theOperation = op;
        if (result != 0) saved = result;
        multiplier = 1;
        result = 0;
        txt_result.text = theOperation;
    }

    public void store_restore(string s_r)
    {
        if (s_r == "s") storedNum = float.Parse(txt_result.text);
        if (s_r == "r")
        {
            result = storedNum;
            txt_result.text = storedNum.ToString();
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
        
        txt_result.text = result.ToString();
        result = 0;
        saved = float.Parse(txt_result.text);
        multiplier = 1;
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

            if (multiplier < .2) multiplier *= 10;

            result = float.Parse(txt_result.text);
        }
    }
}