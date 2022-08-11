using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    
    PlayerController plcont;
    GameOver gameOver;
    Animator anim;
    bool isSliding = false;
    public float speed;
    public GameObject plrod;

    void Start()
    {
        
        plcont = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        gameOver = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameOver>();
    }


    private void OnTriggerEnter(Collider other)
    {      

        if (other.gameObject.CompareTag("IncrasePlayerSpeed"))
            DOTween.To(() => plcont.runspeed, x => plcont.runspeed = x, 4, 0.5f);
           

        if (other.gameObject.CompareTag("LowerPlayerSpeed"))
        {
            plcont.runspeed = 3f;
            isSliding = false;
            anim.SetBool("Hanging", false);
            plrod.transform.DOLocalMoveY(0.45f, 0.1f);
            GetComponent<Rigidbody>().drag = 0f;
        }

        if (other.gameObject.CompareTag("IncraseDrag"))
        {
            GetComponent<Rigidbody>().drag = 3f;
            anim.SetBool("Hanging", true);
            plrod.transform.DOLocalMoveY(0.75f, 0.1f);
        }
      
        if (other.gameObject.CompareTag("slide"))
        {
            plrod.transform.DOLocalMoveY(0.75f, 0.1f);
            anim.SetBool("Hanging", true);
            isSliding = true;
        }

        if (other.gameObject.CompareTag("slideChild"))
        {

            if (other.gameObject.transform.position.x > 0 && !isSliding)
            {
                transform.Translate(new Vector3(-1,0, 0)*Time.deltaTime*speed);
                isSliding = true;
            }
            if (other.gameObject.transform.position.x < 0 && !isSliding)
            {
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
                isSliding = true;
            }
        }
    }
}
