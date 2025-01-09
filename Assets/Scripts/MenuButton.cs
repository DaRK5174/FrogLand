using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public string sceneName;
    public void OnClickPlay()
    {
        SceneManager.LoadScene(sceneName);
    }
   
    public void OnClickExit()
    {
        Application.Quit();
    }
}
