using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Player : MonoBehaviour {

    public Vector3 movementVector;
    public bool canTurnUp;
    public bool canTurnDown;
    public bool canTurnLeft;
    public bool canTurnRight;
    public bool moved;

    private LevelManager levelManager;
    public int lives;
    public float health;
    public float damage;

    public enum Directions
    {
        Up = 1,
        Right = 2,
        Left = -2,
        Down = -1
    }

    public List<Directions> directions;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	    lives = 3;
        movementVector = new Vector3(velocity, 0, 0);
        directions.Add(Directions.Up);
        directions.Add(Directions.Down);
        directions.Add(Directions.Left);
        directions.Add(Directions.Right);
        gameObject.tag = "Street";
	    levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        health -= healthDegeneration * Time.fixedDeltaTime;
        if (health <= 0) Die();
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
            if (movementVector.y >= 0 && dir == Directions.Up && canTurnUp && !moved)
            {
                movementVector = new Vector3(0, Mathf.Sign((int)dir) * velocity, 0);
                transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
                moved = true;
                break;
            }
            else if (movementVector.y <= 0 && dir == Directions.Down && canTurnDown && !moved)
            {
                movementVector = new Vector3(0, Mathf.Sign((int)dir) * velocity, 0);
                transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
                moved = true;
                break;
            }
            else if (movementVector.x >= 0 && dir == Directions.Right && canTurnRight && !moved)
            {
                movementVector = new Vector3(Mathf.Sign((int)dir) * velocity, 0, 0);
                transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
                moved = true;
                break;
            }
            else if (movementVector.x <= 0 && dir == Directions.Left && canTurnLeft && !moved)
            {
                movementVector = new Vector3(Mathf.Sign((int)dir) * velocity, 0, 0);
                transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
                moved = true;
                break;
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

        else if (collision.gameObject.tag == "Environment")
        {
            Environment env = collision.gameObject.GetComponent<Environment>();
            Debug.Log("Environment trigger");
            ScorePopUpController.CreateFloatingText(env.points.ToString(), collision.transform);
            damage += env.points;
            if (damage >= maxDamage)
            {
                lives++;
                damage = 0;
            }
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Pickup")
        {
            Pickup pickup = collision.gameObject.GetComponent<Pickup>();
            health += pickup.points;
            health = health > maxHealth ? maxHealth : health;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Street")
        {
            canTurnDown = false;
            canTurnUp = false;
            canTurnLeft = false;
            canTurnRight = false;
            moved = false;
        }
    }

    public void Die()
    {
        lives--;
        if (lives <= 0) levelManager.Lose();
    }
}
