﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Player : MonoBehaviour {

    public Vector3 movementVector;
    public bool canTurnUp;
    public bool canTurnDown;
    public bool canTurnLeft;
    public bool canTurnRight;

    public bool lastPressedHorizontalRight;
    public bool lastPressedVerticalDown;
    public bool lastPressedHorizontal;

    public enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }

    public List<Directions> directions;

	// Use this for initialization
	void Start () {
        movementVector = new Vector3(velocity, 0, 0);
        directions.Add(Directions.Up);
        directions.Add(Directions.Down);
        directions.Add(Directions.Left);
        directions.Add(Directions.Right);
        gameObject.tag = "Street";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Input();
        Move();
	}

    void Input()
    {
        if (InputController.moveValueY > 0)
        {
            directions.Remove(Directions.Up);
            directions.Add(Directions.Up);
        }
        else if (InputController.moveValueY < 0)
        {
            directions.Remove(Directions.Down);
            directions.Add(Directions.Down);
        }
        else if (InputController.moveValueX > 0)
        {
            directions.Remove(Directions.Right);
            directions.Add(Directions.Right);
        }
        else if (InputController.moveValueX < 0)
        {
            directions.Remove(Directions.Left);
            directions.Add(Directions.Left);
        }

        foreach (Directions dir in directions.Select(x => x).Reverse())
        {
            if (movementVector.x != 0 && InputController.moveValueY != 0)
            {
                if ((InputController.moveValueY > 0 && canTurnUp) || (InputController.moveValueY < 0 && canTurnDown))
                {
                    movementVector = new Vector3(0, InputController.moveValueY * velocity, 0);
                    transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
                }
            }
            else if (movementVector.y != 0 && InputController.moveValueX != 0 && (canTurnLeft || canTurnRight))
            {
                if ((InputController.moveValueX > 0 && canTurnRight) || (InputController.moveValueX < 0 && canTurnLeft))
                {
                    movementVector = new Vector3(InputController.moveValueX * velocity, 0, 0);
                    transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
                }
            }
        }
    }

    void Move()
    {
        transform.position += movementVector * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Street")
        {
            Street street = collision.gameObject.GetComponent<Street>();
            canTurnRight = street.turnRight;
            canTurnUp = street.turnUp;
            canTurnLeft = street.turnLeft;
            canTurnDown = street.turnDown;
        }

        if (collision.gameObject.tag == "Environment")
        {
            ScorePopUpController.CreateFloatingText(100.ToString(), collision.transform);
        }
        Destroy(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Street")
        {
            canTurnDown = false;
            canTurnUp = false;
            canTurnLeft = false;
            canTurnRight = false;
        }
    }
}
