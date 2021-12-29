using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftPoint : MonoBehaviour
{
    public CarChanger carChanger_class;
    public CarCollisions carCollisions_class;
    public Transform text;

    public GameObject good_text;
    public GameObject perfect_text;
    public GameObject confetti;

    public Animation good;
    public Animation perfect;

    private float timeLeft = 1;
    private bool timer;
    private void Update()
    {
        if(timer)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                good_text.SetActive(false);
                perfect_text.SetActive(false);
                confetti.SetActive(false);
                timer = false;
                timeLeft = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="GameController")
        {
            if (carCollisions_class.noCol)
            {
                carChanger_class.levelCar++;
                if (carChanger_class.levelCar == 2)
                {
                    good_text.SetActive(true);
                    good.Play("good");
                    confetti.SetActive(true);
                    timer = true;
                }
                if (carChanger_class.levelCar >= 3)
                {
                    confetti.SetActive(true);
                    perfect_text.SetActive(true);
                    perfect.Play("perfect");
                    timer = true;
                }
            }
        }
    }

}
