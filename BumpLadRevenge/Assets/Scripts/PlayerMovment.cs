using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public float speed;
    Rigidbody2D body;
    public PlayerManager PM;

#if UNITY_EDITOR && !UNITY_ANDROID
    float horizontal;
    float vertical;

    public float unityEditorSpeed;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * unityEditorSpeed, vertical * unityEditorSpeed);
    }

#endif

#if UNITY_ANDROID
    void Start()
    {
        Input.gyro.enabled = true;
    }

    public void Update()
    {
        transform.position += (Input.gyro.rotationRateUnbiased * Time.deltaTime * speed);
    }
#endif


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Car"))
        {
            PM.Defeat();
        }
    }
}


