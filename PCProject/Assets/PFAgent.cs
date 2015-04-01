using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PFAgent : MonoBehaviour {

	//This is just a pathfollow Object to see if i can get this object to interperlolate between points

	public List<Vector3> Points;	// These are just some points for interpolation
	public float Length;			//Distance Length Dont worry about it
	public float Direction; 		//Direction the agent will go

	// Use this for initialization
	void Start () 
	{

		Points = new List<Vector3> ();
		Points.Add (new Vector3 (10, 0,0));
		Points.Add (new Vector3 (20, 0,10));
		Points.Add (new Vector3 (30, 0,50));
		Points.Add (new Vector3 (40, 0,80));
	}
	
	// Update is called once per frame
	void Update () 
	{
		Direction = (transform.position - Points [0]).magnitude;
		Length = (transform.position - Points [0]);

		Direction.Normalize ();

		if (Length < 10 && Points.count != 0) 
		{
			Points.RemoveAt(0);
		}

		transform.Translate (Direction);

	}
}
