using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    const float screenX = 9f;
    const float screenY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Mathf.Abs(transform.position.x) > screenX || Mathf.Abs(transform.position.y ) > screenY)
            {
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);

        }
        
    }
}
