using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class State : MonoBehaviour
{
    public string state;
    public GameObject menu, game, gameover, birds;
    public GameObject[] selectBird;

    // Use this for initialization
    void Start()
    {
        state = "Menu";
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "Menu":
                menu.SetActive(true);
                game.SetActive(false);
                gameover.SetActive(false);
                birds.SetActive(false);
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (!player)
                {
                    switch (PlayerPrefs.GetInt("selectedBird"))
                    {
                        case 0:
                            Instantiate(selectBird[0], new Vector2(0, 4.8f), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(selectBird[1], new Vector2(0, 4.8f), Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(selectBird[2], new Vector2(0, 4.8f), Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(selectBird[3], new Vector2(0, 4.8f), Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(selectBird[4], new Vector2(0, 4.8f), Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(selectBird[5], new Vector2(0, 4.8f), Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(selectBird[6], new Vector2(0, 4.8f), Quaternion.identity);
                            break;
                        case 7:
                            Instantiate(selectBird[7], new Vector2(0, 4.8f), Quaternion.identity);
                            break;
                    }
                }
                break;
            case "Game":
                menu.SetActive(false);
                game.SetActive(true);
                gameover.SetActive(false);
                birds.SetActive(false);
                break;
            case "GameOver":
                menu.SetActive(false);
                game.SetActive(false);
                gameover.SetActive(true);
                birds.SetActive(false);
                break;
            case "Birds":
                menu.SetActive(false);
                game.SetActive(false);
                gameover.SetActive(false);
                birds.SetActive(true);
                break;
        }

    }
}
