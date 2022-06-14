using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    AudioSource _laserSfx;
    [SerializeField]
    ParticleSystem _explosion;

    [SerializeField]
    float _fRotationSpeed;
    [SerializeField]
    float _fMovementSpeed;
    // Shot _stdShot;
    float _fXAxis = 0;
    float _fYAxis = 0;
    float _fRotation = 0;
    [SerializeField]
    float _fpauseTime;
    float time;
    [SerializeField]
    Projectile _stdShot;
    float _spawnTime;
    float invulFrames = 1.5f;
    public bool test = false;
    bool vulnurable = false;
    public bool mouseOn = true;
    [SerializeField]
    Bomb _bombPrefab;
    public float _bombCountDown = 100;


    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        _spawnTime = Time.time;
        _laserSfx = GetComponent<AudioSource>();
        time = Time.time;
        vulnurable = false;
        sprite = transform.GetChild(0).transform.GetChild(0).transform.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if(_bombCountDown < 100)
        {
            _bombCountDown += 1 * Time.deltaTime;
        }
        _fXAxis = Input.GetAxisRaw("Horizontal");
        _fYAxis = Input.GetAxisRaw("Vertical");
        _fRotation = Input.GetAxisRaw("Joy2X");
        
        if((Input.GetAxisRaw("Right Trigger") > 0.1 )  && Time.time - time > _fpauseTime)
        {
            Shoot();
            time = Time.time;
        }
        if(Input.GetAxisRaw("Bomb") >0 && _bombCountDown >= 100)
        {
            triggerBomb();
        }
        if(mouseOn)
        {
            MouseRotate();
        }
        MoveShip();
        if(Time.time - _spawnTime < invulFrames)
        {
            if ((Time.time * 10) % 10 != 0)
            {
                
                sprite.enabled = !sprite.enabled;
            }

                
                
        }
        else 
        {
            sprite.enabled = true;
            vulnurable = true;
        }

    }

    void Shoot() 
    {
        
        Projectile _buf = Instantiate(_stdShot, transform.position, transform.GetChild(0).transform.rotation);
        _laserSfx.Play();
       
        
    }

    void MouseRotate()
    {   
        Vector3 baseVector = (transform.GetChild(0).transform.rotation * Vector3.up);
        
        Vector3 targetVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        targetVector = new Vector3(targetVector.x, targetVector.y, 0);
        

        transform.GetChild(0).transform.up = targetVector - baseVector;
        

    }

    void triggerBomb()
    {
        Instantiate(_bombPrefab, transform.position, Quaternion.identity);
        _bombCountDown = 0;
    }

    void MoveShip() 
    {
        if(Mathf.Abs(transform.position.y) > 4.5)
        {
            if (transform.position.y > 0 && _fYAxis > 0)
                _fYAxis = 0;
            else if (transform.position.y < 0 && _fYAxis < 0)
                _fYAxis = 0;



        }
        if (Mathf.Abs(transform.position.x) > 8.5)
        {
            if (transform.position.x > 0 && _fXAxis > 0)
                _fXAxis = 0;
            else if (transform.position.x < 0 && _fXAxis < 0)
                _fXAxis = 0;



        }
        transform.Translate(new Vector3(_fXAxis * _fMovementSpeed * Time.deltaTime, _fYAxis * _fMovementSpeed * Time.deltaTime, 0));
        
        transform.GetChild(0).transform.Rotate(new Vector3(0, 0, _fRotation*_fRotationSpeed*Time.deltaTime));
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(vulnurable && collision.gameObject.tag =="Enemy" && !test)
        {
            ParticleSystem _exp = Instantiate(_explosion, transform.position, Quaternion.identity);
            _exp.Play();
            Destroy(gameObject);
        }
            
            
    }
}
