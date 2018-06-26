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

	public void OnPointerDown (PointerEventData eventData) {
		Camera.main.GetComponent<MainMenuCamera> ().goToSelectorScene (debugMode);
	}
}
