using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	GameObject bird;

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 320f / 480f;
		bird = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(bird != null){
			transform.position = new Vector3(transform.position.x, bird.transform.position.y + 4.5f,transform.position.z);
		} else {
			bird = GameObject.FindGameObjectWithTag("Player");
		}

	}
}
