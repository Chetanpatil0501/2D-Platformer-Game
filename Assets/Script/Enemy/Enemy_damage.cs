using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_damage : MonoBehaviour
{
    
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            anim.SetTrigger("Dead");
            Destroy(gameObject, 0.5f);
            Sound_Manager.instance.EnemyDieFX();

        }
    }
}
