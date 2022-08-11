using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCheck : MonoBehaviour
{
    GameObject right;
    GameObject left;
    GameOver gameOver;
    public GameObject sliderRight;
    public GameObject sliderLeft;
    

    void Start()
    {
        right = GameObject.FindGameObjectWithTag("right");
        left = GameObject.FindGameObjectWithTag("left"); ;
        gameOver = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameOver>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("rod"))
        {

            if (right.transform.position.x + 0.1f < sliderRight.transform.position.x  )
                gameOver.Gameover();

            if (left.transform.position.x -0.1f >  sliderLeft.transform.position.x)              
               gameOver.Gameover();
        }
    }

}
