using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    

    public float minX;
    public float maxX;
   // public float minY;
   // public float maxY;
    public float minZ;
    public float maxZ;

    private GameObject playerInstance;
    void Start()
    {
        Vector3 playerSpawnPosition = new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minZ, maxZ));
        playerInstance = PhotonNetwork.Instantiate(playerPrefab.name, playerSpawnPosition, Quaternion.identity);

       
    }

}
