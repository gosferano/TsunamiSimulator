using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour {

    public Vector3 movementVector;

	// Use this for initialization
	void Start () {
        movementVector = new Vector2(velocity, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Input();
        Move();
        Debug.Log(movementVector);
	}

    void Input()
    {
        if (movementVector.x != 0 && InputController.moveValueY != 0)
        {
            movementVector = new Vector2(0, InputController.moveValueY * velocity);
        }
        else if (movementVector.y != 0 && InputController.moveValueX != 0)
        {
            movementVector = new Vector2(InputController.moveValueX * velocity, 0);
        }
    }

    void Move()
    {
        transform.position += movementVector;
    }
}
