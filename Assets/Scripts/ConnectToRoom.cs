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
    public InputField speedText, nameText;
    public string speedValue, nameValue;

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
            speedValue = speedText.text;
            nameValue = nameText.text;
        
    }

    public void JoinRoom()
    {
            PhotonNetwork.JoinRoom(joinInput.text);
            speedValue = speedText.text;
            nameValue = nameText.text;
        
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Hall");
    }

   

}
