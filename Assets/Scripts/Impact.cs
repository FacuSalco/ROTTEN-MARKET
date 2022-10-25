using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    public AudioClip Sound;
    public float volumeModifier;
    AudioSource audioSource;
    bool waited5Seconds;
    bool cool = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("Waited5Seconds", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (waited5Seconds && cool)
        {
            AudioSource.PlayClipAtPoint(Sound, transform.position, volumeModifier);
            StartCoroutine(CooldownCoroutine(0.5f));            
        }
    }

    void Waited5Seconds() //Porque habia muchos ruidos al inicio, entonces todo los sonidos que deberian pasar en los primeros 5 segundo no se reproducen
    {
        waited5Seconds = true;
    }
    IEnumerator CooldownCoroutine(float coolDownTime)
    {
        cool = false;
        yield return new WaitForSeconds(coolDownTime);
        cool = true;
        //Debug.Log("Cooldown is over");
    }

}
