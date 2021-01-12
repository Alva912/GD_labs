using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int curTime;
    private float timer;
    private bool paused = false;
    [SerializeField]
    private Transform[] transArray;
    const float moveWait = 2.0f;
    const float scaleWait = 4.0f;

    void ResetTime()
    {
        timer = 0;
        curTime = 0;
        InvokeRepeating("ScaleObject", 0.0f, scaleWait);
    }

    void MoveObjects()
    {
        foreach (Transform trans in transArray)
        {
            if (trans.position.x / trans.position.y > 0)
            {
                trans.position = new Vector3(trans.position.x, trans.position.y * -1, trans.position.z);
            }
            else
            {
                trans.position = new Vector3(trans.position.x * -1, trans.position.y, trans.position.z);
            }
        }

    }
    void ScaleObject()
    {
        foreach (Transform trans in transArray)
        {
            trans.localScale = trans.localScale * (trans.localScale.x > 1.5f ? 1 / 1.2f : 1.2f);
        }
    }

    IEnumerator RotateObjects(float randomDelay)
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(randomDelay);
            foreach (Transform trans in transArray)
            {
                trans.Rotate(0, 0, 90, Space.World);
            }
        }
    }

    void Start()
    {
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 2.0f;
        ResetTime();
        InvokeRepeating("MoveObjects", moveWait, moveWait);
    }

    void Update()
    {
        // if (curTime < Time.time)
        // {
        //     Debug.Log(curTime);
        //     curTime++;
        // }
        timer += Time.deltaTime;
        if (timer >= curTime)
        {
            Debug.Log(curTime);
            curTime++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0;
                CancelInvoke("ScaleObject");
            }
            else
            {
                Time.timeScale = 1;
                InvokeRepeating("ScaleObject", 0.0f, scaleWait);
            }
            Debug.Log("Spacebar pressed");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CancelInvoke("ScaleObject");
            ResetTime();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            float randomDelay = Random.Range(0.25f, 0.75f);
            StartCoroutine(RotateObjects(randomDelay));
        }
    }
}
