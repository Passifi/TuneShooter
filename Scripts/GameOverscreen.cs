using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameOverscreen : MonoBehaviour
{
    [SerializeField]
    ScoreList scoreList;
    [SerializeField]
    GameObject _panel;
    [SerializeField]
    Letter letter;
    [SerializeField]
    Letter[] letters = new Letter[3];
    bool highscore;
    int position = 0;
    float lastCall;
    float wait = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        position = scoreList.checkScore(PlayerPrefs.GetInt("currentScore"));
       


        if (position != -1)
        {
            
            _panel.transform.GetChild(0).gameObject.SetActive(true);
            highscore = true;
            
        }
        else
            highscore = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(highscore+"2");
        if (!highscore && Input.anyKeyDown)
            SceneManager.LoadScene(0);
        else if(highscore && Input.anyKeyDown)
        {
          
            string name = "";

            for(int i = 0; i < 3; i++)
            {
                name += letters[i]._text.text;
            }
            int newScore = PlayerPrefs.GetInt("currentScore");
            scoreList.updateScore(newScore, name);
            SceneManager.LoadScene(3);
            
        }
        float _fdirection = Input.GetAxisRaw("Vertical");
        
        letter = EventSystem.current.currentSelectedGameObject.transform.GetComponent<Letter>();
       
        if(Time.time - lastCall > wait)
        {
            letter.changeLetter(_fdirection);
            lastCall = Time.time;
        }    
            
        
    }
}
