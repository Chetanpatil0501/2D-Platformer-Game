
using UnityEngine;
using UnityEngine.UI;

public class KeyCollecter : MonoBehaviour
{
    private int Keys = 0;
    private int Score = 0;

    [SerializeField] private Text KeyText;
    [SerializeField] private Text ScoreText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Sound_Manager.instance.KeyCollectFX();
            Destroy(collision.gameObject);
            Keys++;
            KeyText.text = "Keys: " + Keys;
            Score += 10;
            ScoreText.text = "Score: " + Score;
        }
      
    }
}
