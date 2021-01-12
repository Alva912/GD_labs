using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Camera refCamera;
    private Image innerBar;
    private GameObject player;

    private void Update()
    {
        if (player && innerBar)
            UpdateHealthBar(player);

        if (!refCamera)
            refCamera = Camera.main;
        else RotateCamera(refCamera);
    }

    private void LateUpdate()
    {
        if (player && innerBar)
            CameraFacing(innerBar.transform.parent);

        // if (refCamera)
        //     RotateCamera(refCamera);
    }

    // SECTION Callback via UI-Button-Inspector-OnClick() list, load new level
    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        DontDestroyOnLoad(this.gameObject);
        // NOTE The SceneManager.sceneLoaded delegate can have any method (that takes a Scene and a LoadSceneMode) hooked into it.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            // NOTE Quit game button listener
            Button quitButton = GameObject.FindWithTag("QuitButton").GetComponent<Button>();
            quitButton.onClick.AddListener(QuitGame);
            // ANCHOR 
            innerBar = GameObject.FindWithTag("PlayerHealthBar").GetComponent<Image>();
            player = GameObject.FindWithTag("Player");
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    // !SECTION

    public void UpdateHealthBar(GameObject player)
    {
        float xPos = player.transform.position.x;
        float hp = 1.0f - Mathf.Abs(xPos) / 5.0f;
        innerBar.fillAmount = Mathf.Clamp(hp, 0.0f, 1.0f);
        if (innerBar.fillAmount < .5f && innerBar.color != Color.red)
        {
            innerBar.color = Color.red;
        }
        if (innerBar.fillAmount > .5f && innerBar.color == Color.red)
        {
            innerBar.color = Color.green;
        }
    }

    public void CameraFacing(Transform billboard)
    {
        Vector3 targetPosition = billboard.transform.position + refCamera.transform.rotation * Vector3.forward;
        Vector3 targetOrientation = refCamera.transform.rotation * Vector3.up;
        billboard.transform.LookAt(targetPosition, targetOrientation);
    }

    public void RotateCamera(Camera refCamera)
    {
        // NOTE 30 degrees/second
        float rotateSpeed = 30.0f;
        float rotate = Input.GetAxis("CameraRotate") * rotateSpeed * Time.deltaTime;
        refCamera.transform.RotateAround(refCamera.transform.position, Vector3.up, rotate);
    }
}
