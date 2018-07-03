using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant : MonoBehaviour {

	public CanvasGroup canvasGroup;


	private Vector3 startRotation;
	private Vector3 victoryRotation;

	private bool victory = false;

	// Use this for initialization
	void Start () {
		startRotation = new Vector3 (179.704f, 189.632f, -179.204f);
		victoryRotation = transform.rotation.eulerAngles;
		transform.eulerAngles = startRotation;
		canvasGroup.alpha = 0;
		canvasGroup.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (!victory && Input.GetMouseButton (0)) {
			transform.Rotate (Input.GetAxis ("Mouse Y") * Time.deltaTime * 250, 0, 0, Space.Self);
			checkVictory ();
		} else if (victory) {
			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (victoryRotation), 0.1f);
			if (canvasGroup.alpha < 1) {
				canvasGroup.alpha += Time.deltaTime;
			}
		}
	}

	void checkVictory () {
		float angle = Vector3.Angle (transform.rotation.eulerAngles, victoryRotation);
		Debug.Log (angle);
		if (Mathf.Round (angle) > 0 && Mathf.Round(angle) < 5) {
			Debug.Log ("Victory");
			victory = true;
			canvasGroup.gameObject.SetActive (true);
			Camera.main.GetComponent<Animator> ().SetTrigger ("Victory");
			Player.getInstance ().levelStatus1 = (int)Player.LevelStatus.SUCCESSED;
			Player.getInstance ().levelStatus2 = (int)Player.LevelStatus.AVAILABLE;
			Player.getInstance ().saveDatas ();
		}
	}

}
