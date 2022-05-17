using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using UnityEngine.SocialPlatforms;

using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    public Text scoreGame, bestGame, bestMenu, coinGame, totalcoin, shopCoin, shopBest, reachText, gameNameText, tapText;
    public int coin, score;
    public GameObject bird2, bird3, bird4, bird5, bird6, bird7, bird8;
    public Sprite bg1, bg2, ground1, ground2, soundOn, soundOff, floorBird, floorBird2;
    GameObject background;
    GameObject[] grounds;
    GameObject[] groundsOld;
    GameObject clouds;
    GameObject bgCorners;
    public Button sound;
    public GameObject bgSound, coinSound, jumpSound;
    public Image reach, reachImage;
    public managerVars vars;
  

    void OnEnable()
    {
        vars = Resources.Load("manager") as managerVars;
    }
    
    void Start()
    {
        bgSound.GetComponent<AudioSource>().clip = vars.bgSound;
        bgSound.GetComponent<AudioSource>().Play();
        gameNameText.text = vars.gameTitle;
        tapText.text = vars.tapStart;

        background = GameObject.Find("Background");
        clouds = GameObject.Find("Clouds");
        bgCorners = GameObject.Find("BgCorners");


    }

    // Update is called once per frame
    void Update()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        groundsOld = GameObject.FindGameObjectsWithTag("GroundOld");

        if (Camera.main.GetComponent<State>().state != "Menu")
        {
            scoreGame.text = "   " + score;
            bestGame.text = "    BEST " + PlayerPrefs.GetInt("bestScore");
            coinGame.text = "" + coin;
            totalcoin.text = "TOTAL " + PlayerPrefs.GetInt("totalCoin");
        }
        else if (Camera.main.GetComponent<State>().state == "Menu")
        {
            bestMenu.text = "BEST " + PlayerPrefs.GetInt("bestScore");
        }

        if (Camera.main.GetComponent<State>().state == "Birds" || Camera.main.GetComponent<State>().state == "GameOver")
        {
            checkBirds();
        }

        if (score >= 20)
        {
            background.GetComponent<SpriteRenderer>().sprite = bg2;
            foreach (GameObject ground in grounds)
            {
                ground.transform.root.GetComponent<SpriteRenderer>().sprite = ground2;
            }
            foreach (GameObject groundOld in groundsOld)
            {
                groundOld.transform.root.GetComponent<SpriteRenderer>().sprite = ground2;
            }
            clouds.GetComponent<MeshRenderer>().enabled = false;
            bgCorners.GetComponent<SpriteRenderer>().color = new Color32(255, 131, 131, 255);
        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = bg1;
            foreach (GameObject ground in grounds)
            {
                ground.transform.root.GetComponent<SpriteRenderer>().sprite = ground1;
            }
            foreach (GameObject groundOld in groundsOld)
            {
                groundOld.transform.root.GetComponent<SpriteRenderer>().sprite = ground1;
            }
            clouds.GetComponent<MeshRenderer>().enabled = true;
            bgCorners.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }

        if (PlayerPrefs.GetInt("sound") == 0)
        {
            sound.GetComponent<Image>().sprite = soundOff;
            bgSound.GetComponent<AudioSource>().mute = true;
            coinSound.GetComponent<AudioSource>().mute = true;
            jumpSound.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            sound.GetComponent<Image>().sprite = soundOn;
            bgSound.GetComponent<AudioSource>().mute = false;
            coinSound.GetComponent<AudioSource>().mute = false;
            jumpSound.GetComponent<AudioSource>().mute = false;
        }

        if (PlayerPrefs.GetInt("reklam") >= vars.showAdAfterDead)
        {
#if UNITY_ANDROID
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
#endif
            PlayerPrefs.SetInt("reklam", 0);
            PlayerPrefs.Save();
        }
    }

    void checkBirds()
    {
        shopCoin.text = " " + PlayerPrefs.GetInt("totalCoin");
        shopBest.text = "Best " + PlayerPrefs.GetInt("bestScore");

        if (PlayerPrefs.GetInt("bestScore") >= vars.unlockAt2)
        {
            reach.enabled = false;
            reachText.enabled = false;
            reachImage.enabled = false;
            PlayerPrefs.SetInt("bird8bought", 1);
            PlayerPrefs.Save();
        }
        else if (PlayerPrefs.GetInt("bestScore") >= vars.unlockAt1 && PlayerPrefs.GetInt("bestScore") <= 49)
        {
            PlayerPrefs.SetInt("bird7bought", 1);
            PlayerPrefs.Save();
            reachText.text = "REACH " + vars.unlockAt2 + " FLOOR TO UNLOCK!";
            reachImage.sprite = floorBird2;
        }
        else
        {
            reachText.text = "REACH " + vars.unlockAt1 + " FLOOR TO UNLOCK!";
            reachImage.sprite = floorBird;
        }

        if (PlayerPrefs.GetInt("bird2bought") == 1)
        {
            bird2.GetComponentInChildren<Text>().enabled = false;
            Image[] getImage = bird2.GetComponentsInChildren<Image>();
            getImage[0].enabled = true;
            getImage[1].enabled = false;
            getImage[2].enabled = true;
        }
        if (PlayerPrefs.GetInt("bird3bought") == 1)
        {
            bird3.GetComponentInChildren<Text>().enabled = false;
            Image[] getImage = bird3.GetComponentsInChildren<Image>();
            getImage[0].enabled = true;
            getImage[1].enabled = false;
            getImage[2].enabled = true;
        }
        if (PlayerPrefs.GetInt("bird4bought") == 1)
        {
            bird4.GetComponentInChildren<Text>().enabled = false;
            Image[] getImage = bird4.GetComponentsInChildren<Image>();
            getImage[0].enabled = true;
            getImage[1].enabled = false;
            getImage[2].enabled = true;
        }
        if (PlayerPrefs.GetInt("bird5bought") == 1)
        {
            bird5.GetComponentInChildren<Text>().enabled = false;
            Image[] getImage = bird5.GetComponentsInChildren<Image>();
            getImage[0].enabled = true;
            getImage[1].enabled = false;
            getImage[2].enabled = true;
        }
        if (PlayerPrefs.GetInt("bird6bought") == 1)
        {
            bird6.GetComponentInChildren<Text>().enabled = false;
            Image[] getImage = bird6.GetComponentsInChildren<Image>();
            getImage[0].enabled = true;
            getImage[1].enabled = false;
            getImage[2].enabled = true;
        }
        if (PlayerPrefs.GetInt("bird7bought") == 1)
        {
            bird7.GetComponentInChildren<Text>().enabled = false;
            Image[] getImage = bird7.GetComponentsInChildren<Image>();
            getImage[0].enabled = true;
            getImage[1].color = new Color32(255, 255, 255, 255);
        }
        if (PlayerPrefs.GetInt("bird8bought") == 1)
        {
            bird8.GetComponentInChildren<Text>().enabled = false;
            Image[] getImage = bird8.GetComponentsInChildren<Image>();
            getImage[0].enabled = true;
            getImage[1].color = new Color32(255, 255, 255, 255);
        }
    }

    public void birdsBtn()
    {
        Camera.main.GetComponent<State>().state = "Birds";
    }
    public void taptoStartBtn()
    {
        if (Camera.main.GetComponent<State>().state == "Game")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<BirdControl>().JumpFunc();
        }
        else
        {
            Camera.main.GetComponent<State>().state = "Game";
        }
    }
    public void retryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void rateBtn()
    {
        Application.OpenURL(vars.rateUrl);
    }

    public void leaderBtn()
    {
        Social.ReportScore(PlayerPrefs.GetInt("bestScore"), vars.leaderboard, (bool success) =>
        {
            // handle success or failure
        });
        Social.ShowLeaderboardUI();
    }

    public void backBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void soundBtn()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
        }
    }

    public void buyBird(Button button)
    {
        switch (button.name)
        {
            case "Bird1":
                PlayerPrefs.SetInt("selectedBird", 0);
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Camera.main.GetComponent<State>().state = "Menu";
                break;
            case "Bird2":
                if (PlayerPrefs.GetInt("bird2bought") == 0)
                {
                    if (PlayerPrefs.GetInt("totalCoin") >= vars.bird2Price)
                    {
                        PlayerPrefs.SetInt("bird2bought", 1);
                        PlayerPrefs.SetInt("totalCoin", PlayerPrefs.GetInt("totalCoin") - 25);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("selectedBird", 1);
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Camera.main.GetComponent<State>().state = "Menu";
                }
                break;
            case "Bird3":
                if (PlayerPrefs.GetInt("bird3bought") == 0)
                {
                    if (PlayerPrefs.GetInt("totalCoin") >= vars.bird3Price)
                    {
                        PlayerPrefs.SetInt("bird3bought", 1);
                        PlayerPrefs.SetInt("totalCoin", PlayerPrefs.GetInt("totalHtotalCoinoneyBox") - 50);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("selectedBird", 2);
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Camera.main.GetComponent<State>().state = "Menu";
                }
                break;
            case "Bird4":
                if (PlayerPrefs.GetInt("bird4bought") == 0)
                {
                    if (PlayerPrefs.GetInt("totalCoin") >= vars.bird4Price)
                    {
                        PlayerPrefs.SetInt("bird4bought", 1);
                        PlayerPrefs.SetInt("totalCoin", PlayerPrefs.GetInt("totalCoin") - 75);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("selectedBird", 3);
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Camera.main.GetComponent<State>().state = "Menu";
                }
                break;
            case "Bird5":
                if (PlayerPrefs.GetInt("bird5bought") == 0)
                {
                    if (PlayerPrefs.GetInt("totalCoin") >= vars.bird5Price)
                    {
                        PlayerPrefs.SetInt("bird5bought", 1);
                        PlayerPrefs.SetInt("totalCoin", PlayerPrefs.GetInt("totalCoin") - 100);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("selectedBird", 4);
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Camera.main.GetComponent<State>().state = "Menu";
                }
                break;
            case "Bird6":
                if (PlayerPrefs.GetInt("bird6bought") == 0)
                {
                    if (PlayerPrefs.GetInt("totalCoin") >= vars.bird6Price)
                    {
                        PlayerPrefs.SetInt("bird6bought", 1);
                        PlayerPrefs.SetInt("totalCoin", PlayerPrefs.GetInt("totalCoin") - 150);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("selectedBird", 5);
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Camera.main.GetComponent<State>().state = "Menu";
                }
                break;
            case "Bird7":
                if (PlayerPrefs.GetInt("bird7bought") == 1)
                {
                    PlayerPrefs.SetInt("selectedBird", 6);
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Camera.main.GetComponent<State>().state = "Menu";
                }
                break;
            case "Bird8":
                if (PlayerPrefs.GetInt("bird8bought") == 1)
                {
                    PlayerPrefs.SetInt("selectedBird", 7);
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Camera.main.GetComponent<State>().state = "Menu";
                }
                break;
        }
    }


}
