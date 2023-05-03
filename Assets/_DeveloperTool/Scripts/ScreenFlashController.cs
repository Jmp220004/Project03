using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFlashController : MonoBehaviour
{
    [Header ("Screen Flash Image")]
    [SerializeField] ScreenFlash _screenFlash = null;
    [Header ("Screen Flash Color")]
    [SerializeField] Color _flashColor = Color.red;
    [Header("Screen Flash Seconds")]
    [SerializeField] float _flashSeconds = .25f;
    [Header("Opacity between 0-1")]
    [SerializeField] float _opacity = .5f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _screenFlash.StartFlash(_flashSeconds, _opacity, _flashColor);
        }
    }
}
