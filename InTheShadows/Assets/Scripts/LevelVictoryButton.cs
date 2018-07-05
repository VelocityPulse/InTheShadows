using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVictoryButton : MonoBehaviour {

	public enum ButtonIndex {
		BACK,
		CONTINUE
	}

    public Player.LevelID id = Player.LevelID.LEVEL_1;

	public ButtonIndex index = ButtonIndex.BACK;

	// Use this for initialization
	void Start () {
		if (id == Player.LevelID.LEVEL_4 && index == ButtonIndex.CONTINUE)
        {
            enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick() {
        if (index == ButtonIndex.BACK) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        } else if (id == Player.LevelID.LEVEL_1) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Level2");
        }
        else if (id == Player.LevelID.LEVEL_2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
        }
        else if (id == Player.LevelID.LEVEL_3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level4");
        }
    }
}
