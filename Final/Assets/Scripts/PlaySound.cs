using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource zombieAudio;
   

    void OnTriggerEnter(Collider trigger) {
        if (trigger.gameObject.tag == "Spider") {
            zombieAudio.Play();
            Destroy(trigger.gameObject);
        }
    }
}
