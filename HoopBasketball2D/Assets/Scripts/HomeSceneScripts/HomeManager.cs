using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    GameObject StartBtn;
    GameObject ExitBtn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
