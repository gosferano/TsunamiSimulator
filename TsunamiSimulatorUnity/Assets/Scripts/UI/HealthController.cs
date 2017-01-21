using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
    public Image Bar;
    public float MaxHealth = 100f;
    public float CurrentHealth = 0f;
    public float DischargeRate = 2f;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
        InvokeRepeating("DecreaseHealth", 0f, DischargeRate);
	    levelManager = GameObject.FindObjectOfType<LevelManager>();

	}

    public void DecreaseHealth()
    {
        CurrentHealth -= 5f;
        if (CurrentHealth <= 0) levelManager.Lose();
        UpdateHealthBar();
    }

    public void IncreaseHealth()
    {
        CurrentHealth += 5f;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        Bar.fillAmount = CurrentHealth / MaxHealth;
    }
}
