using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Neck : MonoBehaviour {

	public static Neck Instance;

	void Awake(){
		Instance = this;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)) {
			Flip();
		}
	}

	public void Flip(){
		transform.DORotate(transform.eulerAngles + Vector3.right * 180, 0.5f);
	}
}
