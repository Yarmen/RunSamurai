using UnityEngine;
using System.Collections;

public class MovingPersonController : MonoBehaviour {

	// Use this for initialization
	public int moveSpeed = 5;
	public Vector3 nextPosition;
	public Vector3 nextRotation;
	
	private float timeCurrent = 1 ;
	private float timeDelta = 0;
	private Vector3 currentPosition;
	private Vector3 currentRotation;
	private GameObject[] waypoints;
	
	private Vector3 waypointPos0;
	private Vector3 waypointPos1;
	private Vector3 waypointPos2;
	private Vector3 waypointPos3;
	
	private Vector3 waypointRot0;
	private Vector3 waypointRot1;
	private Vector3 waypointRot2;
	private Vector3 waypointRot3;
	
	public bool move = false;
	
	//GameObject testObject;
	
	
	
	void Start () {
		
		//testObject = GameObject.CreatePrimitive(PrimitiveType.Cube) as  GameObject ;
		//testObject.collider.enabled = false;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (move) moveForward();
	
	}
	
	
	
	void moveForward () {
	
		
		if (timeCurrent>=1)
		{
				
			timeCurrent-=1;

			GameObject[] newWaypoints = new GameObject[waypoints.Length-1];
			for (int i = 0;i<newWaypoints.Length;i++) {
				newWaypoints[i] = waypoints[i+1];
				
			}
			waypoints = newWaypoints;
			
			waypointPos0 = waypoints[0].transform.position;
			waypointPos1 = waypoints[1].transform.position;
			waypointPos2 = waypoints[2].transform.position;
			waypointPos3 = waypoints[3].transform.position;
			
			waypointRot0 = waypoints[0].transform.eulerAngles;
			waypointRot1 = waypoints[1].transform.eulerAngles;
			waypointRot2 = waypoints[2].transform.eulerAngles;
			waypointRot3 = waypoints[3].transform.eulerAngles;
	
		}
		
		timeDelta=0.1f*moveSpeed/Vector3.Distance(waypointPos1,waypointPos2);
		timeCurrent+=timeDelta;
		//print(timeCurrent);
		
			
		currentPosition =(  	(2 * waypointPos1) +
		
		 (-waypointPos0 + waypointPos2) * timeCurrent +
		 
		(2*waypointPos0 - 5*waypointPos1 + 4*waypointPos2 - waypointPos3) * timeCurrent*timeCurrent +
		  
		(-waypointPos0 + 3*waypointPos1 - 3*waypointPos2 + waypointPos3) * timeCurrent*timeCurrent*timeCurrent);
		
		currentPosition/= 2;

		nextPosition = new Vector3(currentPosition.x,currentPosition.y,currentPosition.z);
		
		currentRotation =(  	(2 * waypointRot1) +
		
		 (-waypointRot0 + waypointRot2) * timeCurrent +
		 
		(2*waypointRot0 - 5*waypointRot1 + 4*waypointRot2 - waypointRot3) * timeCurrent*timeCurrent +
		  
		(-waypointRot0 + 3*waypointRot1 - 3*waypointRot2 + waypointRot3) * timeCurrent*timeCurrent*timeCurrent);
		
		currentRotation/= 2;
		
		nextRotation = currentRotation;
		
		//testObject.transform.position = nextPosition;
	}
	
	
	void setNewWaypoints(GameObject[] arivedWaypoints) {
		
		//print("new waypoints arrived");
		
		if (waypoints ==null )  waypoints = new GameObject[0];
		GameObject[] newWaypoints = new GameObject[waypoints.Length+arivedWaypoints.Length];
		
			for (int i = 0;i<waypoints.Length;i++) {
				newWaypoints[i] = waypoints[i];
				
			}
			
			int lastindex =  waypoints.Length;
			for (int i = 0;i<arivedWaypoints.Length;i++) {
				newWaypoints[lastindex+i] = arivedWaypoints[i];
				
			}
		
			waypoints = newWaypoints;
		//	print(waypoints.Length);
		
	}
	
}
