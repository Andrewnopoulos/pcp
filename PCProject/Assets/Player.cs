using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private NavMeshAgent agent;
	public float Posy;


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
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);


		if (Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast(ray, out hit))
			{
			

				agent.SetDestination(hit.point);
				Debug.DrawLine(ray.origin, hit.point);
			}
				
		}
	}
}
