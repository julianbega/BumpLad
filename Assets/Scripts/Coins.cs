using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public float speed;
    public float limitY;
    public float[] Xposition;
    private bool isColliding;
    PlayerManager PM;
    GameUI GUI;
    void Start()
    {
        initCoin();
        PM = FindObjectOfType<PlayerManager>();
        GUI = FindObjectOfType<GameUI>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        if (transform.position.y <= limitY)
        {
            initCoin();
        }
    }

    void initCoin()
    {
        int aux = Random.Range(0, 5);
        this.transform.position = new Vector3(Xposition[aux], 7.0f, transform.position.z);
    }

    void SpawnCoin()
    {
        PM.money++;
        int aux = Random.Range(0, 5);
        this.transform.position = new Vector3(Xposition[aux], 7.0f, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (isColliding) return;
            isColliding = true;
            GUI.UpdateMoney();
            SpawnCoin();
            StartCoroutine(Reset());
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;

    }
}
