using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFormsGlobe : MonoBehaviour {

   public enum FormIndex
    {
        FORM1,
        FORM2
    }

    public FormIndex indexOfForm = FormIndex.FORM1;
    public Globe parent;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void click ()
    {
        if (indexOfForm == FormIndex.FORM1)
        {
            parent.onClickForm1();
        } else if (indexOfForm == FormIndex.FORM2)
        {
            parent.onClickForm2();
        }
    }
}
