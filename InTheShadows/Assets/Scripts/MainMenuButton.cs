using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour {

	public enum ButtonIndex {
		START,
		DEBUG,
		SELECTOR_BACK,
		RESET
	}

	public ButtonIndex index = ButtonIndex.START;
	private UnityEngine.UI.Selectable selectable;

	// Use this for initialization
	void Start () {
		selectable = GetComponent<UnityEngine.UI.Selectable> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClick () {
		if (index == ButtonIndex.START) {
			Camera.main.GetComponent<MainMenuCamera> ().goToSelectorScene (false);
		} else if (index == ButtonIndex.DEBUG) {
			Camera.main.GetComponent<MainMenuCamera> ().goToSelectorScene (true);
		}else if (index == ButtonIndex.SELECTOR_BACK) {
			Camera.main.GetComponent<MainMenuCamera> ().backToHomeScene ();
		} else if (index == ButtonIndex.RESET) {
			Debug.Log ("Click");
			Player.getInstance ().initDataToDefault ();
			Player.getInstance ().reloadDatas ();
		}
	}
}
