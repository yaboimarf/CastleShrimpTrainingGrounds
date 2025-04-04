using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerBehavior: MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed;
    public Vector3 bodyRotate;
    public Vector3 camRotate;
    public float rotateSpeed;
    public Transform cam;
    public float extraSpeed;
    
    public float groundedDistance;
    public RaycastHit groundedHit;

    public float interactionDistance;
    public RaycastHit interactionHit;
    
    public Rigidbody rb;
    public float jumpHeight;
    //public BubbleBehavior bubbleBehavior;

    public float hp;
    public int playerStrenght;
    public void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        BodyMovement();
        Jump();
        CamMovement();
        //DistantTrigger();
        //Shoot();         
    }
    public void BodyMovement()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Physics.Raycast(transform.position, -transform.up, out groundedHit, groundedDistance))
            {
                rb.velocity = (Vector3.up * jumpHeight);
            }
        }
    }
    public void CamMovement()
    {
        bodyRotate.y = Input.GetAxis("Mouse X");
        camRotate.x = -Input.GetAxis("Mouse Y");
        transform.Rotate(bodyRotate * Time.deltaTime * rotateSpeed);
        cam.Rotate(camRotate * Time.deltaTime * rotateSpeed);
        
    }
    //public void DistantTrigger()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (Physics.Raycast(cam.position, cam.forward, out interactionHit, interactionDistance))
    //        {
    //            if (interactionHit.collider.GetComponent<BubbleBehavior>())
    //            {
    //                interactionHit.collider.gameObject.GetComponent<BubbleBehavior>().EnemyHp(playerStrenght);
    //            }
    //        }
    //    }
    //}
    public void DamageToDo(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}