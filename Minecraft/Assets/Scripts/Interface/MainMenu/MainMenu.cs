using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  // Function to play the game
  public void PlayGame()
  {
    SceneManager.LoadScene(1);
  }

  // Function to quit the game
  public void QuitGame()
  {
    Application.Quit();
  }
}




























//credit by Guemmar_abderrahmane