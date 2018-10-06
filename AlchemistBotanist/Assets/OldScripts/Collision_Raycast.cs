using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Raycast : MonoBehaviour {

    // Use this for initialization
    RaycastHit hit;
    RaycastHit oldHit;
    Ray ray;
    public GameObject selectionSprite;

    
	void Start () {
        ray = new Ray(transform.position, new Vector3(0, -1, 0));
	}
	
	// Update is called once per frame
	void Update () {
        ray.origin = transform.position;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.isTrigger)
            {
                Debug.Log("Raycast Hit.");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);

                

                if (Input.GetButton("Activate"))
                {
                    hit.collider.gameObject.SendMessageUpwards("ActivateActor");
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.white);
            }

            if (hit.collider.Equals(oldHit.collider))
            {
                oldHit = hit;
            }
            else
            {
                Debug.Log("New Hit!");
                ColorizeSelected(hit);
                oldHit = hit;
            }
        }  
	}

    void ColorizeSelected(RaycastHit selection)
    {
        DestroySelection();
        if (selection.collider.isTrigger)
        {
            GameObject newSelection = Instantiate(selectionSprite, new Vector3(selection.transform.position.x, selection.transform.position.y + 0.6F, selection.transform.position.z), Quaternion.Euler(90,0,0));
            newSelection.name = "Selection";
        }
        
    }

    void DestroySelection()
    {
        
            GameObject toDestroy = GameObject.Find("Selection");
            Destroy(toDestroy);
        
        
    }
}
