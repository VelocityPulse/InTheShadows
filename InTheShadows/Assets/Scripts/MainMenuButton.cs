using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour, UnityEngine.EventSystems.IPointerDownHandler {

	public bool debugMode = false;
	private UnityEngine.UI.Selectable selectable;

	// Use this for initialization
	void Start () {
		selectable = GetComponent<UnityEngine.UI.Selectable> ();
	}

	// Update is called once per frame
	void Update () {
		//selectable.OnPointerEnter ()


	}

	public void OnPointerEnter (PointerEventData eventData) {
		Debug.Log ("The cursor entered the selectable UI element.");
	}

	private void OnMouseDown () {
		Debug.Log ("down");
	}

	public void OnPointerDown (PointerEventData eventData) {
		Debug.Log ("Click");
	}
}
