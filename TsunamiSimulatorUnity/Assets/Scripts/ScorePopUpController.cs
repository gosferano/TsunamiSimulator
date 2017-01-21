using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopUpController : MonoBehaviour
{
    public  static ScorePopUp popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popupText = Resources.Load<ScorePopUp>("ScorePopUpParent");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        ScorePopUp instance = Instantiate(popupText);
        //Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = location.position; //screenPosition;
        instance.SetText(text);
    }
}
