using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {

	// Use this for initialization
	
	private GameDelegate gameDelegate;
	private GameObject samurai;
	private GameObject[] instantRoadParts = new GameObject[0];
	
	Vector3 lastPoint = new Vector3(0,100,0);
	Vector3 lastAngle = new Vector3(0,100,0);
	public GameObject lastObject;
	public GameObject[] waypoints;
	private int id = 0;
	
	
	void Start () {
		print("terrain manager start");
		
		samurai = GameObject.Find ("samurai");
		samurai.transform.position = new Vector3(0, 100, 0);
		MovingPersonController movingPersonController = samurai.AddComponent("MovingPersonController") as MovingPersonController;
		InputSamurai inputSamurai = samurai.AddComponent("InputSamurai") as InputSamurai;
		movingPersonController.move = true;
		gameDelegate = gameObject.GetComponent<GameDelegate>();
		
		
		for(int i = 0;i<2;i++) {
			
			createTerrainObject();			
			
		}
		
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float distance = Vector3.Distance(samurai.transform.position,lastObject.transform.position);
//		GUIText text = console.GetComponent<GUIText>();
//		text.text = ""+distance;
		
		
		if (distance<30) createTerrainObject();
		//if (Vector3.Distance(samur
		
	
	}
	
	
	void createTerrainObject(){
		
		string[] levelParts = new string[]{"road","roadRight","roadLeft"};
		
		if (instantRoadParts.Length > 4) {
			deleteFirtsObject();
			
		}
		
		int n = Random.Range(0,levelParts.Length);
		GameObject obj =GameObject.Find(levelParts[n]);
		
		GameObject road = Instantiate(obj) as GameObject ;
		road.name = "road"+id;
		GameObject meshObject = (GameObject.Find(road.name+"/mesh")) as GameObject ;
		road.transform.position = lastPoint;
		road.transform.eulerAngles = lastAngle;
			// go.renderer.material = Resources.Load("materials/terrain") as Material;
		Mesh mesh = meshObject.GetComponent<MeshFilter>().mesh;
		//lastPoint += road.transform.position.x+mesh.bounds.size.y*road.transform.localScale.y;
		lastObject = road;
		addObject(road);
		id++;
		float x = Random.Range(0,30);
		
		GameObject waypointsParent = (GameObject.Find(road.name+"/waypoints")) as GameObject;
		GameObject[] waypoints = new GameObject[waypointsParent.transform.childCount-1];
		for(int i=0;i<waypoints.Length+1;i++)
		{
			GameObject currentPoint = GameObject.Find(road.name+"/waypoints/"+i) as GameObject;
			
			currentPoint.collider.enabled  = false;
			currentPoint.renderer.enabled = false;
			
			if (i<waypoints.Length) waypoints[i] = currentPoint ; 
			else {
					
				lastPoint = currentPoint.transform.position;
				lastAngle = currentPoint.transform.eulerAngles;
			}

				
		}
		
		samurai.BroadcastMessage("setNewWaypoints",waypoints,SendMessageOptions.RequireReceiver);	
		
		/*
		int direction =  Random.Range(0,2);
			
				switch (direction) {
				case 0: lastObject.transform.eulerAngles = new Vector3(x,0,0);break;
				case 1: lastObject.transform.eulerAngles = new Vector3(-x,0,0);break;
				default: break;
		}
		*/
		
		
		//if (obstacleControll !=null) obstacleControll.createEnemyAtPosition(lastObject.transform.position+new Vector3(0,8.55f,0));
		//print(mesh.bounds.size.x);

		
	}
	
	
	void addObject(GameObject newObject) {
		
		
		if (instantRoadParts ==null )  instantRoadParts = new GameObject[0];
		GameObject[] newRoadParts = new GameObject[instantRoadParts.Length+1];
		
			for (int i = 0;i<instantRoadParts.Length;i++) {
				newRoadParts[i] = instantRoadParts[i];
				
			}
			newRoadParts[newRoadParts.Length-1] = newObject;
			
		
			instantRoadParts = newRoadParts;
		
		
	}
	
	void deleteFirtsObject() {
		
		GameObject[] newRoadParts = new GameObject[instantRoadParts.Length-1];
		for(int i = 0;i<instantRoadParts.Length;i++) {
				
			if (i==0) {
				GameObject roadForRelease = instantRoadParts[i];
				GameObject.Destroy(roadForRelease);
					
			} else {
				newRoadParts[i-1] = instantRoadParts[i];
			}
				
		}
		instantRoadParts = newRoadParts;
		
		
	}
	
}
