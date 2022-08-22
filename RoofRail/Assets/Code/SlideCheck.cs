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
    public ParticleSystem particlePrefab;
    

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
            float distanceRight = right.transform.position.x - sliderRight.transform.position.x;
            ParticleSystem particleEffect =  Instantiate(particlePrefab);
            ParticleSystem particleEffect2 =  Instantiate(particlePrefab);
            particleEffect.transform.position = new Vector3(sliderRight.transform.position.x, right.transform.position.y, right.transform.position.z);
            particleEffect2.transform.position = new Vector3(sliderLeft.transform.position.x, left.transform.position.y, left.transform.position.z);

            if (right.transform.position.x + 0.1f < sliderRight.transform.position.x  )
                gameOver.Gameover();

            if (left.transform.position.x -0.1f >  sliderLeft.transform.position.x)              
               gameOver.Gameover();
        }
    }

}
