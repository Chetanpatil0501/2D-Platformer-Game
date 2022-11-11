
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Level_Selector : MonoBehaviour
{
    public Button[] lvlButtons;
    public TextMeshProUGUI[] LevelText;
   

   
    private void Update()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 3); //<-Level 1 scene at.

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 3 > levelAt)
            {
                lvlButtons[i].interactable = false;
                LevelText[i].enabled = false;
            }

        }
    }

}
