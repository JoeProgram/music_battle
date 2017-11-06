using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum PlayerSide {LEFT, RIGHT};

public class Player : MonoBehaviour {
	
	// which side is this player on?
	public PlayerSide player;
	public Slider healthUI;

	protected int maxHealth = 100;
	protected int health;
	protected int hurt = 10;

	public static Dictionary<PlayerSide, Player> Players = new Dictionary<PlayerSide, Player>();

	// Use this for initialization
	void Start () {

		Player.Players[player] = this;
		health = maxHealth;

	}

	public void AddMistake(){
		health -= hurt;
		healthUI.value = health * 1.0f / maxHealth;
		if(health <= 0) {
			Kill();
		}
	}

	protected void Kill(){
		transform.DOMoveY(20, 1).SetEase(Ease.InBack);
	}
}
