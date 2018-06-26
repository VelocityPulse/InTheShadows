using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightFollowing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 point = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint (10);

		Debug.Log (point);

		transform.LookAt (point);
	}
}
