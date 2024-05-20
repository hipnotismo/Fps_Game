using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    private bool pause;

    void Update()
    {
        //pause = Input.GetKeyUp(KeyCode.P);
        if (Input.GetKeyUp("p"))
        {
            pause = !pause;
            Debug.Log("space key was pressed");
        }
        PauseCheck();
    }

    void PauseCheck()
    {
        if (pause)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1.0f;

        }
    }
}
