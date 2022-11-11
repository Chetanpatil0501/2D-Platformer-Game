
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level_button : MonoBehaviour
{
    [Header("Button text")]
    public TextMeshProUGUI Button_num_text;


   public void LoadLevel()
    {
        SceneManager.LoadScene("Level_" + Button_num_text.text);
    }
}
