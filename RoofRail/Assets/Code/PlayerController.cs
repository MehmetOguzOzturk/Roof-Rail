using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator anim;

    float step;
    Vector2 actionPosition;

    public bool isRun, isFight;
    public float speed, swipeSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            actionPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            isRun = true;

        }

        if (isRun)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            anim.SetTrigger("Run");
        }

        if (Input.GetMouseButton(0))
        {


            step = (Input.mousePosition.x - actionPosition.x);

            transform.position += new Vector3(step * swipeSpeed, 0, 0) * Time.deltaTime;


            actionPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x, -1.75F, 1.75F);
            transform.position = pos;

        }


    }
}
