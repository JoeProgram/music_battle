using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour {

	public GameObject perimeter;
	public GameObject face;

	protected bool shouldPress;

	protected Vector3 faceOutPosition;
	protected static Vector3 faceInPosition = new Vector3(0,0,-0.036f);

	protected Material perimeterMaterialDontPress;
	public Material perimeterMaterialDoPress;

	protected MusicButtonSet buttonSet;
	public string buttonName;
	public PlayerSide player;
	public int note;



	// Use this for initialization
	void Start () {
	
		// find and assign parent
		buttonSet = transform.GetComponentInParent<MusicButtonSet>();

		// grab default values that we'll need to restore later
		perimeterMaterialDontPress = perimeter.GetComponent<Renderer>().material;
		faceOutPosition = face.transform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown(buttonName)) {
			SetPressed(true);	
		} else if(Input.GetButtonUp(buttonName)) {
			SetPressed(false);
		}

	}

	protected void SetPressed( bool pressed = true ){
		
		if(pressed) {
			face.transform.localPosition = faceInPosition;

			if(shouldPress) {

				// if it's our fret, assign a button
				if(buttonSet.GetFret().player == player) {
					buttonSet.GetFret().SetNote(note);
				}
				// otherwise, just clear it
				else {
					buttonSet.ClearFret();
				}

			} else {
				Player.Players[player].AddMistake();
			}
				
			buttonSet.ClearFret();

		} else {
			face.transform.localPosition = faceOutPosition;
		}
	}

	public void SetShouldPress( bool shouldPress = true ){
		this.shouldPress = shouldPress;
		perimeter.GetComponent<Renderer>().material = shouldPress ? perimeterMaterialDoPress : perimeterMaterialDontPress;
	}
		
}
