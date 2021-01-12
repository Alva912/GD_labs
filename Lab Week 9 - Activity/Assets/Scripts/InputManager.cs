using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            SpeedManager.CurrentSpeedState =
            (SpeedManager.CurrentSpeedState == SpeedManager.GameSpeed.Slow)
            ? SpeedManager.GameSpeed.Fast
            : SpeedManager.GameSpeed.Slow;
            // SaveGameManager.SaveSpeed();
        }
        if (GameManager.currentGameState == GameManager.GameState.Start && Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(gameObject.GetComponent<Tweener>());
            // NOTE To add a scene to the build settings use menu File->Build Settings...
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            DontDestroyOnLoad(this.gameObject);
            GameManager.currentGameState = GameManager.GameState.WalkingLevel;
        }
    }
}
