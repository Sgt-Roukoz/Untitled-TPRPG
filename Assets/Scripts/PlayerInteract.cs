using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject rayObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForHit();
    }

    void CheckForHit()
    {
        Vector3 fwd = rayObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(rayObject.transform.position, fwd * 50, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(rayObject.transform.position, fwd, out hit, 50))
            {
                if(hit.collider.gameObject.name == "Item")
                {
                    Debug.Log("Item Hit!");
                }
            }
        }
    }
}
