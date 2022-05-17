using UnityEngine;
using System.Collections;

public class DisableGround : MonoBehaviour {
	public GameObject player;
	public Vector2 dist;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null){
			player = GameObject.FindGameObjectWithTag("Player");
		} else if(Camera.main.GetComponent<State>().state == "Game" || Camera.main.GetComponent<State>().state == "Menu"){
			dist.x = transform.position.x - player.transform.position.x;
			dist.y = transform.position.y - player.transform.position.y;
		}


		if(dist.y > 40f){
			Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), player.GetComponent<CircleCollider2D>(), true);
		}else if(dist.y < - 70f){
			Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), player.GetComponent<CircleCollider2D>(), false);
		}
	}

}
