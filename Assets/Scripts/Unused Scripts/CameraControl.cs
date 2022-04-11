using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;


public class CameraControl : MonoBehaviour
{
    private PhotonView pView;
 
    void Start()
    {
       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }

}
