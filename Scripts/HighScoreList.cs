using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreList : MonoBehaviour
{

    int[] scores = new int[5];
    string[] names = new string[5];
    [SerializeField]
    TextMeshProUGUI[] scoreTexts = new TextMeshProUGUI[5];
    [SerializeField]
    TextMeshProUGUI[] nameTexts = new TextMeshProUGUI[5];
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Score1"))
        {
            for (int i = 0; i < 5; i++)
            {

                scoreTexts[i].text = PlayerPrefs.GetInt("Score" + i).ToString();
                nameTexts[i].text = PlayerPrefs.GetString("Name" + i);

            }

        }
        else
        {
            for (int i = 0; i < 5; i++)
            {

                PlayerPrefs.SetInt("Score" + i, 10000);
                PlayerPrefs.SetString("Name" + i, "PAS");

            }

        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
            
        }
    }
}
