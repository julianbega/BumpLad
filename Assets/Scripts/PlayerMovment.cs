using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public float speed;
    public Rigidbody2D body;
    float dx;
    float dy;
    public PlayerManager PM;


    void Start()
    {        
        Input.gyro.enabled = true;
    }

    public void Update()
    {
        dx = Input.acceleration.x * speed * Time.deltaTime;
        dy = Input.acceleration.y * speed * Time.deltaTime;
        transform.position = new Vector2 (Mathf.Clamp(transform.position.x, -7.5f, 7.5f), Mathf.Clamp(transform.position.y, -7.5f, 7.5f));
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(dx, dy);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Car"))
        {
            PM.Defeat();
        }
    }
}


