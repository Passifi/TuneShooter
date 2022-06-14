using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : Enemy
{
    int _xDir = 0;
    int _yDir = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 8)
            _xDir = -1;
        else if (transform.position.x < -8)
            _xDir = 1;
        if (transform.position.y > 5)
            _yDir = -1;
        else if (transform.position.y < -5)
            _yDir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    void Fly()
    {
        transform.Translate(new Vector3(_xDir * _fSpeed * Time.deltaTime, _yDir * _fSpeed * Time.deltaTime, 0));

    }
}
