using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecogerBalon : MonoBehaviour
{

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
            audioSource.Play();
            Marcador.value -=1;
            Destroy(gameObject.GetComponent<Renderer>());
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(gameObject, 1);
        
    }

}
