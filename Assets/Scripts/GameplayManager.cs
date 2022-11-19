using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{    
    public List<Car> cars;

    public float[] Xposition;
    public float[] Yposition;

    public float fastMaxSpeed;
    public float fastMinSpeed;
    public float slowMaxSpeed;
    public float slowMinSpeed;

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
        float aux = Random.Range(Xposition[0], Xposition[1]);
        if (cars[id].goingFast == 0)
        {
            floatAux = Random.Range(slowMinSpeed, slowMaxSpeed);
            cars[id].speed = floatAux;
            cars[id].gameObject.transform.position = new Vector3(aux, Yposition[0], transform.position.z);
        }
        else
        {
            floatAux = Random.Range(fastMinSpeed, fastMaxSpeed);
            cars[id].speed = floatAux;
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
