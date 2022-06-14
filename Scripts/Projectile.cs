using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float _fSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _fSpeed * Time.deltaTime);
    }

    public void setDirection(Quaternion rotate)
    {
        transform.rotation = rotate;
    }
}
