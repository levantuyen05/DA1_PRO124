using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSetting : MonoBehaviour
{
   
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void Setting()
    {
        SceneManager.LoadScene(2);
    }

    public void Extras()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        SceneManager.LoadScene(2);
    }
}


