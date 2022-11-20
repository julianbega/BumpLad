using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    public int money;
    public float highscore;
    public Sprite selectedCar;
    public List<int> selectableCars;


    void Start()
    {
        PlayerPrefs.GetInt("money");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockAchivments(string name)
    {
        GooglePlay.UnlockAchievement(name);
    }
}
