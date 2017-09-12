using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    public GameObject obj;

    private GameObject currObj;
    private bool ropeActive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if(ropeActive == false)
            {
                Vector3 destination;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    destination = hit.point;
                    currObj = (GameObject)Instantiate(obj, transform.position, Quaternion.identity);
                    currObj.GetComponent<RopeScript>().destination = destination;

                    ropeActive = true;
                }
            }
            else
            {
                Destroy(currObj);
                ropeActive = false;
            }     
        }
	}
}
