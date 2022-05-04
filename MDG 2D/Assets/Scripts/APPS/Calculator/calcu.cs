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
    [SerializeField] private float multiplier()
    {
        int lenght = txt_result.text.Split(',').Count() > 1 && !isItResult ? txt_result.text.Substring(txt_result.text.IndexOf(",")).Length : 0;
        float mp = 1;
        for (int i = lenght; i > 0; i--) mp *= .1f;
        return mp;
    }
    [SerializeField] private bool isItResult;
    [SerializeField] private bool isItOperator()
    {
        if (txt_result.text == "+" || txt_result.text == "-" || txt_result.text == "x" || txt_result.text == "÷" ||
            txt_result.text == "√" || txt_result.text == "^")
            return true;
        return false;
    }


    private void Update()
    {
        if (!isItOperator())
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
        if (multiplier() > .2)
        {
            if (isItResult || isItOperator() || txt_result.text == "")
            {
                txt_result.text = "0,";
                isItResult = false;
            }
            else txt_result.text += ",";
        }
    }

    public void numbers(int num)
    {
        if (isItOperator() || isItResult)
        {
            txt_result.text = "";
            isItResult = false;
        }

        txt_result.text += num.ToString();
    }

    public void operation(string op)
    {
        isItResult = false;
        theOperation = op;
        result = float.Parse(txt_result.text);
        saved = result;
        result = 0;
        txt_result.text = theOperation;
    }

    public void store_restore(string s_r)
    {
        if (s_r == "s") storedNum = float.Parse(txt_result.text);
        if (s_r == "r")
        {
            result = storedNum;
            txt_result.text = result.ToString(CultureInfo.CreateSpecificCulture("fr-FR"));
        }
    }

    public void equals()
    {
        if (isItOperator())
        {
            saved = 0;
            theOperation = "";
            txt_result.text = "";
        }

        switch (theOperation)
        {
            case "+":
                result = saved + float.Parse(txt_result.text);
                break;
            case "-":
                result = saved - float.Parse(txt_result.text);
                break;
            case "x":
                result = saved * float.Parse(txt_result.text);
                break;
            case "÷":
                result = saved / float.Parse(txt_result.text);
                break;
            case "√":
                result = (float)Math.Sqrt(float.Parse(txt_result.text));
                break;
            case "^":
                result = (float)Math.Pow(saved, float.Parse(txt_result.text));
                break;
        }

        isItResult = true;
        txt_result.text = result.ToString(CultureInfo.CreateSpecificCulture("fr-FR"));
        multiplier().Equals(1);
        theOperation = "";
        saved = result;
        result = 0;
    }

    public void delete()
    {
        if (!isItOperator())
            txt_result.text = txt_result.text.Length > 0 ? txt_result.text.Substring(0, txt_result.text.Length - 1) : "";
        else
        {
            theOperation = "";
            txt_result.text = saved.ToString(CultureInfo.CreateSpecificCulture("fr-FR"));
        }

        if (isItResult)
        {
            txt_result.text = "";
            isItResult = false;
        }
    }
}