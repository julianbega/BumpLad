using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct playerCars
    {
        public Sprite car;
        public bool unlocked;
    }
    
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
    public List<playerCars> playerCarsList;

    void Start()
    {
        
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
