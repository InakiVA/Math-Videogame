using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using System;

public class Texto : MonoBehaviour
{
    [HideInInspector]
    public int num1, num2, den1, den2, numRes, denRes;
    int[] maxRange = new int[12] { 4, 6, 8, 4, 6, 8, 5, 10, 15, 5, 10, 15 };
    public TMP_Text num1Text, num2Text, den1Text, den2Text, /*numResText, denResText,*/ tiempo, errorCount, tiempoResults;
    public TMP_InputField numResText, denResText;
    public GameObject finishScreen, loseScreen;
    GameLogic lg;

    // Start is called before the first frame update
    void Start()
    {
        numRes = 0;
        denRes = 1;
        numResText.text = numRes.ToString();
        denResText.text = denRes.ToString();
        lg = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        CreateFractions();
        finishScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        num1Text.text = num1.ToString();
        num2Text.text = num2.ToString();
        den1Text.text = den1.ToString();
        den2Text.text = den2.ToString();
        //numResText.text = numRes.ToString();
        //denResText.text = denRes.ToString();
        errorCount.text = lg.errores.ToString();
        if (!lg.finish)
        {
            tiempo.text = Time.timeSinceLevelLoad.ToString("f0");
            tiempoResults.text = Time.timeSinceLevelLoad.ToString("f0");
        }
    }

    public void CreateFractions()
    {
        numRes = 0;
        denRes = 1;
        //den1 = UnityEngine.Random.Range(2, 4);
        den1 = UnityEngine.Random.Range(2, maxRange[((3*(lg.type-1))+lg.level)-1]);
        //UnityEngine.Debug.Log("Max Den: " + maxRange[(((3*(lg.type-1))+lg.level)-1)].ToString());

        num1 = UnityEngine.Random.Range(1, den1);
        den2 = UnityEngine.Random.Range(2, maxRange[((3*(lg.type-1))+lg.level)-1]);
        num2 = UnityEngine.Random.Range(1, den2);

        //num1 = 1; num2 = 4; den1 = 3; den2 = 5;

        if ((float)num2/(float)den2 > (float)num1/(float)den1)
        {
            UnityEngine.Debug.Log("Seria negativo");
            int tempDen, tempNum;
            tempDen = den2;
            tempNum = num2;
            den2 = den1;
            num2 = num1;
            den1 = tempDen;
            num1 = tempNum;
        }
    }

    public void AddButtonNum()
    {
        numRes++;
        numResText.text = numRes.ToString();
    }

    public void SubButtonNum()
    {
        if (numRes != 0)
        {
            numRes--;
            numResText.text = numRes.ToString();
        }
    }

    public void AddButtonDen()
    {
        denRes++;
        denResText.text = denRes.ToString();
    }

    public void SubButtonDen()
    {
        if (denRes != 1)
        {
            denRes--;
            denResText.text = denRes.ToString();
        }
    }
}
