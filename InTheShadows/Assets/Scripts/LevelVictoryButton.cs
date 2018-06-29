using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVictoryButton : MonoBehaviour {

	public enum ButtonIndex {
		BACK,
		CONTINUE
	}

	public ButtonIndex index = ButtonIndex.BACK;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick() {
		if (index == ButtonIndex.BACK) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenu");
		} else {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Level2");
		}
	}

}
