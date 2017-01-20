using UnityEngine;
using System.Collections;

public class InputController : Singleton<InputController>
{

    public static float moveValueX;
    public static float moveValueY;
    public static float exitValue;
    public static float moveTreshold = 0.25f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        computeInput();
    }

    void computeInput()
    {
        exitValue = 0;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitValue = 1;
        }

        moveValueX = 0;
        moveValueY = 0;

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            moveValueX = Input.GetAxis("Horizontal") > moveTreshold ? 1 : Input.GetAxis("Horizontal") < moveTreshold ? -1 : 0;
            moveValueY = Input.GetAxis("Vertical") > moveTreshold ? 1 : Input.GetAxis("Vertical") < moveTreshold  ? -1 : 0;
            //Debug.Log(moveValueX + " " + moveValueY);
        }
    }
}
