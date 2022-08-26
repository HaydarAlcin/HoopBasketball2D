using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public GameObject Panel;
    public GameObject PauseBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseButton()
    {
        
        Time.timeScale = 0;
        PauseBtn.SetActive(false);
        Panel.SetActive(true);
    }

    public void ResumeButton()
    {
        Panel.SetActive(false);
        PauseBtn.SetActive(true);
        Time.timeScale = 1.8f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
