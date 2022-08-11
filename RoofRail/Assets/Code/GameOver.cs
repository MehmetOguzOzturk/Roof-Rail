using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    PlayerController plcont;
    Collectstick clst;
    PlayerManager playermng;
    GameObject rod;
    public Animator playerAnim;
    bool gameOverCheck;
    float forcePower=40;
    void Start()
    {
        plcont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        clst = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectstick>();
        playermng = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        rod = GameObject.FindGameObjectWithTag("rod");
    }

    public void Gameover()
    {
        if (gameOverCheck)
        {
            return;
        }
        gameOverCheck = true;

        plcont.enabled = false;
        clst.enabled = false;
        playermng.speed = 0;
        playermng.enabled = false;

        rod.transform.parent = null;
        rod.AddComponent<Rigidbody>();
        rod.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 1) * forcePower, ForceMode.Impulse);
        playerAnim.SetTrigger("Fall");


    }
    public void Die()
    {
        playerAnim.SetTrigger("Die");
        rod.transform.parent = null;
        rod.AddComponent<Rigidbody>();

        plcont.enabled = false;
        clst.enabled = false;
        playermng.speed = 0;
        playermng.enabled = false;
    }
}
