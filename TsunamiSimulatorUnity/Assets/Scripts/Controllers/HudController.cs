using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

    public Player player;
    public Image healthBarImage;
    public Image damageBarImage;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        healthBarImage = GameObject.Find("HealthBarImage").GetComponent<Image>();
        damageBarImage = GameObject.Find("DamageBarImage").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        healthBarImage.fillAmount = player.health / Player.maxHealth;
        damageBarImage.fillAmount = player.damage / Player.maxDamage;
	}
}
