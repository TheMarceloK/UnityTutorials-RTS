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
       

        //_playersData[PV.Controller.ActorNumber] = new PlayerData(PV.Controller.NickName, Color.red);

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
    public void TriggerSkill(Unit caller, int index, GameObject target = null)
    {
        if (PV.IsMine)
        {
            //Debug.Log(caller);
            //caller.PV.RPC("RPCTriggerSkill", RpcTarget.All, index, target);
            PV.RPC("teste", RpcTarget.All);
        }
    }
    [PunRPC]
    public void teste()
    {
        Debug.Log("teste");
    }

    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RTS Camera"), new Vector3(100, 40, 50), Quaternion.Euler(new Vector3(30, 0, 0)));
        Object.FindObjectOfType<CameraManager>().InitializeBounds();
        EventManager.TriggerEvent("LoadedScene");
    }

    // inserir aqui todas as chamadas que o jogador faça.

}