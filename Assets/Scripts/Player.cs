using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerSide {LEFT, RIGHT};

public class Player : MonoBehaviour {
	
	// which side is this player on?
	public PlayerSide player;
	public Slider healthUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
