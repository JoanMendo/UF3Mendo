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
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeCameraState();
        }

    }
    public void ChangeCameraState()
    {
        if (isCameraActive)
        {
            int layerIndex = LayerMask.NameToLayer("Default");
            cameraPivot.SetActive(false);
            foreach (GameObject obj in objectToDisable)
            {
                obj.layer = layerIndex;
            }
        }
        else
        {
            int layerIndex = LayerMask.NameToLayer("TransparentFX");
            cameraPivot.SetActive(true);
            foreach (GameObject obj in objectToDisable)
            {
                obj.layer = layerIndex;
            }
        }

        isCameraActive = !isCameraActive;
    }
}
