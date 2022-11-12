using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public int goingFast;
    public float speed;
    public bool isOnGame;



    void Update()
    {
        if (goingFast == 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Car"))
        {
            Debug.Log("Choque");
            float auxSpeed = collision.gameObject.GetComponent<Car>().speed;
            goingFast = 0;
            if (auxSpeed >= speed)
            {
                speed = auxSpeed;
            }
        }

        if (collision.collider.CompareTag("Finish"))
        {
            Debug.Log("Finish");
            speed = 0;
            transform.position = new Vector3(15, 15, -1.0f);
            isOnGame = false;
        }
    }

   
}
