using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool gameOver;
    public GameObject confetti;
    public GameObject finish_text;
    private void OnTriggerEnter(Collider other)
    {
        confetti.SetActive(true);
        finish_text.SetActive(true);
        gameOver = true;
    }
}
