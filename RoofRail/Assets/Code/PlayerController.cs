using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    Vector3 direction;
    bool movebytouch;
    bool startTouch;
    public float runspeed, velocity, swipespeed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            movebytouch = true;
            startTouch = true;
            anim.SetTrigger("Run");
        }
        if (startTouch)
        {
            
            if (Input.GetMouseButtonUp(0))
            {
                movebytouch = false;
            }
            if (movebytouch)
            {
                direction = new Vector3(Mathf.Lerp(direction.x, Input.GetAxis("Mouse X"), runspeed * Time.deltaTime), 0f, 0f);
                direction = Vector3.ClampMagnitude(direction, 1f);
            }

            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, runspeed);
        }

    }

    private void FixedUpdate()
    {
        if (movebytouch)
        {

            rb.velocity = new Vector3(direction.x * Time.fixedDeltaTime * swipespeed * 10, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            Vector3 desiredVelocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            rb.velocity = desiredVelocity;
        }
    }
}
