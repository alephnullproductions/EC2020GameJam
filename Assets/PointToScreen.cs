using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToScreen : MonoBehaviour
{

    public Camera cameraToLookAt;
    public Transform target;
    public Vector3 adjustOffTarget;

    void Start()
    {
        if(cameraToLookAt == null)
        {
            cameraToLookAt = Camera.main;
        }
        //transform.Rotate( 180,0,0 );
    }

    void Update()
    {
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
        transform.position = target.transform.position + adjustOffTarget;
    }
}
