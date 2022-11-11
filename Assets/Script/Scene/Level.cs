using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int Index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(Index);
            if (Index > PlayerPrefs.GetInt("LevelAt"))
            {
                PlayerPrefs.SetInt("levelAt", Index);
            }
       
        }
    }
}
