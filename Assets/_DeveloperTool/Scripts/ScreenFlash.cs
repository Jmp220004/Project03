using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class ScreenFlash : MonoBehaviour
{

    Image _image = null;
    Coroutine _currentFlashroutine = null;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
  
    public void StartFlash(float secondsForFlash, float maxAlpha, Color newColor)
    {
        _image.color = newColor;

        // ensure maxAlpha isn't above 1
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if(_currentFlashroutine != null)
        {
            StopCoroutine(_currentFlashroutine);
        }
        _currentFlashroutine = StartCoroutine(Flash(secondsForFlash, maxAlpha));
    }

    IEnumerator Flash(float secondsForFlash, float maxAlpha)
    {
        // animate flash in
        float flashInDuration = secondsForFlash / 2;
        for(float t = 0; t <= flashInDuration; t += Time.deltaTime)
        {
            Color colorInFrame = _image.color;
            colorInFrame.a = Mathf.Lerp(0, maxAlpha, t/flashInDuration);
            _image.color = colorInFrame;
            yield return null;
        }

        // animate flash out
        float flashOutDuration = secondsForFlash / 2;
        for(float t = 0; t<= flashOutDuration; t += Time.deltaTime)
        {
            Color colorInFrame = _image.color;
            colorInFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
            _image.color = colorInFrame;
            yield return null;
        }

        // ensure alpha is zero
        _image.color = new Color32(0, 0, 0, 0);
    }
}
