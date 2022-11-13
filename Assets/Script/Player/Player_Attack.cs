using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    bool IsAttacking;
    BoxCollider2D Coll;
    Animator anim;
    [SerializeField] GameObject AttackColl;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Coll = GetComponent<BoxCollider2D>();
        AttackColl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            IsAttacking = true;
            anim.SetTrigger("Attack");
            AttackColl.SetActive(true);
            Sound_Manager.instance.PlayerSound(Sound_Manager.PlayerSoundFX.PlayerAttack);

        }
        else
        {
            IsAttacking = false;
            AttackColl.SetActive(false);
        }
    }
}
