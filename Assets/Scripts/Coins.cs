using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public float speed;
    public float limitY;
    public float[] Xposition;
    PlayerManager PM;
    GameUI GUI;
    void Start()
    {
        SpawnCoin();
        PM = FindObjectOfType<PlayerManager>();
        GUI = FindObjectOfType<GameUI>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        if (transform.position.y <= limitY)
        {
            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        int aux = Random.Range(0, 5);
        this.transform.position = new Vector3(Xposition[aux], 7.0f, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnCoin();
        PM.money++;
        GUI.UpdateMoney();
        }
    }
}
  