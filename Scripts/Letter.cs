using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Letter : MonoBehaviour
{
    string letters = "ABCDEFGHILMNOPQRSTUVWYZ";
    int index = 0;
    [SerializeField]
    public TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeLetter(float dir)
    {
        if (dir < 0 && index < 27)
            index++;
        else if (dir > 0 && index > 0)
            index--;
            
        
        _text.text = letters[index].ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
