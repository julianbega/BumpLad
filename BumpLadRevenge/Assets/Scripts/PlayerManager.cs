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





}
