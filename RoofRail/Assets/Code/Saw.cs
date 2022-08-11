using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Saw : MonoBehaviour
{
    GameObject right;
    GameObject left;
    GameObject playerrod;
    GameObject player;
    GameOver gameOver;
    public GameObject cylinderobjectleft;
    public GameObject cylinderobjectright;
    public Material rodmater;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerrod = GameObject.FindGameObjectWithTag("rod");
        right = GameObject.FindGameObjectWithTag("right");
        left= GameObject.FindGameObjectWithTag("left"); ;
        gameOver = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameOver>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rod"))
        {
            if (transform.position.x> player.transform.position.x)
            {
                float hangover = (right.transform.position.x - transform.position.x) / 2;
                hangover = Mathf.Abs(hangover);
                CutRod(hangover, false);
                SpawnDropcylinderOnRight(hangover);
              
            }
            else if (transform.position.x < player.transform.position.x)
            {
                float hangover = (left.transform.position.x - transform.position.x) / 2;
                hangover = Mathf.Abs(hangover);
                CutRod(hangover, true);
                SpawnDropcylinderOnLeft(hangover);
            }
        }

        if (other.gameObject.CompareTag("Player"))
            gameOver.Die();

    }

  

    public void SpawnDropcylinderOnRight(float hangover)
    {
        var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinderobjectright = cylinder;
        cylinder.transform.localScale = new Vector3(playerrod.transform.localScale.x, hangover, playerrod.transform.localScale.z);
        cylinder.transform.position = new Vector3(right.transform.position.x + hangover, playerrod.transform.position.y, playerrod.transform.position.z);
        cylinder.transform.Rotate(new Vector3(0, 0, -90));
        cylinder.AddComponent<Rigidbody>();
        cylinder.GetComponent<MeshRenderer>().material = rodmater;
    }

   

    public void SpawnDropcylinderOnLeft(float hangover)
    {
        var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinderobjectleft = cylinder;
        cylinder.transform.localScale = new Vector3(playerrod.transform.localScale.x, hangover, playerrod.transform.localScale.z);
        cylinder.transform.position = new Vector3(left.transform.position.x - hangover, playerrod.transform.position.y, playerrod.transform.position.z);
        cylinder.transform.Rotate(new Vector3(0, 0, -90));
        cylinder.AddComponent<Rigidbody>();
        cylinder.GetComponent<MeshRenderer>().material = rodmater;
        
    }

    void CutRod(float hangover, bool left)
    {
        float hangoverMultiply = 0f;
        if (left)
            hangoverMultiply = 1;

        else
            hangoverMultiply = -1;


        playerrod.transform.localScale = new Vector3(playerrod.transform.localScale.x, playerrod.transform.localScale.y - hangover, playerrod.transform.localScale.z);
        playerrod.transform.position = new Vector3(playerrod.transform.position.x + hangover*hangoverMultiply, playerrod.transform.position.y, playerrod.transform.position.z);
        DOTween.Kill(playerrod.transform);
        playerrod.transform.DOLocalMoveX(0f, 0.8f).SetDelay(0.5f);
    }


}
