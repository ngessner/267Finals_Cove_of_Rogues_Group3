using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShiftRoomCam : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShiftToRoom(GameObject roomPoint)
    {
        vcam.Follow = roomPoint.transform;
    }
}
