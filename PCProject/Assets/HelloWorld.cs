using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {

	public int incriment;

	// Use this for initialization
	void Start () 
	{
		incriment = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("Hello world" + incriment.ToString ());
		incriment += 1;
	}
}
