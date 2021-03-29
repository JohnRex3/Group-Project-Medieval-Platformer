using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
        }

    }
}
