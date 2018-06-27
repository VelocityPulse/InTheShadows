using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour {

	public enum MenuScene {
		HOME,
		SELECTOR
	}

	private Animator animator;
	private MenuScene CurrentScene = MenuScene.HOME;

	private bool debugMode = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void goToSelectorScene (bool debugMode) {
		animator.SetTrigger ("LookingSelector");
		this.debugMode = debugMode;
	}

	public void backToHomeScene () {
		animator.SetTrigger ("LookingHome");
		debugMode = false;
	}
}
