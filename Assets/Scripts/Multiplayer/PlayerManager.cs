using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System.Linq;

public class PlayerManager : MonoBehaviour
{

    PhotonView PV;
    private Dictionary<int, PlayerData> _playersData;
    public GamePlayersParameters _playersParameters;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        Debug.Log("awake");
        //_playersParameters.myPlayerId = PV.Controller.ActorNumber;
        Debug.Log(PV.Controller.ActorNumber);
        Debug.Log(_playersParameters.myPlayerId);
        
        Debug.Log($"P = {_playersData}");
        Debug.Log(PV.Controller.NickName);
        Debug.Log(PV.Controller.ActorNumber);

        //_playersData[PV.Controller.ActorNumber] = new PlayerData(PV.Controller.NickName, Color.red);

        Debug.Log($"P = {_playersData}");
        //GamePlayersParameters p = ScriptableObject.CreateInstance<GamePlayersParameters>();
        //p.players = _playersData
        //    .Where((KeyValuePair<int, PlayerData> p) => _activePlayers[p.Key])
        //    .Select((KeyValuePair<int, PlayerData> p) => p.Value)
        //    .ToArray();
        
        //Debug.Log($"P = {p}");

        //p.myPlayerId = PV.ControllerActorNr;
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
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RTS Camera"), new Vector3(100, 40, 50), Quaternion.Euler(new Vector3(30,0,0)));
    }

    // inserir aqui todas as chamadas que o jogador faça.

}