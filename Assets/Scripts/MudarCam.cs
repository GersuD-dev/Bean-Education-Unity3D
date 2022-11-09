using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarCam : MonoBehaviour
{
    public GameObject ObjCam1;
    public GameObject ObjCam2;

    public bool status;

    void Start()
    {
        status = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            status = !status;
        }


        if (!status)
        {
            ObjCam2.GetComponent<Camera>().rect = new Rect(0.0f, -0.5f, 1.0f, 1.0f);

            ObjCam1.GetComponent<Camera>().rect = new Rect(0.0f, 0.5f, 1.0f, 1.0f);
        }
        else
        {
            ObjCam1.GetComponent<Camera>().rect = new Rect(-0.5f, 0.0f, 1.0f, 1.0f);

            ObjCam2.GetComponent<Camera>().rect = new Rect(0.5f, 0.0f, 1.0f, 1.0f);
        }
    }
}