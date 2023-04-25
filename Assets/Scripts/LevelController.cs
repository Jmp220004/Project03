using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] ScreenFlash _screenFlash = null;
    [SerializeField] Color _newColor = Color.red;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _screenFlash.StartFlash(.25f, .5f, _newColor);
        }
    }
}
