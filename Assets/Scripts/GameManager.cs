using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float killCount;
    public Text killCountText;

    public GameObject PauseMenu;
    public GameObject WinMenu;

    private bool gameIsPaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void WinLevel()
    {
        WinMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void AppQuit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {

    }

    public void NextLevel()
    {

    }

    public void AddKill()
    {
        killCount++;
        killCountText.text = "KILL : " + killCount;

    }
}
