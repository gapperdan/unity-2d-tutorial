using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {

	[SerializeField] private GameObject targetObject;
	[SerializeField] private string targetMessage;
	[SerializeField] private AudioSource soundSource;
	[SerializeField] private AudioClip startSound;

	public Color highlightColor = Color.cyan;

	public void OnMouseEnter() {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>(); if (sprite != null) {
			sprite.color = highlightColor;
		}
	}

	public void OnMouseExit() {
		//Tint the button when the mouse hovers over it.
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if (sprite != null) {
			sprite.color = Color.white;
		}
	}

	public void OnMouseDown() {
		transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
	}

	public void OnMouseUp(){
		transform.localScale = Vector3.one;
		soundSource.PlayOneShot (startSound);
		if (targetObject != null) {
			targetObject.SendMessage(targetMessage);
		}
	} 
}
