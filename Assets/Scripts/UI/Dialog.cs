using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialog : MonoBehaviour
{
    [Header("INPUT")]
    [SerializeField] private PlayerInput _input;
    
    [Header("CONTENT")]
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;

    [Header("SETTINGS")]
    [Tooltip("Select a speed setting for the text typewriter (higher number = faster text)")]
    [Range(1, 10)]
    public int typingSpeed;

    IEnumerator typingCoroutine;
    
    void Start()
    {
        typingCoroutine = TypeWriter();
        StartCoroutine(typingCoroutine);
    }

    void Update()
    {
        string currentSentence = sentences[index];

        if (_input.actions["interact"].triggered && textDisplay.text != currentSentence)
        {
            StopCoroutine(typingCoroutine);
            AutoCompleteSentence();
        }
        else if (_input.actions["interact"].triggered && textDisplay.text == currentSentence)
        {
            MoveToNextSentence();
            typingCoroutine = TypeWriter();
            StartCoroutine(typingCoroutine);
        }
    }

    IEnumerator TypeWriter()
    {
        string currentSentence = sentences[index];
        char[] currentSentenceCharacters = currentSentence.ToCharArray();
        int characterIndex = 0;

        if (textDisplay.text != currentSentence)
        {
            while(characterIndex <= currentSentenceCharacters.Length - 1)
            {
                char currentCharacter = currentSentenceCharacters[characterIndex];
                string textToDisplay = currentSentence.Substring(0, characterIndex + 1);

                if (currentCharacter.ToString() == " " && characterIndex + 1 <= currentSentenceCharacters.Length - 1)
                {
                    textToDisplay += currentSentenceCharacters[characterIndex + 1];
                    characterIndex += 1;
                }

                textToDisplay += "<color=#000000>" + currentSentence.Substring(characterIndex) + "</color>";

                textDisplay.text = textToDisplay;

                characterIndex += 1;

                yield return new WaitForSeconds(1f/(float)typingSpeed);
            }
        }
    }

    void AutoCompleteSentence()
    {
        if (textDisplay.text != sentences[index])
        {
            textDisplay.text = sentences[index];
        }
    }

    void MoveToNextSentence()
    {
        index += 1;

        if (index > sentences.Length - 1)
        {
            index = sentences.Length - 1;
            return;
        }
    
        textDisplay.text = "";
    }
}
