using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GemUniAPI : MonoBehaviour
{
    private static GemUniAPI instance;

    public static GemUniAPI Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GemUniAPI>();
                if (!instance)
                {
                    instance = new GameObject().AddComponent<GemUniAPI>();
                    instance.name = "GemUniAPI";
                }
            }

            return instance;
        }
    }


    [DllImport("__Internal")]
    private static extern void jsBindingRequestSubmitFromUnity();

     [DllImport("__Internal")]
    private static extern void jsBindingGemUniAPIFromUnity(); 
    
    [DllImport("__Internal")]
    private static extern void jsBindingOnLimitScoreFromUnity(int score);

    public bool isWebGL()
    {
#if !UNITY_EDITOR 
            return true;
#endif
        return false;
    }
    void Start()
    {
        //aFunctionImplementedInJavaScriptLibraryFile("A string from C# side!");
        //UnityBindingFunc("abddaccs!");
        Debug.Log(isWebGL());
        if (!isWebGL()) return;
        //jsBindingGemUniAPIFromUnity();
        //jsBindingOnLimitScoreFromUnity(123123);
   //     jsBindingRequestSubmitFromUnity();
   
    }

    void Init()
    {
        //do something
    }

   public void CallGemUniAPI()
    {
        if (!isWebGL()) return;
        jsBindingGemUniAPIFromUnity();
     
    }

    public void CallOnLimitScore()
    {
        if (!isWebGL()) return;
        jsBindingGemUniAPIFromUnity();
    
    }

    public void CallOnLimitScore(int score)
    {
        if (!isWebGL()) return;
        jsBindingOnLimitScoreFromUnity(score);
        Debug.LogError("+++++++++++++++++++CallOnLimitScore " + score);
    }

    public void CallRequestSubmit()
    {
     
        if (!isWebGL()) return;
        jsBindingRequestSubmitFromUnity();
        Debug.LogError("+++++++++++++++++++CallRequestSubmit");
    }
}
