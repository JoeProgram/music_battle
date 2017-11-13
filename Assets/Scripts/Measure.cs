using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Measure : MonoBehaviour {

	public Fret fret;
	public List<GameObject> beats;
	public List<Note> notes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reverse(){

		transform.localPosition = flipX(transform.localPosition);

		fret.transform.localPosition = flipX(fret.transform.localPosition);

		foreach(GameObject beat in beats) {
			beat.transform.localPosition = flipX(beat.transform.localPosition);
		}

		foreach(Note note in notes) {
			note.transform.localPosition = flipX(note.transform.localPosition);
		}
	}

	protected Vector3 flipX( Vector3 v ){
		return new Vector3(-v.x, v.y, v.z);
	}
}
