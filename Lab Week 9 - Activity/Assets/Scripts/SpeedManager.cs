using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    // ANCHOR Property: Speed Modifier
    private static float speedModifier = 1.0f;
    // private static float speedModifier;
    public static float SpeedModifier
    {
        get { return speedModifier; }
        // NOTE No setter
    }
    public enum GameSpeed
    {
        Slow = 1,
        Fast = 3,
    }

    // ANCHOR Property: Current Speed State
    private static GameSpeed currentSpeedState = GameSpeed.Slow;
    public static GameSpeed CurrentSpeedState
    {
        get { return currentSpeedState; }
        set
        {
            currentSpeedState = value;
            switch (currentSpeedState)
            {
                case GameSpeed.Slow:
                    speedModifier = (float)GameSpeed.Slow;
                    break;
                case GameSpeed.Fast:
                    speedModifier = (float)GameSpeed.Fast;
                    break;
            }
        }
    }
}
