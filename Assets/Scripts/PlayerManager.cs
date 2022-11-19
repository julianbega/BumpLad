using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int money;
    public Vector3 startPos;
    public GameObject pauseButton;
    public GameObject defeatPanel;
    void Start()
    {
        this.transform.position = startPos; 
    }

    public void Defeat()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        defeatPanel.gameObject.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("ChoquePlayer-Auto");
            Defeat();
        }

        
    }



}
