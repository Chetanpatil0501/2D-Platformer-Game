
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    [SerializeField] GameObject Game_Over_screen;
    [SerializeField] GameObject UI;
    bool isDead;




    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        Game_Over_screen.SetActive(false);
        UI.SetActive(true);
        isDead = false;
    }
    private void Update()
    {
        if (isDead)
        {
            GetComponent<Player_Attack>().enabled = false;
        }
    }
    public void TakeDamage(float _damage)
    {
        

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            Sound_Manager.instance.PlayerSound(Sound_Manager.PlayerSoundFX.PlayerHurt);
           
            //iframes
        }
        
        else
        {
            GetComponent<MoveMent_blend>().enabled = false;
            GetComponent<Jump_Crouch>().enabled = false;
            if (currentHealth <=0)
            {
                
                anim.SetTrigger("die");
             
                UI.SetActive(false);
                
                Invoke("Game_over", 1f);
                isDead = true;
    
            }
        }
    }
   public void Game_over()
    {
        
       Game_Over_screen.SetActive(true);
        Sound_Manager.instance.GameOverFX();


    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
