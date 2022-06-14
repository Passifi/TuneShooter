using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMarker : MonoBehaviour
{
    [SerializeField]
    Light halo;

    [SerializeField]
    PacShip pacupacu;
    [SerializeField]
    int _spawnCounter = 60;
    
    public float _fSpeedI = 0.01f;
    public float _fSpeedL = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(halo.range > 0.2) 
        {
            halo.intensity += _fSpeedI*Time.deltaTime;
            halo.range -= _fSpeedL*Time.deltaTime;

        }
        else 
        {
            Instantiate(pacupacu, transform.position, Quaternion.identity);
            _spawnCounter--;

            if(_spawnCounter <= 0)
            {
                Destroy(gameObject);
            }
           

        }
        
    }   
}
