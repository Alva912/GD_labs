using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRotation : MonoBehaviour
{
    public Animator animatorController;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {

            animatorController.SetTrigger("RotateParam");
            audioSource.Play();

        }
    }
}
