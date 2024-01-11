using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OpenSceneMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSceneNight()
    {
        SceneManager.LoadScene("Night");
    }
    public void OpenSceneDay()
    {
        SceneManager.LoadScene("Day");
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
