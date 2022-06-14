using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacShip : MonoBehaviour
{
    [SerializeField]
    float _speedf = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speedf * Time.deltaTime);
    }
}
