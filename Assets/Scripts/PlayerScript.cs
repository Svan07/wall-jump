using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


    public float force = 100;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.up * 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(-Vector3.right * force);
            Debug.Log(GetComponent<Rigidbody>().velocity);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * force);
        }
    }
}
