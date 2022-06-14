using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float x, y, z;
    SpriteRenderer sprite;
    Color color;

    // Start is called before the first frame update
    void Start()
    {


        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.localScale.x > 1.0f)
       {
            transform.Rotate(new Vector3(x, y, z));
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
           sprite.color += new Color(0, 0, 0, 0.01f);
        }
        else 
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            GetComponent<HomingHex>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            this.enabled = false;
        }
        
    }
}
