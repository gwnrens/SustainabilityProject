using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_System : MonoBehaviour
{
    public Camera camera_Bedroom;
    public Camera camera_LivingRoom;
    public Camera camera_Kitchen;
    public Camera camera_Entrance;
    public Camera camera_Bathroom;
    public Camera camera_Roof;
    public Camera camera_Gate;

    protected Camera[] cameras;

    protected int currentCamera;

    void Start()
    {
        Array();

        currentCamera = 0;
        EnableCurrentCamera();
    }

    void Array()
    {
        cameras = new Camera[7];

        cameras[0] = camera_Bedroom;
        cameras[1] = camera_LivingRoom;
        cameras[2] = camera_Kitchen;
        cameras[3] = camera_Entrance;
        cameras[4] = camera_Bathroom;
        cameras[5] = camera_Roof;
        cameras[6] = camera_Gate;
    }

    void EnableCurrentCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == currentCamera)
            {
                cameras[i].enabled = true;
                cameras[i].GetComponent<AudioListener>().enabled = true;
            }
            else
            {
                cameras[i].enabled = false;
                cameras[i].GetComponent<AudioListener>().enabled = false;
            }
        }
    }

    void NextCamera()
    {
        cameras[currentCamera].GetComponent<AudioListener>().enabled = false;
        cameras[currentCamera].enabled = false;
        currentCamera++;
        if (currentCamera >= cameras.Length)
        {
            currentCamera = 0;
        }
        EnableCurrentCamera();
    }

    void PreviousCamera()
    {
        cameras[currentCamera].GetComponent<AudioListener>().enabled = false;
        cameras[currentCamera].enabled = false;
        currentCamera--;
        if (currentCamera < 0)
        {
            currentCamera = cameras.Length - 1;
        }
        EnableCurrentCamera();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            NextCamera();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            PreviousCamera();
        }
    }
}
