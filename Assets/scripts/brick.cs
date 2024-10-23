using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int fila; 
    private int golpesRestantes; 

    private void Start()
    {
        
        fila = Mathf.Clamp(Mathf.CeilToInt(transform.position.y), 1, 5);
        golpesRestantes = fila;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pelota"))
        {
            golpesRestantes--;

            if (golpesRestantes <= 0)
            {
               
                FindObjectOfType<GameManager>().CheckComplete();
                Destroy(gameObject);
            }
            FindObjectOfType<GameManager>().AddScore(100);
        }
    }
}