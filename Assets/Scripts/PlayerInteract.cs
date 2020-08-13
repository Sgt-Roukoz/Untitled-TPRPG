using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject rayObject; // Making indicator for game object to be used as ray source

    // Update is called once per frame
    void Update()
    {
        CheckForHit();
    }

    void CheckForHit()
    {
        Vector3 fwd = rayObject.transform.TransformDirection(Vector3.forward); // find "forward" direction of ray object
        Debug.DrawRay(rayObject.transform.position, fwd * 50, Color.green); // draw green line indicating ray
        if (Input.GetKeyDown("e")) // Shoot ray when player clicks left click
        {
            RaycastHit hit;

            if(Physics.Raycast(rayObject.transform.position, fwd, out hit, 50)) // if ray hit a solid object
            {
                /*if(hit.collider.gameObject.name == "Item") // print if object hit by ray has name "Item"
                {
                    Debug.Log("Item Hit!");
                }*/
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    interactable.interactRange();

                }
            }
        }
    }
}
