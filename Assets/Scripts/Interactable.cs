using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected Interact source;
    public Material interactableMaterial;
    public GameObject ui;

    private Rigidbody rb;
    private bool isHeald = false;
    private Transform holder;
    public Collider interactionCollider;
    Transform parentTransform;

    public virtual void Awake()
    {
        source = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Interact>();
        rb = GetComponent<Rigidbody>();
        parentTransform = transform.parent;
    }

    private void Update()
    {
        if (source == null)
        {
            source = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Interact>();
        }
        interactableMaterial.SetFloat("glow_strength", 0f);
        if(holder != null)
        {
            parentTransform.position = holder.position;
        }
        
    }
  
    public virtual Interactable OnPickupInteraction(FirstPersonInteracter source)
    {
        rb.useGravity = false;
        rb.freezeRotation = true;
        isHeald = true;
        holder = source.GetHolder();
        interactionCollider.isTrigger = true;
        return this;
    }

    public virtual bool DropInteraction(Interact source)
    {
        rb.useGravity = true;
        rb.freezeRotation = false;
        isHeald = false;
        holder = null;
        interactionCollider.isTrigger = false;
        return true;
    }

    public virtual bool OnInteractStart(Interact source, ScriptableObject item)
    {
        return false;
    }
    public virtual bool OnInteractEnd(Interact source)
    {
        return false;
    }
    public virtual bool OnInteract(Interact source, ScriptableObject item)
    {
        return false;
    }

    public virtual GameObject ShowPreview(Interact source, GameObject previewObject)
    {
        return null;
    }

    public virtual void OnHover()
    {
        interactableMaterial.SetFloat("glow_strength", 6f);
    }

    /*private void OnMouseOver()
    {
        Debug.Log("FOOer");
        if (Vector3.Distance(transform.position, source.transform.position) <= source.interactRange)
        {
            if (rendererd != null)
            {

                float emission = Mathf.PingPong(Time.time, 1.0f);
                Color baseColor = rendererd.material.color;

                Color finalColor = Color.white * Mathf.LinearToGammaSpace(.10f);
                rendererd.material.EnableKeyword("_EMISSION");
                rendererd.material.SetColor("_EmissionColor", finalColor);
                if (ui != null)
                {
                    ui.SetActive(true);
                }

            }
        }
        else
        {
            if (rendererd != null)
            {
                rendererd.material.DisableKeyword("_EMISSION");
                if (ui != null)
                {
                    ui.SetActive(false);
                }
            }
        }

    }

    private void OnMouseExit()
    {
        TurnOffGlow();
    }

    public void TurnOffGlow()
    {
        if (rendererd != null)
        {
            rendererd.material.DisableKeyword("_EMISSION");
            if (ui != null)
            {
                ui.SetActive(false);
            }
        }
    }*/


}


