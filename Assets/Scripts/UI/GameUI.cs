using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public GameObject pausePanel;
    public TextMeshProUGUI money;
    private GameManager GM;
    private PlayerManager PM;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        PM = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMoney()
    {
        money.text = PM.money.ToString();
    }

    public void ShowGO(GameObject objectToShow)
    {
        objectToShow.SetActive(true);
    }
    public void HideGO(GameObject objectToHide)
    {
        objectToHide.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }
    public void LevelEnd()
    {
        GM.money += PM.money;
    }
}
