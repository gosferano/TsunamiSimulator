using UnityEngine;
using System.Collections;

public class InputController : Singleton<InputController>
{

    public static float moveValue;
    public static float jumpValue;
    public static float slamValue;
    public static float exitValue;

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

        moveValue = 0;
        jumpValue = 0;
        slamValue = 0;

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            moveValue = Input.GetAxis("Horizontal");
            if (Input.GetAxis("Jump") > 0) jumpValue = 1;
            if (Input.GetAxis("Slam") > 0) slamValue = 1;
        }
    }
}
