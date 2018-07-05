using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFormsFortyTwo : MonoBehaviour {

	public enum FormIndex {
		FORM1,
		FORM2
	}

	public FormIndex indexOfForm = FormIndex.FORM1;
	public FortyTwo parent;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnMouseUpAsButton () {
		if (indexOfForm == FormIndex.FORM1) {
			parent.onClickForm1 ();
		} else if (indexOfForm == FormIndex.FORM2) {
			parent.onClickForm2 ();
		}
	}
}
