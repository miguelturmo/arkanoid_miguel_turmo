using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelota : MonoBehaviour
{
   public Rigidbody2D rigidballbody2D;
   public float speed = 250;
   private Vector2 velocity;
    private float speedmultiplier = 1.05f;
    Vector2 startPosition;
    // Update is called once per frame
 
        
    
    // Update is called once per frame
    void Start()
    {
        startPosition = transform.position;
        ResetBall();
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        speed *= speedmultiplier;
        if (collision.gameObject.CompareTag("Death"))
        {
            FindAnyObjectByType<GameManager>().loselive();
        }
    }
    
    public void ResetBall()
    {
        transform.position = startPosition;
        speed = 250;
        rigidballbody2D.velocity = Vector2.zero;
        velocity.x = Random.Range(-1, 1);
        velocity.y = 1;
        rigidballbody2D.AddForce(velocity * speed);
    }
    
}
