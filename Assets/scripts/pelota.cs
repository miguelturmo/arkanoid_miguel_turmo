using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelota : MonoBehaviour
{
   public Rigidbody2D rigidballbody2D;
   public float speed = 250;
   private Vector2 velocity;
   public Vector2 speedIncrement = new Vector2(0.5f, 0.5f);
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
        IncreaseSpeed();
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
    
    private void IncreaseSpeed()
    {
        Vector2 currentVelocity = rigidballbody2D.velocity;

        Vector2 newVelocity = new Vector2(
            currentVelocity.x + (currentVelocity.x > 0 ? speedIncrement.x : -speedIncrement.x),
            currentVelocity.y + (currentVelocity.y > 0 ? speedIncrement.y : -speedIncrement.y));
        rigidballbody2D.velocity = newVelocity;
    }
}
