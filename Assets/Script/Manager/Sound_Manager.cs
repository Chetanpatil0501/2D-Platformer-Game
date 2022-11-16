
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    private static Sound_Manager _instance = null;
    AudioSource Audio;
    [Header("UI Sound FX")]
    [SerializeField] AudioClip ButtonCLickclip;
    [SerializeReference] AudioClip GameOver;

    public enum PlayerSoundFX
    {
        PlayerRun,
        PlayerWalk,
        PlayerJump,
        PlayerAttack,
        PlayerHurt,
        PlayerDie
    }
    [Header("Enemy Sound Fx")]
    [SerializeField] AudioClip EnemyDie;
    [SerializeField] AudioClip EnemyAttack;

    [Header("Interactables Sound Fx")]
    [SerializeField] AudioClip Interactables;
    [SerializeField] AudioClip LevelComplete;


    public static Sound_Manager instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = (Sound_Manager)FindObjectOfType(typeof(Sound_Manager));
                
            }
            return _instance;

        }
    }
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        if (instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
       
    }

    public void ButtonClickFX()
    {
        Audio.PlayOneShot(ButtonCLickclip);
    }

    public void GameOverFX()
    {
        Audio.PlayOneShot(GameOver);
    }

    #region Enemy Sound Fx

    public void EnemyDieFX()
    {
        Audio.PlayOneShot(EnemyDie, 0.8f);
    }
    public void EnemyattackFX()
    {
        Audio.PlayOneShot(EnemyAttack, 0.4f);
    }
    #endregion


    #region Player Sound Fx
    private static Dictionary<PlayerSoundFX, float> SoundTimerDictionary;
    public static void Initialize()
    {
        SoundTimerDictionary = new Dictionary<PlayerSoundFX, float>();
        SoundTimerDictionary[PlayerSoundFX.PlayerRun] = 0f;
        SoundTimerDictionary[PlayerSoundFX.PlayerWalk] = 0f;
    }

    public void PlayerSound(PlayerSoundFX Sound)
    {
        if (canPlaySound(Sound))
        {
            Audio.PlayOneShot(GetAudioClip(Sound));
        }
       
    }

    private static bool canPlaySound(PlayerSoundFX sound)
    {
        switch (sound)
        {
            default:
                return true;


            case  PlayerSoundFX.PlayerRun:
                if (SoundTimerDictionary.ContainsKey(sound))
                {
                    float LastTimePlayed = SoundTimerDictionary[sound];
                    float PlayerRunTimer = .29f;
                    if (LastTimePlayed + PlayerRunTimer < Time.time)
                    {
                        SoundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
              


            case PlayerSoundFX.PlayerWalk:
                if (SoundTimerDictionary.ContainsKey(sound))
                {
                    float LastTimePlayed = SoundTimerDictionary[sound];
                    float PlayerRunTimer = .5f;
                    if (LastTimePlayed + PlayerRunTimer < Time.time)
                    {
                        SoundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
             
         
             
           
        }
    }

    private static AudioClip GetAudioClip(PlayerSoundFX sound) 
    {
        foreach (SoundAudioClip soundAudioClip in instance.PlayerSoundArray)
        {
            if (soundAudioClip.soundState == sound)
            {
                return soundAudioClip.playerFX;
            }
        }
        Debug.LogError("Sound : " + sound + " Not found.");
        return null;
    }

    public SoundAudioClip[] PlayerSoundArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public PlayerSoundFX soundState;
        public AudioClip playerFX;
    }
    #endregion

    #region Inractables Fx

    public void KeyCollectFX()
    {
        Audio.PlayOneShot(Interactables);
    }
    public void LevelCompleteFX()
    {
        Audio.PlayOneShot(LevelComplete);
    }
    #endregion

}
