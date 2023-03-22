using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Accident : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.1f;
    [SerializeField] ParticleSystem accidentEffect;
    [SerializeField] AudioClip accidentSFX;

    bool hasAccident = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !hasAccident)
        {
            hasAccident = true;
            FindObjectOfType<PlayerController>().DisableControls();
            accidentEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(accidentSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
