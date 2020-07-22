using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraFocus : MonoBehaviour
{
    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRot = transform.localEulerAngles;
        newRot = cam.transform.eulerAngles;
        this.transform.eulerAngles = newRot;
    }

    
}
