using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour {
    private Vector3 MousePos;
    private bool Kliked;
    private Collider CardCollider;
    // Use this for initialization
    void Start () {
        Kliked = false;
        CardCollider = gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () { 

        MousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            { 
                
                if (hit.collider == CardCollider)
                {


                    if (Kliked)
                    {
                        Kliked = false;
                    }
                    else
                    {
                        Kliked = true;
                    }
                }
            }
        }

        if (Kliked)
        {
            transform.position = Vector3.Lerp(transform.position, MousePos, 0.98f);
        }

        
	}
}
