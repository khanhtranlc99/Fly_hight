using UnityEngine;
using System.Collections;

public class Cat3Move : MonoBehaviour
{
    public string side;
    public GameObject cat3, warning;
    GameObject cat;

    // Use this for initialization
    void Start()
    {
        if (side.Equals("Left"))
        {
            InvokeRepeating("leftMove", 3f, 4f);
        }
        else if (side.Equals("Right"))
        {
            InvokeRepeating("rightMove", 3f, 4f);
        }

        if (GetComponent<Rigidbody2D>() != null)
        {
            Destroy(gameObject, 3f);
        }
    }

    void Update()
    {
        if (Camera.main.GetComponent<State>().state == "GameOver")
        {
            CancelInvoke();
        }

        if (cat != null)
        {
            float dist = Vector2.Distance(cat.transform.position, warning.transform.position);
         
            if (dist > 200)
            {
                warning.SetActive(false);
            }
            else
            {
                warning.SetActive(true);
            }
        }
    }

    void leftMove()
    {
        cat = Instantiate(cat3, transform.position, Quaternion.identity) as GameObject;

        cat.transform.localScale = new Vector2(-0.8f, 0.8f);
        cat.GetComponent<Rigidbody2D>().velocity = new Vector2(-400, 0);
    }
    void rightMove()
    {
        cat = Instantiate(cat3, transform.position, Quaternion.identity) as GameObject;

        cat.transform.localScale = new Vector2(0.8f, 0.8f);
        cat.GetComponent<Rigidbody2D>().velocity = new Vector2(400, 0);
    }
}
