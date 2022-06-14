using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    [SerializeField]
    float _growSpeed = 2.0f;
    float blinkStart = 0;
    float blinkLength = 0.2f;
    bool countDown = false;
    int blinkCounter = 0;
    float _spawnStart = 0;
    float _lifeTime = 10.0f;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        _spawnStart = Time.time;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_growSpeed != 0)
            Grow();
        if(countDown && Time.time - blinkStart > blinkLength)
            {
                Blink();
            }

        Debug.Log(_spawnStart);
        if (Time.time - _spawnStart > _lifeTime)
            Destroy(gameObject);
    }

    void Grow()
    {
        int marker = 1;
        float modifier = _growSpeed * Time.deltaTime;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - modifier * 2, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y + modifier, transform.position.z);
        if (transform.position.y > marker)
        {
            _growSpeed = 0;
            countDown = true;
            blinkStart = 0;
        }
            

    }

    void Blink() 
    {
        Debug.Log("Blinked");
        
        if (sprite.color.a != 1)
            sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b, 1);
        else
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.4f);

        blinkCounter++;

        if (blinkCounter > 4)
            {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
            countDown = false;
            GetComponent<BoxCollider2D>().enabled = true;

        }


        blinkStart = Time.time;
        
    }
}
