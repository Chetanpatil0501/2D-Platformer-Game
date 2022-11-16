
using UnityEngine;

public class Playerprfs : MonoBehaviour
{
   public void ClearData()
    {
        PlayerPrefs.DeleteAll();
        Sound_Manager.instance.ButtonClickFX();
    }
}
