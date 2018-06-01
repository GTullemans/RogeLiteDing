using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour {
    private Vector3 _MousePos;
    private bool _Kliked;
    private Collider _CardCollider;
    // Use this for initialization
    void Start () {
        _Kliked = false;
        _CardCollider = gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        
        _MousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);


        DragAndDrop(_MousePos);
        





    }



    private void DragAndDrop(Vector3 mousepos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider == _CardCollider)
                {



                    _Kliked = true;

                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _Kliked = false;
        }

        if (_Kliked)
        {
            transform.position = Vector3.Lerp(transform.position, _MousePos, 0.98f);
        }
    }

    private void ClickToPick(Vector3 mousepos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider == _CardCollider)
                {


                    if (_Kliked)
                    {
                        _Kliked = false;
                    }
                    else
                    {
                        _Kliked = true;
                    }
                }
            }
        }

        if (_Kliked)
        {
            transform.position = Vector3.Lerp(transform.position, _MousePos, 0.98f);
        }
    }
}
