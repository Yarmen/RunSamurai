using UnityEngine;
using System.Collections;



public class GameDelegate : MonoBehaviour {
	
	
	public GameObject console;
	
	public ObstacleControll obstacleControll;
	public TerrainManager terrainManager;
	
	
	// Use this for initialization
	void Start () {
		
		console = GameObject.Find("console");
			
		terrainManager = gameObject.AddComponent("TerrainManager") as TerrainManager;
		obstacleControll = gameObject.AddComponent("ObstacleControll") as ObstacleControll;
		
		// GameObject person =Instantiate (Resources.Load("objects/soccerMan")) as GameObject;
		//SkinnedMeshRenderer render = person.GetComponentInChildren<SkinnedMeshRenderer>();
		//person.transform.position = new Vector3(0, render.bounds.extents.y*10, 0);
		
		
	}
	
	
	
	
}
