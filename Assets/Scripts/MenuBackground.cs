using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    public float speed;
    public float startX;
    public float limitX;


    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        if (transform.position.x <= limitX)
        {
            transform.position = new Vector3(startX, 0, transform.position.z);
        }
    }
}
