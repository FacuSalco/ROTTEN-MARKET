using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip coinSound, healSound, clickErrorSound, clickSound, jumpSound, pickUpSound, deathSound, punchSound, questComplete;
    public AudioClip[] hitSounds;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
        //audioSource.PlayOneShot(coinSound, NUMERO DE VECES QUE QUIERO MULTIPLICAR EL VOLUMEN);
    }
    public void PlayHealSound()
    {
        audioSource.PlayOneShot(healSound);
    }
    public void PlayClickErrorSound()
    {
        audioSource.PlayOneShot(clickErrorSound);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
    public void PlayHitSound()
    {
        int i = Random.Range(0, hitSounds.Length);
        audioSource.PlayOneShot(hitSounds[i]);
        Debug.Log(i);
    }
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
    public void PlayPickUpSound()
    {
        audioSource.PlayOneShot(pickUpSound);
    }
    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
    public void PlayPunchSound()
    {
        audioSource.PlayOneShot(punchSound); //Cuando un enemigo es golpeado
    }
    public void PlayQuestCompleteSound()
    {
        audioSource.PlayOneShot(questComplete);
    }

}
