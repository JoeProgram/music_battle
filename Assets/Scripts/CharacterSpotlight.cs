using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterSpotlight : MonoBehaviour {

	protected Vector3 leftCharacterPosition = new Vector3(-2.83f,36.2f,-4.95f);
	protected Vector3 rightCharacterPosition = new Vector3(2.83f,36.2f,-4.95f);

	protected float moveTime = 0.5f;

	public void MoveToCharacter( PlayerSide player ){
		Vector3 position = player == PlayerSide.LEFT ? leftCharacterPosition : rightCharacterPosition;
		transform.DOMove(position, moveTime).SetDelay(1f);
	}

}
