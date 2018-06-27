using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelectorManager : MonoBehaviour {

	public Color32 colorUnavailable =	new Color32 { r = 0xff, g = 0x81, b = 0x81 };// 0xFF8181
	public Color32 colorAvailable =	new Color32 { r = 0xff, g = 0xff, b = 0xff };// 0xFFFFFF
	public Color32 colorSuccessed =	new Color32 { r = 0x72, g = 0xff, b = 0x79 };// 0X72FF79


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
		light1 = level1.GetComponent<Light> ();
		light2 = level1.GetComponent<Light> ();
		light3 = level1.GetComponent<Light> ();
		light4 = level1.GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () {
		//light1.color = ColorUtility.
	}

	public void reloadScene () {

	}

}
