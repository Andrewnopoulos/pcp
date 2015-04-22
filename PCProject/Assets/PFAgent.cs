using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PFAgent : MonoBehaviour {

	//This is just a pathfollow Object to see if i can get this object to interperlolate between points

	public List<Vector3> Points;	// These are just some points for interpolation
	public float Length;			//Distance Length Dont worry about it
	public Vector3 Direction; 		//Direction the agent will go
	public float Deltatime;			//Just using for deltaTime;

	public float dot;
	public Vector3 PlayerDir;
	public GameObject Playerstuff;

	public bool follow;

	// Use this for initialization
	void Start () 
	{

		gameObject.renderer.material.color = Color.red;
		Points = new List<Vector3> ();
	
		//Specify the points you want the object to go betweeen
		Points.Add (new Vector3 (9, 0,9)); 
		Points.Add (new Vector3 (9, 0,-9));
		Points.Add (new Vector3 (-9, 0,-9));
		Points.Add (new Vector3 (-9, 0,9));

		Playerstuff = GameObject.Find ("Player");

	


	}
	
	// Update is called once per frame
	void Update () 
	{
		Playerstuff.GetComponent ("Player");
		
		Deltatime = Time.deltaTime;
		//Direction = (Points[0] - transform.position);
		Length = (transform.position - Points[0]).magnitude;

		PlayerDir = Vector3.Normalize(Playerstuff.transform.position - transform.position);
		RaycastHit hit;
	
		if (!Physics.Raycast (transform.position, Direction, out hit, 10)) {
			Direction = (Points[0] - transform.position);
			Debug.DrawLine(transform.position, Playerstuff.transform.position, new Color(125, 125, 125));
			Collider h = hit.collider;
			Collider p = Playerstuff.collider;
			if (h == p)
			{
				Debug.DrawLine(transform.position, Playerstuff.transform.position, new Color(125, 125, 125));
			}
		}

		PlayerDir.Normalize ();
		Direction.Normalize ();
		
		dot = Vector3.Dot (Direction, PlayerDir);

		if (dot > 0.70)
		{
			//i see the target!
			Direction = PlayerDir;

		}//else 
	//		Direction = (Points[0] - transform.position);

		if (Length < 1 && Points.Count != 1) 
		{
			Points.Add(Points[0]);
			Points.RemoveAt(0);
		}
				
	

		transform.position += Direction * Deltatime * 5;

	}
}
