using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource _explosion;
    // Start is called before the first frame update
    void Start()
    {
        _explosion = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void playDeathBoom()
    {
        _explosion.Play();
    }
}
