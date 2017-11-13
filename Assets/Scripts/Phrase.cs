using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrase : MonoBehaviour {

	public static Phrase Instance;

	public List<Measure> measures;
	public float speed;
	public Vector3 direction = Vector3.left;

	public Fret endFret;

	protected bool isDone = false;

	void Awake () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.B)) {
			Reverse();
		}
	}

	void FixedUpdate(){
		transform.position += direction * speed * Time.fixedDeltaTime;
	}

	public void Reverse(){
		direction = direction * -1;

		foreach(Measure measure in measures) {
			measure.Reverse();
		}

		endFret.transform.localPosition = new Vector3(-endFret.transform.localPosition.x, endFret.transform.localPosition.y, endFret.transform.localPosition.z);

	}
}
