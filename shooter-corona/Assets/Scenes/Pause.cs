using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private string menu_scene = "Menu";

    public Transform pauseScreen;

    private bool paused = false;
    private bool isMenuOpen = true;
    // Start is called before the first frame update
    private void Start()
    {
        pauseScreen.gameObject.SetActive(false);
        paused = true; Time.timeScale = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&!isMenuOpen)
        {
            paused = !paused;
            pauseScreen.gameObject.SetActive(paused);
            Time.timeScale = paused ? 0 : 1;
        }
    }

    public void Continue()
    {
        if (paused)
        {
            paused = false;
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void CloseHelpMenu()
    {
        isMenuOpen = false;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menu_scene);
    }
}
