using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Transform[] transArray;
    private string[] tags = { "Red", "Blue" };

    // Start is called before the first frame update
    void Start()
    {
        transArray = new Transform[2];

        transArray[0] = GameObject.FindWithTag(tags[0]).transform;
        transArray[1] = GameObject.FindWithTag(tags[1]).transform;
    }

    void AddComponent(GameObject obj)
    {
        obj.AddComponent<PrintAndHide>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transArray[0].Rotate(0, 0, 45, Space.World);
            transArray[1].Rotate(0, 0, -45, Space.World);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            foreach (Transform trans in transArray)
            {
                trans.position = new Vector3(trans.position.x, trans.position.y * -1, trans.position.z);
            }
        }
        for (int i = 0; i < tags.Length; i++)
        {
            var obj = GameObject.FindWithTag(tags[i]);
            if (obj != false)
            {
                PrintAndHide printAndHide = obj?.GetComponent<PrintAndHide>();
                if (printAndHide != null)
                {
                    if (Input.GetButtonUp("Fire1"))
                    {
                        Color[] colors = { new Color(Random.Range(51.0f, 255.0f), 0.0f, 0.0f, 1.0f), new Color(0.0f, 0.0f, Random.Range(51.0f, 255.0f), 1.0f) };
                        printAndHide.rend.material.color = colors[i];
                        Debug.Log(tags[i] + ":" + colors[i]);
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(printAndHide);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        AddComponent(obj);
                        // Debug.Log("Added");
                    }
                }
            }
        }
    }
}
