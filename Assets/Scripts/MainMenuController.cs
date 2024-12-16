using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        
        SceneManager.LoadScene("SampleScene"); 
    }

    public void QuitGame()
    {
        
        Application.Quit();
        Debug.Log("Juego cerrado"); 
    }
}
