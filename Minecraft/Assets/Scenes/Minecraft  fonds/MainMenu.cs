using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//credit by guemmar_abderrahmane
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}




























//credit by Guemmar_abderrahmane