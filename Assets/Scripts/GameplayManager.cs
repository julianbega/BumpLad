using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{    
    public List<Car> cars;

    public float[] Xposition;
    public float[] Yposition;

    public float maxSpeed;
    public float minSpeed;
    private void Start()
    {
        InvokeRepeating("spawner", 2.0f, 0.5f);
        GooglePlay.Init();
    }
    public void spawnCar(int id)
    {
        cars[id].isOnGame = true;
        int intAux;
        intAux = Random.Range(0, 2);
        cars[id].goingFast = intAux;
        float floatAux;
        floatAux = Random.Range(minSpeed, maxSpeed);
        float aux = Random.Range(Xposition[0], Xposition[5]);
        cars[id].speed = floatAux;
        if (cars[id].goingFast == 0)
        {
            cars[id].gameObject.transform.position = new Vector3(aux, Yposition[0], transform.position.z);
        }
        else
        {
            cars[id].gameObject.transform.position = new Vector3(aux, Yposition[1], transform.position.z);
        }
        
    }

    public void setBackToIdle(GameObject carToBack)
    {
        carToBack.GetComponent<Car>().speed = 0;
        carToBack.transform.position = new Vector3(0, 0, 0);
    }

    public void spawner()
    {
        int intAux;
        intAux = Random.Range(0, 11);

        bool allTrue = true;
        for (int i = 0; i < 11; i++)
        {
            if (cars[intAux].isOnGame == false)
                allTrue = false;
        }

        while (cars[intAux].isOnGame == true && allTrue == false)
        {
            intAux = Random.Range(0, 11);
        }
        if (allTrue) return;
        spawnCar(intAux);
    }


}
