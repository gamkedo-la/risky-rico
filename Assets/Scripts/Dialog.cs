using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        StartEnumerator(TypeWritter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator TypeWritter(){
        foreach (char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
        }
    }
}
