using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavmeshGuard : MonoBehaviour {
	
	
	public List<Vector3> Points;	// These are just some points for interpolation
	public float distance;

	public GameObject Playerstuff;
	public  NavMeshAgent agent;


	public int currentloc;
	NavMeshHit hit;


	// Use this for initialization
	void Start () 
	{
		Points = new List<Vector3> ();
		
		//Specify the points you want the object to go betweeen
		Points.Add (new Vector3 (9, 0,9)); 
		Points.Add (new Vector3 (9, 0,-9));
		Points.Add (new Vector3 (-9, 0,-9));
		Points.Add (new Vector3 (-9, 0,9));


		currentloc = 0;

		agent = this.GetComponent<NavMeshAgent> ();
		Playerstuff = GameObject.Find ("Player");


		gameObject.renderer.material.color = Color.red;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (agent.Raycast (Playerstuff.transform.position, out hit)) 
		{
			{
						if (currentloc == 4)
								currentloc = 0;

						distance = Vector3.Distance (this.transform.position, Points [currentloc]);
		

						agent.destination = Points [currentloc];

						if (distance < 10)
								currentloc++;

			}
		}
		else if(!agent.Raycast (Playerstuff.transform.position, out hit)) 
				agent.destination = Playerstuff.transform.position;
	}
}