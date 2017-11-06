using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles fret detection for all the buttons
public class MusicButtonSet : MonoBehaviour {

	public PlayerSide player;

	protected Fret currentFret;
	protected List<MusicButton> buttons;

	protected void Start(){

		// setup the buttons
		buttons = new List<MusicButton>();
		foreach(MusicButton button in transform.GetComponentsInChildren<MusicButton>()) {
			buttons.Add(button);
		}

	}

	public void SetFret( Fret fret ){
		currentFret = fret;
	}

	public Fret GetFret(){
		return currentFret;
	}

	public void KillFret(){
		if(currentFret != null) {
			currentFret.Kill();

			ClearFret();
		}
	}

	public void ClearFret(){

		currentFret = null;

		foreach(MusicButton button in buttons) {
			button.SetShouldPress(false);
		}
	}

	protected void OnTriggerEnter( Collider other ){
		
		SetFret( other.attachedRigidbody.GetComponent<Fret>() );

		// if it's mine, press any button
		if(currentFret.player == player) {
			foreach(MusicButton button in buttons) {
				button.SetShouldPress(true);
			}
		}
		// if it's theirs, press the correct button
		else {
			foreach(MusicButton button in buttons) {
				if(button.note == currentFret.chosenNote) {
					button.SetShouldPress(true);
				}
			}
		}
	}

	protected void OnTriggerExit( Collider other ){


		if(currentFret) {

			// if it was our fret, delete it.
			if(currentFret.player == player) {
				currentFret.Kill();

			// if it was the other player's fret, you messed up
			} else {
				Player.Players[player].AddMistake();
				KillFret();
			}


		}



	}


}
