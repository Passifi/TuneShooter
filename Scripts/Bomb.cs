using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    CircleCollider2D circle;
    SpriteRenderer sprite;
    Transform spriteShape;
    // Start is called before the first frame update
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        sprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        spriteShape = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        circle.radius += 0.2f;
        //sprite.color.a += 0.1f;
        spriteShape.localScale += new Vector3(1f, 1f, 0);
        if (circle.radius > 10)
            Destroy(gameObject);
    }
}
