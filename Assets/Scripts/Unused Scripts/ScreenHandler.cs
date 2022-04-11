using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Photon.Pun;

public class ScreenHandler : MonoBehaviour
{

    [SerializeField] VideoClip source1, source2, source3, source4;

    [SerializeField] private bool hasScreenControls = false;

    [SerializeField] private GameObject offlineScreen;

    [SerializeField] Material[] materials;
    private  Renderer screenObject;

    VideoPlayer videoPlayer;

    int key;
    int matKey;
    PhotonView photonView;


    void Start()
    {
        videoPlayer = offlineScreen.GetComponent<VideoPlayer>();

        screenObject = offlineScreen.GetComponent<Renderer>();
        
        photonView = GetComponent<PhotonView>();
       
    }
     void Update()
    {
        if (hasScreenControls)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                key = 1;
                photonView.RPC("ScreenManager", RpcTarget.AllBuffered, key);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                key = 2;
                photonView.RPC("ScreenManager", RpcTarget.AllBuffered, key);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                key = 3;
                photonView.RPC("ScreenManager", RpcTarget.AllBuffered, key);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                key = 4;
                photonView.RPC("ScreenManager", RpcTarget.AllBuffered, key);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                key = 9;
                photonView.RPC("ScreenManager", RpcTarget.AllBuffered, key);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                key = 0;
                photonView.RPC("ScreenManager", RpcTarget.AllBuffered, key);
            }
            else if (Input.GetKeyDown(KeyCode.Minus))
            {
                key = -99;
                photonView.RPC("ScreenManager", RpcTarget.AllBuffered, key);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                matKey = 0;
                photonView.RPC("ScreenLogoManager", RpcTarget.AllBuffered, matKey);
            }

            else if (Input.GetKey(KeyCode.E))
            {
                matKey = 1;
                photonView.RPC("ScreenLogoManager", RpcTarget.AllBuffered, matKey);
            }

        }
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            hasScreenControls = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            hasScreenControls = false;
    }

    [PunRPC]
    void ScreenManager(int key)
    {
        if (key == 1)
        {
            Debug.Log("1");
            videoPlayer.clip = source1;
            videoPlayer.Play();
        }

        if (key == 2)
        {
            Debug.Log("2");
            videoPlayer.clip = source2;
            videoPlayer.Play();
        }

        if (key == 3)
        {
            Debug.Log("3");
            videoPlayer.clip = source3;
            videoPlayer.Play();
        }

        if (key == 4)
        {
            Debug.Log("4");
            videoPlayer.clip = source4;
            videoPlayer.Play();
        }

        
        if ((key == 0) )
        {
            Debug.Log("0");
            videoPlayer.Pause();
        }
        else if ( (key == 9) )
        {
            Debug.Log("9");
               videoPlayer.Play();
        }
        else if ((key == -99))
        {
            Debug.Log("9");
            videoPlayer.Stop();
        }

    }

    [PunRPC]
    void ScreenLogoManager(int matKey)
    {
            screenObject.material = materials[matKey];   
    }



}