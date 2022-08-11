using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectstick : MonoBehaviour
{
    public GameObject playerstick;
    public bool onlava;
    Saw saw;

    private void Start()
    {
        saw = GameObject.FindGameObjectWithTag("saw").GetComponent<Saw>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collect"))
        {
            playerstick.transform.localScale = new Vector3(playerstick.transform.localScale.x , playerstick.transform.localScale.y+0.1f, playerstick.transform.localScale.z);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("lava"))
        {
            onlava = true;
            StartCoroutine(DecreasePlayerStick());
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("lava"))
        {
            onlava = false;
            StopCoroutine(DecreasePlayerStick());
            
        }
    }

    private IEnumerator DecreasePlayerStick()
    {

        while (onlava && playerstick.transform.localScale.y > 0.1f)
        {
            float hangover = 0.05f;
            playerstick.transform.localScale = new Vector3(playerstick.transform.localScale.x , playerstick.transform.localScale.y - hangover, playerstick.transform.localScale.z);
            saw.SpawnDropcylinderOnLeft(hangover);
            saw.SpawnDropcylinderOnRight(hangover);
            saw.cylinderobjectleft.GetComponent<CapsuleCollider>().isTrigger = true;
            saw.cylinderobjectright.GetComponent<CapsuleCollider>().isTrigger = true;
            Destroy(saw.cylinderobjectleft, 1f);
            Destroy(saw.cylinderobjectright, 1f);
            yield return new WaitForSeconds(0.15f);
        }

    }


}
