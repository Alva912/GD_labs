using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    private Vector3 target = new Vector3(-3, 1, 0);
    private float duration = 1.5f;
    public Tweener tweener;

    private void Update()
    {
        if (!tweener.TweenExists(transform))
        {
            target.x = target.x * -1;
            tweener.AddTween(transform, transform.position, target, duration/SpeedManager.SpeedModifier);
        }
    }
}
