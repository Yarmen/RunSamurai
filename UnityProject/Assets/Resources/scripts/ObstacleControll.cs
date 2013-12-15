using UnityEngine;
using System.Collections;

public class ObstacleControll : MonoBehaviour {

	// Use this for initialization
	int nextTimeEnemy = 0;
	int enemyCreationSpeed = 5;
	GameObject samurai;
	GameObject[] enemys;
	GameDelegate gameDelegate;
	
	void Start () {
		
		samurai = GameObject.Find("samurai");
		gameDelegate = Camera.main.GetComponent<GameDelegate>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//print(Time.time);
		if (nextTimeEnemy<Time.time) {
		//	createEnemy();
			nextTimeEnemy+=enemyCreationSpeed;
		}
	
	}
	
	void createEnemy() {
		
		print("create enemy");
		float xOffset = -20;
		switch (Random.Range(0,3) ) {
				case 0: xOffset = 4;break;
				case 1: xOffset = 0;break;
				case 2: xOffset = -4;break;
				default: break;
				
				}
			
		
		
		Vector3 position = samurai.transform.position+new Vector3(0,10,100);
		position.x = gameDelegate.terrainManager.lastObject.transform.position.x+xOffset;
		
		GameObject enemy = Instantiate(GameObject.Find("enemy")) as GameObject ;
		enemy.transform.position = position;
		
	}
	
	
	public void createEnemyAtPosition(Vector3 position) {
		
		GameObject enemy = Instantiate(GameObject.Find("enemy")) as GameObject ;
		enemy.transform.position = position;
		
		
	}
}
