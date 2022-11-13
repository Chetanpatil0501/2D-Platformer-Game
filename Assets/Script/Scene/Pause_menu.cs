
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause_menu : MonoBehaviour
{

    [SerializeField] GameObject Pause_panel;
    // Start is called before the first frame update
    void Start()
    {
        Pause_panel.SetActive(false);
    }

    public void Pause()
    {
        Pause_panel.SetActive(true);
        Sound_Manager.instance.ButtonClickFX();
        Time.timeScale = 0f;
        
    }

    private int CurrentBuildIndex;
    public void menu()
    {
        CurrentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", CurrentBuildIndex);
        SceneManager.LoadScene(1);
        Sound_Manager.instance.ButtonClickFX();
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        Pause_panel.SetActive(false);
        Sound_Manager.instance.ButtonClickFX();
        Time.timeScale = 1f;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Sound_Manager.instance.ButtonClickFX();
        Time.timeScale = 1f;
    }

}
