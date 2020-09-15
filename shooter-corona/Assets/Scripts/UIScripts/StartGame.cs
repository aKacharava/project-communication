using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private string scene = string.Empty;

    public void Start_Game()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}
