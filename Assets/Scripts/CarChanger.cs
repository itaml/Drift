using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChanger : MonoBehaviour
{
    public GameObject Jeep;
    public GameObject Mustang;
    public GameObject Sportcar;
    public GameObject confetti;

    public CarController carControl_class;

    public int levelCar;
    public int enemies;
    public int boxes;
    private float timeLeft = 1;
    private bool timer;

    void Start()
    {
        levelCar = 1;
    }

    private void Update()
    {
        if(levelCar <= 0) { levelCar = 1; } 
        if(levelCar == 1) { Change_Jeep();  }
        if(levelCar == 2) { Change_Mustang(); }
        if(levelCar == 3) { Change_Sportcar(); }
        if(levelCar >= 4) { levelCar = 3; }

        if (timer)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                confetti.SetActive(false);
                timer = false;
                timeLeft = 1;
            }
        }
    }

    void Change_Jeep()
    {
        Jeep.SetActive(true);
        Sportcar.SetActive(false);
        Mustang.SetActive(false);
        carControl_class.forwardAccel = 13;
    }

    void Change_Mustang()
    {
        Jeep.SetActive(false);
        Sportcar.SetActive(false);
        Mustang.SetActive(true);
        carControl_class.forwardAccel = 15;
    }

    void Change_Sportcar()
    {
        Mustang.SetActive(false);
        Jeep.SetActive(false);
        Sportcar.SetActive(true);
        carControl_class.forwardAccel = 17;
    }

}
