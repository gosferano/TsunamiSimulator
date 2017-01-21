using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
    public Image Bar;
    public float MaxHealth = 100f;
    public float CurrentHealth = 0f;
    
	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
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
