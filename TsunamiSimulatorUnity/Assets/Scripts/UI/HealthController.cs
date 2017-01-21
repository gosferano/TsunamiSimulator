using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
    public Image Bar;
    public float MaxHealth = 100f;
    public float CurrentHealth = 0f;
    public float DischargeRate = 2f;
    
	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
        InvokeRepeating("DecreaseHealth", 0f, DischargeRate);
	}

    public void DecreaseHealth()
    {
        CurrentHealth -= 5f;
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
