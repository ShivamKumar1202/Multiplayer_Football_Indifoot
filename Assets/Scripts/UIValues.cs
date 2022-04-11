using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UIValues : MonoBehaviour
{
    PhotonView pv;

    [SerializeField] private Vector3 lastPosition;
    [SerializeField] private float totalDistance;
    [SerializeField] private int sprintCount = 0;

    public int speed;


    [SerializeField] private TMP_Text distanceText, sprintText, speedText;


    private void Start()
    {
        pv = GetComponent<PhotonView>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (pv.IsMine)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                sprintCount++;
            }

            float distance = Vector3.Distance(lastPosition, transform.position);
            totalDistance += distance;
            lastPosition = transform.position;
            totalDistance = Mathf.Round(totalDistance * 10) / 10f;
            distanceText.text = "Distance : " + totalDistance;
            sprintText.text = "Sprints : " + sprintCount;
            int.TryParse(ConnectToRoom.connectToRoom.speedValue, out speed);
            speedText.text = "Top Speed : " + speed;
        }
    }

    
}
