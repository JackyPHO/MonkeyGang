using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
//Menu Tutorial from Zenva
{
    public void onPlayButton(){
        SceneManager.LoadScene("GameStart");
    }
    public void onQuitButtion()
    {
        Application.Quit();
    }
}
