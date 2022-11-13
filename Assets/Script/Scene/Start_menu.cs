using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_menu : MonoBehaviour
{
    public void Main_menu()
    {
        SceneManager.LoadScene("Start_menu");
        Sound_Manager.instance.ButtonClickFX();
    }
    public void Quit()
    {
        Application.Quit();
        Sound_Manager.instance.ButtonClickFX();
    }

    public void Start_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Sound_Manager.instance.ButtonClickFX();
    }

    public void Select_level_button()
    {
        SceneManager.LoadScene("Level_selection");
        Sound_Manager.instance.ButtonClickFX();
    }
    public void BackButton()
    {
        SceneManager.LoadScene(1);
        Sound_Manager.instance.ButtonClickFX();
    }
    private int ToContinueScene;


    public void ContinueButton()
    {
        
        ToContinueScene = PlayerPrefs.GetInt("SavedScene");
        Sound_Manager.instance.ButtonClickFX();

        if (ToContinueScene != 0)
        {
            SceneManager.LoadScene(ToContinueScene);
        }

        else { return; }
    }
}
