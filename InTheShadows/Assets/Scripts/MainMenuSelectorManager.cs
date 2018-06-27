using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelectorManager : MonoBehaviour {


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

	}
}
