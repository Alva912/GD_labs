using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintAndHide : MonoBehaviour
{
    private int i, randomNum;
    public Renderer rend;
    void Start()
    {
        i = 0;
        randomNum = Random.Range(200, 251);
    }

    void Update()
    {
        i += 1;
        if (gameObject.tag == "Red" && i == 100)
        {
            gameObject.SetActive(false);
        }
        if (gameObject.tag == "Blue" && i == randomNum)
        {
            rend.enabled = false;
        }
        Debug.Log(gameObject.name + ":" + i);
    }
}
