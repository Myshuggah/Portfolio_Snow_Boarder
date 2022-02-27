using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float restartTime = 0f;
    [SerializeField] ParticleSystem damageEffect;
    [SerializeField] AudioClip crashSFX;

    bool playOnce = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && playOnce == false)
        {
            playOnce = true;
            FindObjectOfType<PlayerController>().DisableControls();
            damageEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", restartTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
