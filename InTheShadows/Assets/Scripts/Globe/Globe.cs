using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : MonoBehaviour
{
    enum CurrentClicked
    {
        GLOBE,
        BODY
    }

    public CanvasGroup canvasGroup;
    public Transform globe;
    public Transform body;
    private Transform current = null;

    private Vector3 startRotationGlobe;
    private Vector3 victoryRotationGlobe;

    private Vector3 startRotationBody;
    private Vector3 victoryRotationBody;

    private CurrentClicked currentID = CurrentClicked.GLOBE;

    private bool victory = false;

    // Use this for initialization
    void Start()
    {
        // globe
        startRotationGlobe = new Vector3(163.825f, 236.875f, -198.965f);
        victoryRotationGlobe = transform.rotation.eulerAngles;
        globe.eulerAngles = startRotationGlobe;

        // body
        startRotationBody = new Vector3(163.825f, 236.875f, -198.965f);
        victoryRotationBody = transform.rotation.eulerAngles;
        body.eulerAngles = startRotationBody;


        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!victory)
        {
            if (Input.GetMouseButton(0) && current != null)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * -250, 0, Space.Self);
                }
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    transform.Translate (Input.GetAxis("Mouse Y") * Time.deltaTime * 250, Input.GetAxis("Mouse X") * Time.deltaTime * -250, 0, Space.Self);
                }
                else
                {
                    transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * 250, 0, 0, Space.Self);
                }

            }
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            checkVictory();
        }
        else if (victory)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(victoryRotationGlobe), 0.1f);
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
            }
        }
    }

    void checkVictory()
    {
        float dist = Vector3.Distance(transform.rotation.eulerAngles, victoryRotationGlobe);
        //Debug.Log(dist);

        if (dist > 0 && dist < 3)
        {
            Debug.Log("Victory");
            victory = true;
            canvasGroup.gameObject.SetActive(true);
            Camera.main.GetComponent<Animator>().SetTrigger("Victory");
            Player.getInstance().levelStatus2 = (int)Player.LevelStatus.SUCCESSED;
            Player.getInstance().levelStatus3 = (int)Player.LevelStatus.AVAILABLE;
            Player.getInstance().saveDatas();
        }
    }

    public void onClickForm1()
    {
        Debug.Log("click1");
        currentID = CurrentClicked.GLOBE;
        current = globe;
    }

    public void onClickForm2()
    {
        Debug.Log("click2");
        currentID = CurrentClicked.BODY;
        current = body;
    }
}
