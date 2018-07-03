using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tea : MonoBehaviour
{

    public CanvasGroup canvasGroup;

    private Vector3 startRotation;
    private Vector3 victoryRotation;
    private float onClickMousePosy;

    private bool victory = false;

    // Use this for initialization
    void Start()
    {
        startRotation = new Vector3(163.825f, 236.875f, -198.965f);
        victoryRotation = transform.rotation.eulerAngles;
        transform.eulerAngles = startRotation;
        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!victory)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * -250, 0, Space.Self);
                }
                else
                {
                    transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * 250, 0, 0, Space.Self);
                }
                checkVictory();
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            }


        }
        else if (victory)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(victoryRotation), 0.1f);
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
            }
        }
    }

    void checkVictory()
    {
        float dist = Vector3.Distance(transform.rotation.eulerAngles, startRotation);
       // Debug.Log(dist);
       
        if (dist > 260 && dist < 263)
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

}
