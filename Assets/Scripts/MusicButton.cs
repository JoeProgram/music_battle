using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour {

	public GameObject perimeter;
	public GameObject face;

	protected Material perimeterMaterialDontPress;
	public Material perimeterMaterialDoPress;

	public string mAxis;

	// Use this for initialization
	void Start () {
	
		perimeterMaterialDontPress = perimeter.GetComponent<Renderer>().material;

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Top")) {
			Debug.Log("Top Pressed");
		} else if(Input.GetButtonDown("Middle")) {
			Debug.Log("Middle Pressed");
		} else if(Input.GetButtonDown("Bottom")) {
			Debug.Log("Bottom Pressed");
		}

	}
}
