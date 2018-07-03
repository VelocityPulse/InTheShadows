using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour {

	public MainMenuSelectorManager mainMenuSelectorManager;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void goToSelectorScene (bool debugMode) {
		animator.SetTrigger ("LookingSelector");
		mainMenuSelectorManager.reloadScene (debugMode);
	}

	public void backToHomeScene () {
        animator.SetTrigger("LookingHome");
	}
}
