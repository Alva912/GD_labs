using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveGameManager : MonoBehaviour
{
    public GameObject player;
    public void SaveSpeed()
    {
        // GameObject player = PrefabUtility.GetCorrespondingObjectFromSourceAtPath(Player,"Assets/Prefabs/Player.prefab");
        // player.GetComponent<Animator>().SetInt((int)SpeedManager.CurrentSpeedState);
    }
    public void LoadSpeed()
    {

    }
    private void Start() {
        LoadSpeed();
    }
}
