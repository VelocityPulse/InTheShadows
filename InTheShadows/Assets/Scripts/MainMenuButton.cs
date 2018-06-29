using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour, UnityEngine.EventSystems.IPointerDownHandler {


	public MainMenuCamera.MenuScene scene = MainMenuCamera.MenuScene.HOME;

	[SerializeField] bool debugMode = false;
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
		if (scene == MainMenuCamera.MenuScene.HOME) {
			Camera.main.GetComponent<MainMenuCamera> ().goToSelectorScene (debugMode);
		} else if (scene == MainMenuCamera.MenuScene.SELECTOR) {
			Camera.main.GetComponent<MainMenuCamera> ().backToHomeScene ();
		}
	}
}
