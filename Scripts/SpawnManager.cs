using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    float _difficultyBuffer = 1.0f;
    [SerializeField]
    float _difficulty = 1.0f;
    int _numberEnemiesSpawned = 0;
    [SerializeField]
    Enemy _square;
    [SerializeField]
    GameObject[] enemies; 
    GameObject[] _spawnPoints;
    float _lastSpawn;
    [SerializeField]
    float _spawnBreak;
    GameObject pacuPacu;
    [SerializeField]
    float _diffModifier;
    public int _enemyCounter = 0;
    float _barrierTimer = 0;
    float _barrierBreak = 20.0f;
    [SerializeField]
    int maxEnemies = 4;
    [SerializeField]
    float pacuThershold = 1.7f;
    [SerializeField]
    float barrierThreshHold = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        _barrierTimer = Time.time;
        int _numSp = transform.childCount;
        _spawnPoints = new GameObject[_numSp];
        
        for(int i = 0; i < _numSp;i++)
        {
            _spawnPoints[i] = gameObject.transform.GetChild(i).gameObject;

        }

        _lastSpawn = Time.time;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_difficulty > 2*_difficultyBuffer)
        {
            float tmpBuffer = _difficultyBuffer;
            _difficultyBuffer = _difficulty;
            _difficulty = tmpBuffer;

        }
        int selection = Random.Range(0, 12);
        _difficulty += _diffModifier * Time.deltaTime;
        if(Time.time - _lastSpawn > _spawnBreak && _enemyCounter< (maxEnemies+_difficulty))
        {
            _enemyCounter++;
            Vector3 _spawnPoint = new Vector3(_spawnPoints[selection].transform.position.x+(Random.Range(-.2f,.2f)), _spawnPoints[selection].transform.position.y+(Random.Range(-1.5f, 1.5f)), 0); 
            Enemy tmpenemy = Instantiate(_square, _spawnPoint, Quaternion.identity);
            tmpenemy._fSpeed *= Random.Range(0.5f, 1.0f + ((int)_difficulty & 4));
            _lastSpawn = Time.time;
            if (Random.Range(0, 120 - _difficulty * Mathf.Pow(10,_difficulty))  <= 4)
                {
                _enemyCounter++;
                Instantiate(enemies[0], new Vector3(Random.Range(-4, 4), Random.Range(-5, 5), 0), Quaternion.identity);
            }

            
            
        }

        if (_difficulty > pacuThershold && pacuPacu == null)
        {

            if (Random.Range(0, 2000 - _difficulty) <= 4)
                pacuPacu = Instantiate(enemies[1], new Vector3(Random.Range(-4, 4), Random.Range(-5, 5), 0), Quaternion.identity);
        }

        if(_difficulty > barrierThreshHold && Time.time - _barrierTimer > _barrierBreak)
        {
            Instantiate(enemies[2], new Vector3(Random.Range(-2, 2), -7, 0), Quaternion.identity);
            _barrierTimer = Time.time;
            _barrierBreak += -0.1f;
        }


    }
}
