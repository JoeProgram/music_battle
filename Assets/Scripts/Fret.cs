using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fret : MonoBehaviour {



	protected void Awake(){
		
	}


	public void Kill(){
		transform.position += Vector3.down * 1000;
		Destroy(this.gameObject, 0.05f);
	}


}
