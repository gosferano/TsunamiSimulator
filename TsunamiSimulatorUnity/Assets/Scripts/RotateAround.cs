using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public float angle = 0;
    public float speed = (2 * Mathf.PI) / 1; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    public float radius = 1f;
    private float dir = 1;

    private float posX;
    private float posY;

    private void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
    }

    void Update()
    {
        if (Random.Range(0, 100) > 90)
        {
            dir *= -1;
        }
        angle += dir * speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(posX + x, posY + y, transform.position.z);
    }
}
