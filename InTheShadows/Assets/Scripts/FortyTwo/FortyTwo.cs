using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortyTwo : MonoBehaviour {
	enum CurrentClicked {
		FOUR,
		TWO
	}

	public CanvasGroup canvasGroup;
	public Transform four;
	public Transform two;
	private Transform current = null;

	private Vector3 victoryRotationFour;
	private Vector3 victoryPositionFour;

	private Vector3 victoryRotationTwo;
	private Vector3 victoryPositionTwo;

	private Vector3 victoryRelativePosition;

	private CurrentClicked currentID = CurrentClicked.FOUR;

	public bool victory = false;

	// Use this for initialization
	void Start () {
		// four
		victoryRotationFour = transform.localRotation.eulerAngles;
		victoryPositionFour = four.localPosition;
		four.eulerAngles = new Vector3 (-10.73f, -26.201f, -180.052f);
		four.localPosition = new Vector3 (7.318865f, -0.04358357f, -3.809745f);

		// two
		victoryRotationTwo = transform.localRotation.eulerAngles;
		victoryPositionTwo = two.localPosition;
		two.eulerAngles = new Vector3 (163.825f, 236.875f, -198.965f);
		two.localPosition = new Vector3 (-7.850225f, 1.035947f, 5.402049f);

		victoryRelativePosition = victoryPositionTwo - victoryPositionFour;

		canvasGroup.alpha = 0;
		canvasGroup.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (!victory) {
			if (Input.GetMouseButton (0) && current != null) {
				if (Input.GetKey (KeyCode.LeftShift)) {
					current.Rotate (0, Input.GetAxis ("Mouse X") * Time.deltaTime * -250, 0, Space.World);
				} else if (Input.GetKey (KeyCode.LeftControl)) {
					current.Translate (Input.GetAxis ("Mouse X") * Time.deltaTime, Input.GetAxis ("Mouse Y") * Time.deltaTime, 0, Space.World);
				} else {
					current.Rotate (Input.GetAxis ("Mouse Y") * Time.deltaTime * 250, 0, 0, Space.World);
				}
				//current.localRotation = Quaternion.Euler(current.localRotation.eulerAngles.x, current.localRotation.eulerAngles.y, 0);
				checkVictory ();
			}
		} else if (victory) {
			four.localRotation = Quaternion.RotateTowards (four.localRotation, Quaternion.Euler (victoryRotationFour), 0.4f);
			two.localRotation = Quaternion.RotateTowards (two.localRotation, Quaternion.Euler (victoryRotationTwo), 0.4f);
			four.localPosition = Vector3.MoveTowards (four.localPosition, victoryPositionFour, 0.1f);
			two.localPosition = Vector3.MoveTowards (two.localPosition, victoryPositionTwo, 0.1f);
			if (canvasGroup.alpha < 1) {
				canvasGroup.alpha += Time.deltaTime;
			}
		}
	}

	void checkVictory () {
		float distFour = Vector3.Distance (four.localRotation.eulerAngles, victoryRotationFour);
		float distTwo = Vector3.Distance (two.localRotation.eulerAngles, victoryRotationTwo);
		float distRelative = Vector3.Distance (two.localPosition - four.localPosition, victoryRelativePosition);
		//Debug.Log("dist four " + distFour);
		//Debug.Log("dist two " + distTwo);
		Debug.Log ("dist rel " + distRelative);

		if (distRelative < 1 &&
			((distFour > 410 && distFour < 520) || (distFour > 310 && distFour < 375)) &&
			(distTwo > 300 && distTwo < 600)) {
			Debug.Log ("Victory");
			victory = true;
			canvasGroup.gameObject.SetActive (true);
			Camera.main.GetComponent<Animator> ().SetTrigger ("Victory");
			Player.getInstance ().levelStatus2 = (int)Player.LevelStatus.SUCCESSED;
			Player.getInstance ().levelStatus3 = (int)Player.LevelStatus.AVAILABLE;
			Player.getInstance ().saveDatas ();
		}
	}

	public void onClickForm1 () {
		currentID = CurrentClicked.FOUR;
		current = four;
	}

	public void onClickForm2 () {
		currentID = CurrentClicked.TWO;
		current = two;
	}
}
