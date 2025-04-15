using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections.Generic;

public class ChangeCamera : MonoBehaviour
{
    public GameObject cameraPivot;
    public List<GameObject> objectToDisable;

    private bool isCameraActive = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCameraState();
        }

    }
    public void ChangeCameraState()
    {
        if (isCameraActive)
        {
            cameraPivot.SetActive(false);
            foreach (GameObject obj in objectToDisable)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            cameraPivot.SetActive(true);
            foreach (GameObject obj in objectToDisable)
            {
                obj.SetActive(false);
            }
        }

        isCameraActive = !isCameraActive;
    }
}
