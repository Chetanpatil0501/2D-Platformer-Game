
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject AttackColl;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AttackColl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
          
            anim.SetTrigger("Attack");
            AttackColl.SetActive(true);
            Sound_Manager.instance.PlayerSound(Sound_Manager.PlayerSoundFX.PlayerAttack);

        }
        else
        {
          
            AttackColl.SetActive(false);
        }
    }
}
