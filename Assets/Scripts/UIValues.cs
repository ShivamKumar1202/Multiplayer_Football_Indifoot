using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class UIValues : MonoBehaviour
{
    PhotonView pv;

    [SerializeField] private Vector3 lastPosition;
    [SerializeField] private float totalDistance;
    [SerializeField] private int sprintCount = 0;

    public int speed;
    float timeElapsed = 0f;
    float minutes = 0f, seconds = 0f;


    [SerializeField] private TMP_Text distanceText, sprintText, speedText, timeText, nameText;
    
    private void Start()
    {
        pv = GetComponent<PhotonView>();
        lastPosition = transform.position;

        nameText.text = ConnectToRoom.connectToRoom.nameValue;

        int.TryParse(ConnectToRoom.connectToRoom.speedValue, out speed);
        speedText.text = "SPD : " + speed;

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
            distanceText.text = "DST : " + totalDistance;

            sprintText.text = "SPR : " + sprintCount;



            timeElapsed += Time.deltaTime;
            minutes = Mathf.FloorToInt(timeElapsed / 60);
            seconds = Mathf.FloorToInt(timeElapsed % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    
}
