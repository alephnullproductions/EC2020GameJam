using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;

public class FirstPersonInteracter : Interact
{
    public float rayRange = 1f;
    public Transform holdPosition;
    public Interactable objectHeald; 


    private SimpleControls m_Controls;
    

    private Camera mainCam;
    private RaycastHit hit;

    public void Awake()
    {
        m_Controls = new SimpleControls();

        m_Controls.gameplay.fire.performed +=
         ctx =>
         {
          Debug.Log("BaR");
          if (ctx.interaction is SlowTapInteraction)
          {

          }
          else
          {

          }
          Fire();
          
      };
        mainCam = Camera.main;
        /*m_Controls.gameplay.fire.started +=
            ctx =>
            {
                if (ctx.interaction is SlowTapInteraction)
                    m_Charging = true;
            };
        m_Controls.gameplay.fire.canceled +=
            ctx =>
            {
                m_Charging = false;
            };*/
    }

    public void OnEnable()
    {
        m_Controls.Enable();
    }

    public void OnDisable()
    {
        m_Controls.Disable();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Ray camRay = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(camRay, out hit, rayRange))
        {
            Interactable target = hit.transform.GetComponent<Interactable>();
            if(target != null)
            {
                target.OnHover();
            }
        }
    }

    void Fire()
    {
        if(objectHeald == null)
        {
            Debug.Log("LS");
            if (hit.transform != null)
            {
                Interactable target = hit.transform.GetComponent<Interactable>();
                if (target != null)
                {
                    objectHeald = target.OnPickupInteraction(this);
                }
            }
            
        }
        else
        {
            Drop();
        }
        
    }

    public void Drop()
    {
        objectHeald.DropInteraction(this);
        objectHeald = null;
    }

    public void Drop(GameObject objectToTest)
    {
        if(objectHeald != null && objectToTest == objectHeald.transform.gameObject)
        {
            Drop();
        }
    }

    public Transform GetHolder()
    {
        return holdPosition;
    }
}
