using UnityEngine;
using System.Collections;

public class SpotlightBehaviour : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{


	}
	


	void Update () 
	{
        transform.position += new Vector3(Mathf.Sin(Time.time)/10, 0, Mathf.Cos(Time.time)/10);
	}
}
