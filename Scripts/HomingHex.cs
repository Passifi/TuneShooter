using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingHex : Enemy
{
    
    Vector3 _orientation;
    Player _player;
    [SerializeField]
    float _speedf = 5.0f;
    // Start is called before the first frame update
   

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_player != null)
        {
            _orientation = _player.transform.position - transform.position;
            _orientation = _orientation.normalized;
            transform.Translate(_orientation * _speedf * Time.deltaTime);

        }
        else
        {
            _player = FindObjectOfType<Player>();
            transform.Translate(new Vector3(Random.Range(-1, 1)*Time.deltaTime, Random.Range(-1, 1)*Time.deltaTime, 0));
        }
        
    }

  
}
