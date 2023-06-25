using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private Dialog _textSequence;
    [SerializeField] private Image _image;
    [SerializeField] private Color _backgroundColor;

    public void Update()
    {
        // switch the image sprite to the current cutscene image
        if (_image != null && _textSequence != null)
        {
            _image.sprite = _textSequence.GetCurrentDialogLine().Image;
        } 
        
        // set the default image to match the background color when no cutscene image is available
        if (_image.sprite == null)
        {
            _image.color = _backgroundColor;
        }
        else 
        {
            _image.color = Color.white;
        }
    }
}
