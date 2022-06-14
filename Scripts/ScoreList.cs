using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreList : MonoBehaviour
{

    
    public int[] scores = new int[5];
    public string[] names = new string[5];

    private void Start()
    {
        if(PlayerPrefs.HasKey("Score1"))
        {
            for (int i = 0; i < 5; i++)
            {

                scores[i] = PlayerPrefs.GetInt("Score" + i);
                names[i] = PlayerPrefs.GetString("Name" + i);

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

    public int checkScore(int score)
    {
        int position = -1;
        for (int i = 0; i < scores.Length; i++)
        {
            if (score > scores[i])
            {
                position = i;
                break;
            }
        }
        return position;
    }

    

    public void updateScore(int lastScore, string newName)
    {
        int position = checkScore(lastScore);
        
        if(position != -1)
        {
            
            int[] oldScores = new int[scores.Length];
            string[] oldStrings = new string[names.Length];

            for(int i= 0; i < scores.Length;i++)
            {
               
                oldScores[i] = scores[i];
                oldStrings[i] = names[i];
            }

            scores[position] = lastScore;
            names[position] = newName;
            for(int i = position+1; i < oldScores.Length;i++)
            {
                scores[i] = oldScores[i-1];
                names[i] = oldStrings[i-1];
            }
        }

        saveScores();
    }

    void loadScores() {

     }

     void saveScores() {
        for (int i = 0; i < 5; i++)
        {
            
            PlayerPrefs.SetInt("Score" + i, scores[i]);
            PlayerPrefs.SetString("Name" + i, names[i]);

        }

    }

}
