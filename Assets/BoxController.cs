using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    Transform parentTransform;
    public ParticleSystem particle;
    public MeshRenderer boxRenderer;
    public Rigidbody rb; 
    float TimeToDie = 6f;
    FirstPersonInteracter interacter;
    public Canvas canvas;
    public Collider boxCollider;
    public float conveyorSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        interacter = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<FirstPersonInteracter>();
        parentTransform = transform.parent;
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if(boxCollider == null)
        {
            boxCollider = GetComponent<Collider>();
        }
        //boxRenderer = GetComponent<MeshRenderer>();
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Conveyor")
        {
            parentTransform.position += parentTransform.forward * conveyorSpeed * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Table")
        {
            interacter.Drop(this.gameObject);
            particle.transform.rotation = Quaternion.Euler(new Vector3(-90f,0f,0f));  
            particle.Play();
            boxRenderer.enabled = false;
            canvas.enabled = false;
            rb.useGravity = false;
            rb.isKinematic = true;
            boxCollider.enabled = false;
            StartCoroutine(KillSelf());
        }
    }

    private void Update()
    {
        /*if (transform.position.y != parentTransform.position.y)
        {
            parentTransform.position = new Vector3(parentTransform.position.x, transform.position.y, parentTransform.position.z);
            transform.position = new Vector3(transform.position.x, parentTransform.position.y, transform.position.z);
        }*/
        parentTransform.position = transform.position;
        transform.position = parentTransform.position;
    }

    IEnumerator KillSelf()
    {
        float timeElapsed = 0f;
        while (timeElapsed < TimeToDie)
        {
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        Destroy(parentTransform.gameObject);

    }
}
