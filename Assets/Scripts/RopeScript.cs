using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour {

    public Vector3 destination;
    public float speed = 1;
    public float distance = 2;
    public GameObject node;
    public GameObject player;
    public GameObject lastnode;
    public LineRenderer lr;
    public List<GameObject> nodes = new List<GameObject>();

    private int vertexCount = 2;
    private bool done = false;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        lastnode = transform.gameObject;

        nodes.Add(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, destination, speed);

        if (transform.position != destination)
        {
            if (Vector3.Distance(player.transform.position, lastnode.transform.position) > distance)
            {
                CreateNode();
            }
        }
        else if (done == false)
        {
            done = true;
            while (Vector3.Distance(player.transform.position, lastnode.transform.position) > distance)
            {
                CreateNode();
            }
            lastnode.GetComponent<HingeJoint>().connectedBody = player.GetComponent<Rigidbody>();
        }            

        RenderRope();
	}

    private void CreateNode()
    {
        Vector3 pos2Create = player.transform.position - lastnode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += lastnode.transform.position;

        GameObject n = (GameObject)Instantiate(node, pos2Create, Quaternion.identity);
        n.transform.SetParent(transform);
        lastnode.GetComponent<HingeJoint>().connectedBody = n.GetComponent<Rigidbody>();

        lastnode = n;
        nodes.Add(lastnode);
        vertexCount++;
    }

    private void RenderRope()
    {
        lr.positionCount = vertexCount;

        int i = 0;
        for(i = 0; i < nodes.Count; i++)
        {
            lr.SetPosition(i, nodes[i].transform.position);
        }
        lr.SetPosition(i, player.transform.position);
    }
}
