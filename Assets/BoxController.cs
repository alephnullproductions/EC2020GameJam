using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = transform.parent;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Conveyor")
        {
            parentTransform.position += parentTransform.forward * 1 * Time.deltaTime;   
        }
    }

    private void Update()
    {
        if (transform.position.y != parentTransform.position.y)
        {
            parentTransform.position = new Vector3(parentTransform.position.x, transform.position.y, parentTransform.position.z);
            transform.position = new Vector3(transform.position.x, parentTransform.position.y, transform.position.z);
        }
    }
}
