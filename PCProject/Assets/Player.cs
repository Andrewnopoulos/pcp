using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.green;
		agent = GetComponent<NavMeshAgent> ();
		agent.speed = 10;

	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast(ray, out hit))
				agent.SetDestination(hit.point);

		
		}
	}
}
