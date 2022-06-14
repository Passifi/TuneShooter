using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static float _score = 0;
    int[] _scoreField = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    float multiplier = 1.0f;

    [SerializeField]
    GameObject continueB;

    int _liveCounter = 1;
    [SerializeField]
    Player _playerPrefab;
    Player _player;
    Vector3 _playPos;
    int _lives = 3;
    [SerializeField]
    Text _livesTxt;
    [SerializeField]
    Text _scoreTxt;
    [SerializeField]
    Image _bombBar;
    float _countDown = 0;
    public float extraLiveScore = 100000;
    [SerializeField]
    Text _pause;
    [SerializeField]
    GameObject panel;
    // Start is called before the first frame update
    void Start()
    { 
        _player = FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            _countDown = _player._bombCountDown;
            _bombBar.rectTransform.localScale = new Vector3(_countDown / 100, 1, 1);
            CheckPlayerStatus();
            updateScore();

            

        }
        else 
        {
            if(Input.GetButtonDown("Fire1") && EventSystem.current.currentSelectedGameObject.gameObject.transform.tag == "continue")
            {
                PauseGame();
            }
            else if(Input.GetButtonDown("Fire1"))
            {
                ExitGame();
            }
        }

        if (Input.GetButtonDown("Start"))
        {
            PauseGame();
        }
    }

    void CheckPlayerStatus() // if player oject is alive and kicking saves last position of the plaser object otherwise respawns on button press if enough lives 
    // are left over 
    // TODO:
    //      Shoudl also destroy all objects on screen and trigger invulFrames after respawn 
    {
        if (_player != null)
        {
            _playPos = _player.transform.position;
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && _lives > 0)
            {
                _player = Instantiate(_playerPrefab, _playPos, Quaternion.identity);
                _player._bombCountDown = _countDown;
                _lives -= 1;
                multiplier = 1.0f;
                updateLives();
            }
            if (_lives <= 0)
            {
                // pass score to ScoreList
                // call gameoverScreen
                SceneManager.LoadScene(2);
            }
        }

    }

    public void addScore(float _points) 
    {
        _score += _points * multiplier;
        multiplier += 0.01f;
    }

    void updateScore() 
    {
        float _tmpBuffer = _score;
        int _counter = 0;
        _scoreTxt.text = "Score: ";
        while(_tmpBuffer > 1)
        {
            _tmpBuffer = _tmpBuffer * 0.1f;
            _counter++;
        }
        Debug.Log(_counter);
        for(int i = 0; i < 11-_counter; i++) 
        {
            _scoreTxt.text += "0";
        }
        if(_score > 1)
            _scoreTxt.text += ((int)_score).ToString();
        if(_score > extraLiveScore*_liveCounter)
        {
            _lives++;
            updateLives();
            _liveCounter *= 2;
        }

        PlayerPrefs.SetInt("currentScore", (int)_score);
        
    }

    
    void updateLives() 

    {
        _livesTxt.text = "Lives: " + _lives.ToString() + "x"; 
        
    }


    void PauseGame() 
    {
        
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(continueB);
        }
        else 
        {
            Time.timeScale = 1;
            panel.SetActive(false);
        }


    }

    void ExitGame() 
    {
        SceneManager.LoadScene(0);
    }

    
}
