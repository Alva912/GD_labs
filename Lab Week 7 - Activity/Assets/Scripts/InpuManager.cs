using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InpuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    private Tweener tweener;
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    void Update()
    {
        Transform target = item.transform;
        Vector3 startPos = target.position;
        if (Input.GetKey(KeyCode.A))
        {
            tweener.AddTween(target, startPos, new Vector3(-2.0f, 0.5f, 0.0f), 1.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            tweener.AddTween(target, startPos, new Vector3(2.0f, 0.5f, 0.0f), 1.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            tweener.AddTween(target, startPos, new Vector3(0.0f, 0.5f, -2.0f), 0.5f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            tweener.AddTween(target, startPos, new Vector3(0.0f, 0.5f, 2.0f), 0.5f);
        }
    }
}
