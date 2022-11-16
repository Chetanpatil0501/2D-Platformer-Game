
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int Index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            Sound_Manager.instance.LevelCompleteFX();
            Invoke("NextLevel", 2f);
        }
       
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(Index);
        if (Index > PlayerPrefs.GetInt("LevelAt"))
        {
            PlayerPrefs.SetInt("levelAt", Index);
        }
    }
}
