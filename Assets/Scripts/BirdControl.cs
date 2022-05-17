using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BirdControl : MonoBehaviour {
	Rigidbody2D rigid2D;
	Animator anim;
	bool side;
	public bool jump;
	public bool secondJump;
	public AudioClip coinSound, jumpSound;
	GameObject coinAudioSource, jumpAudioSource;
	managerVars vars;

	void OnEnable(){
		vars = Resources.Load ("manager") as managerVars;
	}

	// Use this for initialization
	void Start () {
		coinSound = vars.coinSound;
		jumpSound = vars.jumpSound;
		rigid2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		side = true;
		coinAudioSource = GameObject.Find("CoinSound");
		jumpAudioSource = GameObject.Find("JumpSound");
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.GetComponent<State>().state == "Game"){
			if(side == false){
				rigid2D.velocity = new Vector2(-280f, rigid2D.velocity.y);
				transform.localScale = new Vector2(-1.1f, 1.1f);
			} else {
				rigid2D.velocity = new Vector2(280f, rigid2D.velocity.y);
				transform.localScale = new Vector2(1.1f, 1.1f);
			}
		}

		if(Input.GetMouseButtonDown(0)){
			if(!EventSystem.current.IsPointerOverGameObject()){
				if(Camera.main.GetComponent<State>().state == "Game"){
					JumpFunc();
				} else {
					Camera.main.GetComponent<State>().state = "Game";
				}
			}
		}

		if(PlayerPrefs.GetInt("bestScore") < Camera.main.GetComponent<GUI>().score){
			PlayerPrefs.SetInt("bestScore", Camera.main.GetComponent<GUI>().score);
			PlayerPrefs.Save();
		}

	}

	public void JumpFunc(){
		if (jump == false) {
			rigid2D.velocity = new Vector2(rigid2D.velocity.x, 700);
			jump = true;
			anim.SetBool("Fly", true);
			jumpAudioSource.GetComponent<AudioSource>().PlayOneShot(jumpSound);
		}else if (!secondJump){
			rigid2D.velocity = new Vector2(rigid2D.velocity.x, 650);
			secondJump = true;
			anim.SetBool("Fly", true);
			jumpAudioSource.GetComponent<AudioSource>().PlayOneShot(jumpSound);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "BgCorners"){
			if(side == false){
				side = true;
			} else {
				side = false;
			}
		} else if(col.gameObject.tag == "Ground"){
			jump = false;
			secondJump = false;
			anim.SetBool("Fly", false);
			col.gameObject.tag = "GroundOld";
			Camera.main.GetComponent<GUI>().score += 1;
		} else if(col.gameObject.tag == "GroundOld"){
			jump = false;
			secondJump = false;
			anim.SetBool("Fly", false);
		} else if(col.gameObject.tag == "Cat"){
			PlayerPrefs.SetInt("previousScore", Camera.main.GetComponent<GUI>().score);
			GemUniAPI.Instance.CallOnLimitScore(Camera.main.GetComponent<GUI>().score);
			GemUniAPI.Instance.CallRequestSubmit();
			PlayerPrefs.Save();
			Camera.main.GetComponent<State>().state = "GameOver";
			GetComponent<Animator>().SetBool("Dead", true);
			string collidingCat = col.gameObject.GetComponent<SpriteRenderer>().sprite.name;
			if(collidingCat.StartsWith("Cat3")){
				col.gameObject.GetComponent<Cat3Move>().enabled = false;
				col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			}
			PlayerPrefs.SetInt("reklam", PlayerPrefs.GetInt("reklam") + 1);
			PlayerPrefs.Save();
		}

	}

	void OnTriggerEnter2D(Collider2D trig){
		if(trig.gameObject.tag == "Coin"){
			coinAudioSource.GetComponent<AudioSource>().PlayOneShot(coinSound);
			Camera.main.GetComponent<GUI>().coin += 1;
			PlayerPrefs.SetInt("totalCoin", PlayerPrefs.GetInt("totalCoin") + 1);
			PlayerPrefs.Save();
			Destroy(trig.gameObject);
		} else if(trig.gameObject.tag == "Diamond"){
			coinAudioSource.GetComponent<AudioSource>().PlayOneShot(coinSound);
			Camera.main.GetComponent<GUI>().coin += 2;
			PlayerPrefs.SetInt("totalCoin", PlayerPrefs.GetInt("totalCoin") + 2);
			PlayerPrefs.Save();
			Destroy(trig.gameObject);
		}
	}

}
