using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : MonoBehaviour {
	enum CurrentClicked {
		GLOBE,
		BODY
	}

	public CanvasGroup canvasGroup;
	public Transform globe;
	public Transform body;
	private Transform current = null;

	private Vector3 victoryRotationGlobe;
	private Vector3 victoryPositionGlobe;

	private Vector3 victoryRotationBody;
	private Vector3 victoryPositionBody;

	private Vector3 victoryRelativePosition;

	private CurrentClicked currentID = CurrentClicked.GLOBE;

	public bool victory = false;

	// Use this for initialization
	void Start () {
		// globe
		// TODO BIG ERROR HERE : using of transform instead body or globe
		victoryRotationGlobe = transform.localRotation.eulerAngles;
		victoryPositionGlobe = globe.localPosition;
		globe.eulerAngles = new Vector3 (-10.73f, -26.201f, -180.052f);
		globe.localPosition = new Vector3 (7.318865f, -0.04358357f, -3.809745f);

		// body
		victoryRotationBody = transform.localRotation.eulerAngles;
		victoryPositionBody = body.localPosition;
		body.eulerAngles = new Vector3 (163.825f, 236.875f, -198.965f);
		body.localPosition = new Vector3 (-7.850225f, 1.035947f, 5.402049f);

		// USELESS TO REMOVE
		victoryRelativePosition = victoryPositionBody - victoryPositionGlobe;


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
			globe.localRotation = Quaternion.RotateTowards (globe.localRotation, Quaternion.Euler (victoryRotationGlobe), 0.4f);
			body.localRotation = Quaternion.RotateTowards (body.localRotation, Quaternion.Euler (victoryRotationBody), 0.4f);
			globe.localPosition = Vector3.MoveTowards (globe.localPosition, victoryPositionGlobe, 0.1f);
			body.localPosition = Vector3.MoveTowards (body.localPosition, victoryPositionBody, 0.1f);
			if (canvasGroup.alpha < 1) {
				canvasGroup.alpha += Time.deltaTime;
			}
		}
	}

	void checkVictory () {
		float distGlobe = Vector3.Distance (globe.localRotation.eulerAngles, victoryRotationGlobe);
		float distBody = Vector3.Distance (body.localRotation.eulerAngles, victoryRotationBody);
		float distRelative = Vector3.Distance (body.localPosition - victoryPositionBody, globe.localPosition - victoryPositionGlobe);
		//Debug.Log("dist globe " + distGlobe);
		//Debug.Log("dist body " + distBody);
		Debug.Log ("dist rel " + distRelative);

		if (distRelative < 1 &&
			((distGlobe > 410 && distGlobe < 520) || (distGlobe > 310 && distGlobe < 375)) &&
			(distBody > 300 && distBody < 600)) {
			Debug.Log ("Victory");
			victory = true;
			canvasGroup.gameObject.SetActive (true);
			Camera.main.GetComponent<Animator> ().SetTrigger ("Victory");
			Player.getInstance ().levelStatus3 = (int)Player.LevelStatus.SUCCESSED;
			Player.getInstance ().levelStatus4 = (int)Player.LevelStatus.AVAILABLE;
			Player.getInstance ().saveDatas ();
		}
	}

	public void onClickForm1 () {
		currentID = CurrentClicked.GLOBE;
		current = globe;
	}

	public void onClickForm2 () {
		currentID = CurrentClicked.BODY;
		current = body;
	}
}
