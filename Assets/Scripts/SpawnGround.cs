using UnityEngine;
using System.Collections;

public class SpawnGround : MonoBehaviour {
	public GameObject ground;
	public GameObject coin, diamond;
	public GameObject[] cats;
	public GameObject cat3Spawner;
	GameObject spawnedGround;
	int maxGround;
	float yPos;
	int groundCount;
	
	void Start () {
		maxGround = 5;
		yPos = -50f;
		groundCount = 1;
	}

	void Update () {
		GameObject[] groundOnScene = GameObject.FindGameObjectsWithTag("Ground");

		if(groundOnScene.Length < maxGround){
			yPos += 250;
			groundCount++;
			spawnedGround = Instantiate(ground, new Vector3(0f, yPos, 1f), Quaternion.identity) as GameObject;
			spawnedGround.name = groundCount.ToString();
			spawnCoin();
			spawnCats();
		}

		showPreviousScore();
	}

	void spawnCoin(){
		if(Camera.main.GetComponent<GUI>().score >= 20){
			int randomForCoin = Random.Range(0, 2);
			if(randomForCoin == 1){
				Instantiate(diamond, new Vector2(Random.Range(-200f, 200f), spawnedGround.transform.position.y + Random.Range(60f, 130f)), Quaternion.identity);
			}
		} else {
			int randomForCoin = Random.Range(0, 2);
			if(randomForCoin == 1){
				Instantiate(coin, new Vector2(Random.Range(-200f, 200f), spawnedGround.transform.position.y + Random.Range(60f, 130f)), Quaternion.identity);
			}
		}
	}

	void spawnCats(){
		int randomForSpawn = Random.Range(0, 2);
		if(randomForSpawn == 1){
			int randomForCat = Random.Range(0, cats.Length);
			switch(randomForCat){
			case 0:
				Instantiate(cats[0], new Vector2(Random.Range(-170f, 170f), spawnedGround.transform.position.y + 27f), Quaternion.identity);
				break;
			case 1:
				Instantiate(cats[1], new Vector2(Random.Range(-100f, 100f), spawnedGround.transform.position.y + 50f), Quaternion.identity);
				break;
			case 2:
				int randomForSide = Random.Range(0, 2);
				if(randomForSide == 1){
					GameObject spawnCat3 = Instantiate(cat3Spawner, new Vector2(-400f, spawnedGround.transform.position.y + 50f), Quaternion.identity) as GameObject;
					spawnCat3.transform.localScale = new Vector2(-1, 1);
					spawnCat3.GetComponent<Cat3Move>().side = "Right";
				} else {
					GameObject spawnCat3 = Instantiate(cat3Spawner, new Vector2(400f, spawnedGround.transform.position.y + 50f), Quaternion.identity) as GameObject;
					spawnCat3.GetComponent<Cat3Move>().side = "Left";
					spawnCat3.transform.localScale = new Vector2(1, 1);
				}
				break;
			}
		} else {

		}
	}

	void showPreviousScore(){
		if(PlayerPrefs.GetInt("previousScore") > 1 && Camera.main.GetComponent<State>().state == "Game"){
			if(groundCount >= PlayerPrefs.GetInt("previousScore")){
				GameObject previousScoreImage = GameObject.Find(PlayerPrefs.GetInt("previousScore").ToString());
				SpriteRenderer[] image = previousScoreImage.GetComponentsInChildren<SpriteRenderer>();
				image[1].enabled = true;
			}
		}
	}

}
