using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float mouseSensitivity, sprintSpeed, walkSpeed, smoothTime;
    public GameObject cameraHolder;
    public Item[] items;
    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    int itemIndex;
    int previousItemIndex = -1;

    Rigidbody rb;

    const float maxHealth = 100f;
    float currentHealth = maxHealth;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();



    }
    void Start()
    {

        

    }
    void Update()
    {
        Look();
        Move();
        if(Input.GetMouseButtonDown(0))
        {
            items[0].Use();
        }
    }
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }
    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);

        rb.angularVelocity = new Vector3(0, 0, 0); 
    }


    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;

    }
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);

    }
}
