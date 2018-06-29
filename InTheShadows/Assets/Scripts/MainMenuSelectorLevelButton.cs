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
		
	}

}
