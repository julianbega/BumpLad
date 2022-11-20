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


    public GameObject tutorial;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        PM = FindObjectOfType<PlayerManager>();
        money.text = GM.money.ToString();
        Invoke("HideTuto", 2.95f);
    }

    private void HideTuto()
    {
        tutorial.SetActive(false);
    }

    public void UpdateMoney()
    {
        GM.money += PM.money;
        money.text = GM.money.ToString();
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
