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

	public string buttonName;

	// Use this for initialization
	void Start () {
	
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

		// testing
		if(Input.GetKeyDown(KeyCode.A)) {
			SetShouldPress(!shouldPress);
		}

	}

	protected void SetPressed( bool pressed = true ){
		if(pressed) {
			face.transform.localPosition = faceInPosition;
		} else {
			face.transform.localPosition = faceOutPosition;
		}
	}

	public void SetShouldPress( bool shouldPress = true ){
		this.shouldPress = shouldPress;
		perimeter.GetComponent<Renderer>().material = shouldPress ? perimeterMaterialDoPress : perimeterMaterialDontPress;
	}
}
