using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisions : MonoBehaviour
{
    public CarChanger carChanger_class;
    public bool noCol = true;
    private bool timer;
    private float timeLeft = 3;

    public GameObject confetti;
    public GameObject coll;

    private void Update()
    {
        if (timer)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                noCol = true;
                timer = false;
                timeLeft = 3;
                confetti.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Box")
        {
            Instantiate(coll, collision.gameObject.transform.position, Quaternion.identity);
            noCol = false;
            timer = true;
            carChanger_class.levelCar--;
            if (carChanger_class.levelCar == 1)
            {
                confetti.SetActive(true);
            }
            if (carChanger_class.levelCar >= 2)
            {
                confetti.SetActive(true);
            }  
        }
    }
}
