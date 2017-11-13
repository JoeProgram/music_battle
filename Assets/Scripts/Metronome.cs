using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Metronome : MonoBehaviour {

	public GameObject fretPrefab;

	protected Vector3 leftStartingPosition = new Vector3(0,-15,0);
	protected Vector3 leftEndingPosition = new Vector3(0,12.5f,0);
	protected Vector3 rightStartingPosition = new Vector3(0,15,0);
	protected Vector3 rightEndingPosition = new Vector3(0,-12.5f,0);

	public enum PlayerTurn {LEFT_CALL, LEFT_RESPONSE, RIGHT_CALL, RIGHT_RESPONSE};
	protected PlayerTurn playerTurn = PlayerTurn.LEFT_RESPONSE;

	protected float turnTime;
	protected Vector3 leftButtonPosition = new Vector3(0,-10.5f,0);
	protected Vector3 rightButtonPosition = new Vector3(0,10.5f,0);
	protected float fretRotationTime;

	protected float timeBetweenFrets = 0.5f;
	protected float fretsPerSet = 8;
	protected float timeToNextFret;
	protected float remainingFretsInSet;

	// objects to inform of player switch
	protected CharacterSpotlight spotlight;

	// Use this for initialization
	void Start () {

		// calc setup variables
		turnTime = timeBetweenFrets * fretsPerSet;
		CalcFretRotationTime();

		// collect references
		spotlight = GameObject.FindObjectOfType<CharacterSpotlight>();

		// kick it off
		StartNextCall();
	}

	protected void StartNextCall(){
		// switch players
		playerTurn = playerTurn == PlayerTurn.LEFT_RESPONSE ? PlayerTurn.LEFT_CALL : PlayerTurn.RIGHT_CALL;

		timeToNextFret = timeBetweenFrets;
		remainingFretsInSet = fretsPerSet;
	}

	protected void StartNextResponse(){
		playerTurn = playerTurn == PlayerTurn.LEFT_CALL ? PlayerTurn.RIGHT_RESPONSE : PlayerTurn.LEFT_RESPONSE;

		spotlight.MoveToCharacter(playerTurn == PlayerTurn.LEFT_RESPONSE ? PlayerSide.LEFT : PlayerSide.RIGHT); 

		timeToNextFret = timeBetweenFrets * fretsPerSet;
	}

	void FixedUpdate(){


		timeToNextFret -= Time.deltaTime;

		// CALL
		if(playerTurn == PlayerTurn.LEFT_CALL || playerTurn == PlayerTurn.RIGHT_CALL) {
			if(timeToNextFret <= 0) {

				CreateFret();
				remainingFretsInSet -= 1;

				if(remainingFretsInSet > 0) {
					timeToNextFret += timeBetweenFrets;
				} else {
					StartNextResponse();
				}

			}

		// RESPONSE
		} else {
			if(timeToNextFret <= 0) {
				StartNextCall();
			}
		}

	}
		


	protected void CalcFretRotationTime(){
		fretRotationTime = (turnTime/(rightButtonPosition.y - leftButtonPosition.y)) * (rightStartingPosition.y - rightEndingPosition.y); 
	}

	public void CreateFret(){
		GameObject fret = Instantiate(fretPrefab) as GameObject;

		fret.transform.eulerAngles = playerTurn == PlayerTurn.LEFT_CALL ? leftStartingPosition : rightStartingPosition;
		Vector3 endingRotation = playerTurn == PlayerTurn.LEFT_CALL ? leftEndingPosition: rightEndingPosition;
		fret.GetComponent<Fret>().Setup(playerTurn == PlayerTurn.LEFT_CALL ? PlayerSide.LEFT : PlayerSide.RIGHT);

		fret.transform.DORotate(endingRotation, fretRotationTime, RotateMode.Fast).SetEase(Ease.Linear);
	}
}
