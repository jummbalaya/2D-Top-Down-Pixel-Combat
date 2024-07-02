using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera cinVirCamera;

    private void Start()
    {
        SetPlayerCameraFollow();
    }

    public void SetPlayerCameraFollow()
    {
        cinVirCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinVirCamera.Follow = PlayerController.Instance.transform;
    }
}
