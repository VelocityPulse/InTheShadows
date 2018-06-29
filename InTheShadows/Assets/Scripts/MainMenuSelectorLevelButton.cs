using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelectorLevelButton : MonoBehaviour {

	public enum ButtonIndex {
		LEVEL1,
		LEVEL2,
		LEVEL3,
		LEVEL4
	}

	public ButtonIndex index = ButtonIndex.LEVEL1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnMouseDown () {
		Debug.Log (Player.getInstance ().statusLevelFor ((int)index));
		if (Player.getInstance ().statusLevelFor ((int)index) != Player.LevelStatus.UNAVAILABLE) {
			switch (index) {
			case ButtonIndex.LEVEL1:
				UnityEngine.SceneManagement.SceneManager.LoadScene ("Level1");
				break;
			case ButtonIndex.LEVEL2:
				UnityEngine.SceneManagement.SceneManager.LoadScene ("Level2");
				break;
			case ButtonIndex.LEVEL3:
				UnityEngine.SceneManagement.SceneManager.LoadScene ("Level3");
				break;
			case ButtonIndex.LEVEL4:
				UnityEngine.SceneManagement.SceneManager.LoadScene ("Level4");
				break;
			}
		}
	}

}
