using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    private float inputvalue;
    public float speed = 25;
    private Vector2 direction;
    Vector2 startPosition;
    // Update is called once per frame
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        inputvalue = Input.GetAxisRaw("Horizontal");
        if(inputvalue == 1)
        {
            direction = Vector2.right;
        }
        else if (inputvalue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        rigidbody2D.AddForce(direction * speed * Time.deltaTime * 100);
    }
    public void ResetPlayer()
    {
        transform.position = startPosition;
        rigidbody2D.velocity = Vector2.zero;
    }
}
