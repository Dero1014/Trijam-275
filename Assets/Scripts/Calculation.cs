using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Calculation : MonoBehaviour
{
    int a, b, trueResult, fakeResult, result, useResult;

    char mathOperator;
    string calculusString;

    public TextMeshProUGUI CalculusText;
    public int randomDiviation;

    private int operatorRange = 2;
    private int minNumberRange = -1;
    private int maxNumberRange = 10;

    public void StartCalculation()
    {
        GenerateCalculus(2, 2);
    }

    public void Difficulty(int maxNumRange, int minNumRange, int ranDivi = 10, int operatorRangeIncrease = 0)
    {
        if (operatorRange < 3)
        {
            operatorRange += operatorRangeIncrease;
        }
        minNumberRange = minNumRange;
        maxNumberRange = maxNumRange;
        randomDiviation = ranDivi;
    }

    void GenerateCalculus()
    {
        a = Random.Range(minNumberRange, maxNumberRange);
        b = Random.Range(minNumberRange, maxNumberRange);

        mathOperator = PickOperator();

        trueResult = DoCalculus();
        fakeResult = DontCalculus();

        useResult = Random.Range(0, 2);
        print(useResult);

        result = (useResult == 1) ? trueResult : fakeResult;

        calculusString = $"{a} {mathOperator} {b} = {result}";
        CalculusText.text = calculusString;
        print($"True result is: {trueResult}\n Fake result is: {fakeResult}\n");
    }

    void GenerateCalculus(int x, int y)
    {
        a = x;
        b = y;

        mathOperator = '+';

        trueResult = DoCalculus();
        fakeResult = DontCalculus();

        useResult = Random.Range(0, 2);
        print(useResult);

        result = (useResult == 1) ? trueResult : fakeResult;

        calculusString = $"{a} {mathOperator} {b} = {result}";
        CalculusText.text = calculusString;
        print($"True result is: {trueResult}\n Fake result is: {fakeResult}\n");
    }

    char PickOperator()
    {

        switch (Random.Range(0, operatorRange))
        {
            case 0:
                return '+';
            case 1:
                return '-';
            case 2:
                return '*' ;
            default:
                return '+';
        }
    }

    int DoCalculus()
    {
        switch (mathOperator)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            default:
                return 0;
        }
    }

    int DontCalculus()
    {
        int diviation = Random.Range(0, randomDiviation);

        switch (mathOperator)
        {
            case '+':
                return (a + b) + diviation;
            case '-':
                return (a - b) + diviation;
            case '*':
                return (a - b) + (diviation * Random.Range(-1, 2));
            default:
                return 0;
        }
    }

    public string GetCalculusString()
    {
        return calculusString;
    }

    public void Correct()
    {
        if (result == trueResult)
        {
            GameMaster.Instance.Score();
            GenerateCalculus();
        }
        else
        {
            GameMaster.Instance.GameOver();
        }
    }

    public void Incorrect()
    {
        if (result == fakeResult)
        {
            GameMaster.Instance.Score();
            GenerateCalculus();
        }
        else
        {
            GameMaster.Instance.GameOver();
        }
    }
}
