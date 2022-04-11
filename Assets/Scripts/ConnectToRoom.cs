using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ConnectToRoom : MonoBehaviourPunCallbacks
{
    public static ConnectToRoom connectToRoom;

    public InputField createInput;
    public InputField joinInput;
    public InputField inputText;
    public string speedValue;

    private void Awake()
    {
        if(connectToRoom == null)
        {
            connectToRoom = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        speedValue = inputText.text;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        speedValue = inputText.text;
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Hall");
    }

   

}
