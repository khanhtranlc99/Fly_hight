using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyTool : MonoBehaviour
{
    #region Instance

    private static MyTool instance;

    public static MyTool Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<MyTool>();
                if (!instance)
                {
                    instance = new GameObject().AddComponent<MyTool>();
                    instance.name = "MyTool";
                }
            }

            return instance;
        }
    }

    public static bool Exist => instance;

    #endregion

    #region Action
    public Action EvtCounttime;

    #endregion

    #region Value
    private Coroutine counttime;
    private bool runtime;
    private int score;
    public int time = 110;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            Debug.Log("score " + score);
            GemUniAPI.Instance.CallOnLimitScore(score);
            PlayerPrefs.SetInt(KEY_SCORE, score);
        }
    }



    #endregion

    #region Unity Method
    private void Awake()
    {
    
           score = PlayerPrefs.GetInt(KEY_SCORE);
     
    }
    private void Start()
    {
        runtime = true;
        counttime = StartCoroutine(CountTime());
   
    }
    private void OnDestroy()
    {
        if (counttime != null)
        {
            runtime = false;
            StopCoroutine(counttime);
        }
    }
    #endregion

    #region   Method
 
    public void CountScoreWithTime()
    {
        time -= 1;
    }


    private IEnumerator CountTime()
    {
        while (runtime)
        {
            yield return new WaitForSeconds(1);
            EvtCounttime?.Invoke();
        }
    }


    #endregion

    #region Key
    public static string KEY_SCORE = "key_score";
   

    #endregion



}
