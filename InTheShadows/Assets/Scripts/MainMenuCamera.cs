﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour {

	enum MenuScene {
		HOME,
		SELECTOR
	}

	private Animator animator;
	private MenuScene scene = MenuScene.HOME;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void goToSelectorScene (bool debugMode) {
		animator.SetTrigger ("LookingSelector");
	}

	public void backToHomeScene () {
		animator.SetTrigger ("LookingHome");
	}

}
