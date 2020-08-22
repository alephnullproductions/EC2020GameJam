using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    private SimpleControls m_Controls;
    Camera playerCamera;
    float xRotation = 0f;
    float cameraYRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if(playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    public void Awake()
    {
        m_Controls = new SimpleControls();
  
    }

    public void OnEnable()
    {
        m_Controls.Enable();
    }

    public void OnDisable()
    {
        m_Controls.Disable();
    }

    public void Update()
    {
        var look = m_Controls.gameplay.look.ReadValue<Vector2>();
        var move = m_Controls.gameplay.move.ReadValue<Vector2>();

        // Update orientation first, then move. Otherwise move orientation will lag
        // behind by one frame.
        Look(look);
        Move(move);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;

        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        

        transform.position += transform.forward * scaledMoveSpeed * direction.y;
    }

    private void Look(Vector2 rotate)
    {
        
        if (rotate.sqrMagnitude < 0.01)
            return;

        rotate = rotate * Time.deltaTime;
        xRotation += rotate.x;
        cameraYRotation = Mathf.Clamp(cameraYRotation - rotate.y * rotateSpeed, -90f,90f);
        transform.localRotation = Quaternion.Euler(0f, xRotation * rotateSpeed, 0f);
        playerCamera.transform.localRotation= Quaternion.Euler(cameraYRotation, 0f, 0f);
        //(new Vector3(1f,0f,0f) * cameraYRotation);
    }

    
}
