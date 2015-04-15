using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {

	public List<Node> nodes;
	float Range;



	public struct Node
	{
		public Vector3 position;
		public List<Edge> Edges;
		public bool visited;

		public Node(Vector3 pos)
		{
			position = pos;
			Edges = new List<Edge>();
			visited = false;
		}

	
	}

	public struct Edge
	{
		public Node node;
		float cost;

		public Edge(Node point, float range)
		{
			node = point;
			cost = range;
		}

	
	}

	// Use this for initialization
	void Start () 
	{
		Range = 0;
		nodes = new List<Node> ();
		CreateGrid (7,7);
		FindNeighbours();

	}
	
	// Update is called once per frame
	void Update () 
	{
		DrawDebugLines ();
	}

	void CreateGrid(int rows, int collumns)
	{
		for (int i = 0; i < rows; i++) 
		{
			for(int j = 0; j < collumns; j++)
			{
		
				Node n = new Node(new Vector3(-9 + i * 3, 0 , - 9 + j * 3));
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.renderer.material.color = Color.green;
				cube.transform.position = n.position;
				nodes.Add(n);
			}
		}
	}

	public void FindNeighbours()
	{
		for (int i = 0; i < nodes.Count; i++) 
		{
			for(int j = 0; j < nodes.Count; j++)
			{
				if(i == j)
					continue;

				Range = (nodes[i].position - nodes[j].position).magnitude;

				if(Range < 5)
				{
					nodes[i].Edges.Add(new Edge(nodes[j], Range));
				}


			}
		}
	}

	public void DrawDebugLines()
	{
		for (int i = 0; i < nodes.Count; i++) 
		{
			for (int j = 0; j < nodes[i].Edges.Count; j++) 
			{
				Debug.DrawLine(nodes[i].position, nodes[i].Edges[j].node.position, Color.blue);
			}
		}
	}

	//public void AstarpathFind(Node start, Node end)
	//{
	//	 List<Node> closedSet = new List<Node>(); // the setof nodes already evaluated
	//	 List<Node> openSet = new List<Node>(); // The set of tentative nodes to be evaluated, initially cointaing the start node
	//
	//}

	//public void BFS(Node start, Node end)
	//{
	//	if (start == end)
	//		return;
	//
	//	else 
	//	{
	//		for(int i = 0; i < start.Edges.Count; i++)
	//		{
	//
	//		}
	//	}
	//}


	//Recursive loop
	//public List<Node> Childrenof(Node parent, List<Edge> result)
	//{
	//
	//		foreach (Node child in parent.Edges)
	//		{
	//				result.Add(child);
	//				Childrenof(child, result);
	//		}
	//
	//	return result;
	//}

}
