using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerprfs : MonoBehaviour
{
   public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
