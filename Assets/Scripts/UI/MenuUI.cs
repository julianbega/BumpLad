using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    GameManager GM;
    public TextMeshProUGUI money;
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        money.text = GM.money.ToString();
    }


}
