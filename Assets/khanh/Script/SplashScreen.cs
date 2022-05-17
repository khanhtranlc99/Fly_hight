using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public GameObject splashScreen;
    private void Start()
    {
        GemUniAPI.Instance.CallGemUniAPI();
        Debug.LogError("Test");
    }
    public void Off()
    {
  
        Invoke("Wait",1);
    }
    public void Wait()
    {
     
      
        PlayerPrefs.DeleteAll();
       
        splashScreen.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("World");
        //jsBindingGemUniAPIFromUnity();
        //jsBindingOnLimitScoreFromUnity(123123);
        //jsBindingRequestSubmitFromUnity();
    }
}
