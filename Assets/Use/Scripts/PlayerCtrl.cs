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
    public GameObject gun;

    int itemIndex;
    int previousItemIndex = -1;

    const float maxHealth = 100f;
    float currentHealth = maxHealth;

    
    public ParticleSystem particleObject; 

    Rigidbody rb;

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
        kill();
    }
    

    private void OnTriggerEnter(Collider coll)
    {
        if(currentHealth>=0.0f&&coll.CompareTag("Monster"))
        {
            currentHealth -= 10.0f;
            Debug.Log($"Player hp = {currentHealth / maxHealth}");
            if(currentHealth<=0.0f)
            {
                PlayerDie();
            }
        }
    }
    void PlayerDie()
    {
        //UI로 당신은 미션에 실패하셨습니다. 다시 시작하겠습니까?
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
    void kill()
    {
        if (gun.gameObject.activeSelf == true)
        {
            if (Input.GetMouseButton(0))
            {
                items[0].Use();
                particleObject.Play();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                particleObject.Stop();
            }
            else { }
        }
    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);

    }
}
