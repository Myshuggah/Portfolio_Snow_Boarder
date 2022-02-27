using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float restartTime = 0f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") //other refers to the other thing thats hitting this object
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", restartTime);
            
        }       
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
