using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    GameManager GM;
    public TextMeshProUGUI money;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        Invoke("UpdateMoney", 0.04f);
    }
    private void UpdateMoney()
    {
        money.text = GM.money.ToString();
    }


}
