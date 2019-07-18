using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplicationManager : MonoBehaviour
{
    public void Restart()
    {
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneBuildIndex);
    }
    
    public void Quit()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }

}
