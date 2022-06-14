using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    SpawnManager spawnManager;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    AudioManager audioManager;
    public float _fSpeed;
    [SerializeField]
    ParticleSystem _explosion;
    bool wasSeen = false;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

        wasSeen = true;
    }

    private void OnBecameInvisible()
    {
        if (wasSeen)
            {
            spawnManager._enemyCounter -= 1;
            Destroy(gameObject);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag != "Enemy")
        {
            ParticleSystem _exp = Instantiate(_explosion, transform.position, Quaternion.identity);
            _exp.Play();
            audioManager.playDeathBoom();
            gameManager.addScore(15f);
            
            Destroy(gameObject);
            
        }
        
    }


}
