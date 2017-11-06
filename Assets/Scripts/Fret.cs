using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fret : MonoBehaviour {

	public PlayerSide player;

	public GameObject[] notes;
	public int chosenNote = -1;

	protected void Awake(){
		foreach(GameObject note in notes) {
			note.SetActive(false);
		}
	}

	public void Setup( PlayerSide player ){
		this.player = player;
	}

	public void SetNote( int note ){
		chosenNote = note;
		notes[note].SetActive(true);
	}

	// see if the note we pressed matches the note assigned
	public bool IsCorrectNote( int note ){
		return note == chosenNote;
	}

	public void Kill(){
		transform.position += Vector3.down * 1000;
		Destroy(this.gameObject, 0.05f);
	}


}
