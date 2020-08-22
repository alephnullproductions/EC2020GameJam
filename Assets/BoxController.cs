using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    Transform parentTransform;
    public ParticleSystem particle;
    MeshRenderer boxRenderer;
    float TimeToDie = 6f;
    FirstPersonInteracter interacter;
    public Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        interacter = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<FirstPersonInteracter>();
        parentTransform = transform.parent;
        boxRenderer = GetComponent<MeshRenderer>();
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Conveyor")
        {
            parentTransform.position += parentTransform.forward * 1 * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Table")
        {
            interacter.Drop(this.gameObject);
            particle.Play();
            boxRenderer.enabled = false;
            canvas.enabled = false;
            StartCoroutine(KillSelf());
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

    IEnumerator KillSelf()
    {
        float timeElapsed = 0f;
        Debug.Log("Start Time To Die");
        while (timeElapsed < TimeToDie)
        {
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        Debug.Log("Destroy " + parentTransform.name);
        Destroy(parentTransform.gameObject);

    }
}
