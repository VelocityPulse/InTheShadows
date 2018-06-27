using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelectorManager : MonoBehaviour {

	public Color32 colorUnavailable = new Color32 { r = 0xff, g = 0x81, b = 0x81 };// 0xFF8181
	public Color32 colorAvailable = new Color32 { r = 0xff, g = 0xff, b = 0xff };// 0xFFFFFF
	public Color32 colorSuccessed = new Color32 { r = 0x72, g = 0xff, b = 0x79 };// 0X72FF79


	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;

	private Light light1;
	private Light light2;
	private Light light3;
	private Light light4;


	// Use this for initialization
	void Start () {
		light1 = level1.GetComponentInChildren<Light> ();
		light2 = level2.GetComponentInChildren<Light> ();
		light3 = level3.GetComponentInChildren<Light> ();
		light4 = level4.GetComponentInChildren<Light> ();
	}

	// Update is called once per frame
	void Update () {
		//light1.color = ColorUtility.
	}

	public void reloadScene (bool debugMode) {
		Player p = Player.getInstance ();
		if (debugMode) {
			p.loadDebugDatas ();
		} else {
			p.reloadDatas ();
		}

		if (p.levelStatus1 == (int)Player.LevelStatus.AVAILABLE) {
			light1.color = colorAvailable;
		} else if (p.levelStatus1 == (int)Player.LevelStatus.UNAVAILABLE) {
			light1.color = colorUnavailable;
		} else if (p.levelStatus1 == (int)Player.LevelStatus.SUCCESSED) {
			light1.color = colorSuccessed;
		}

		if (p.levelStatus2 == (int)Player.LevelStatus.AVAILABLE) {
			light2.color = colorAvailable;
		} else if (p.levelStatus2 == (int)Player.LevelStatus.UNAVAILABLE) {
			light2.color = colorUnavailable;
		} else if (p.levelStatus2 == (int)Player.LevelStatus.SUCCESSED) {
			light2.color = colorSuccessed;
		}

		if (p.levelStatus3 == (int)Player.LevelStatus.AVAILABLE) {
			light3.color = colorAvailable;
		} else if (p.levelStatus3 == (int)Player.LevelStatus.UNAVAILABLE) {
			light3.color = colorUnavailable;
		} else if (p.levelStatus3 == (int)Player.LevelStatus.SUCCESSED) {
			light3.color = colorSuccessed;
		}

		if (p.levelStatus4 == (int)Player.LevelStatus.AVAILABLE) {
			light4.color = colorAvailable;
		} else if (p.levelStatus4 == (int)Player.LevelStatus.UNAVAILABLE) {
			light4.color = colorUnavailable;
		} else if (p.levelStatus4 == (int)Player.LevelStatus.SUCCESSED) {
			light4.color = colorSuccessed;
		}
	}

}
