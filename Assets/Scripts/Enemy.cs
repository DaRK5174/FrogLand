using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;

    public Transform player;
    public Transform FeetPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {       
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

}
