using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles fret detection for all the buttons
public class MusicButtonSet : MonoBehaviour {

	public PlayerSide player;

	protected Fret currentFret;
	protected List<MusicButton> buttons;

	public AudioClip sfxBeat;

	protected void Start(){

		// setup the buttons
		buttons = new List<MusicButton>();
		foreach(MusicButton button in transform.GetComponentsInChildren<MusicButton>()) {
			buttons.Add(button);
		}

	}

	protected void OnTriggerEnter( Collider other ){

		if(other.CompareTag("beat")) {
			AudioSource.PlayClipAtPoint(sfxBeat, Camera.main.transform.position);

		
		} else if(other.CompareTag("end")) {
			Neck.Instance.Flip();
			Phrase.Instance.Reverse();
		}

		//foreach( MusicButton button in buttons ){
		//	button.SetShouldPress(true);
		//}
	}

	protected void OnTriggerExit( Collider other ){

		foreach( MusicButton button in buttons ){
			button.SetShouldPress(false);
		}
	}


}
