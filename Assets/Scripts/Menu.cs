using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void SceneNumber(int n)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(n);
    }

    public void SceneName(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
