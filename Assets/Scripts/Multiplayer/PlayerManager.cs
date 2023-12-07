using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{

    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();

        Debug.Log("Player Manager awake");
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void Start()
    {
        //if(PV.IsMine)
        //{
        //    CreateController();
        //}
    }

    void CreateController()
    {

        Debug.Log("CreateController");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RTS Camera"), new Vector3(100, 40, 50), Quaternion.Euler(new Vector3(30,0,0)));
    }
}