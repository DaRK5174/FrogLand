using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;

    public Transform player;
    public Transform FeetPos;
    public int health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    
    void Update()
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

}
