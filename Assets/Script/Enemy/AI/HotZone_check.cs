using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZone_check : MonoBehaviour
{
    private Enemy_behaviour Enemy_parent;
    private bool InRange;
    private Animator anim;

    private void Awake()
    {
        Enemy_parent = GetComponentInParent<Enemy_behaviour>();
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        if (InRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Enemy_parent.Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InRange = false;
        gameObject.SetActive(false);
        Enemy_parent.TriggerArea.SetActive(true);
        Enemy_parent.inRange = false;
        Enemy_parent.SelectTarget();
    }
}
