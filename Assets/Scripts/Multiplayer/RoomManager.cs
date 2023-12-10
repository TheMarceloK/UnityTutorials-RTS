using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GamePlayersParameters gamePlayersParameters;
    public static RoomManager instance;
    BuildingPlacer buildingPlacer;
    PhotonView PV;

    private void Awake()
    {
        
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        PV = GetComponent<PhotonView>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 2)
        {
            buildingPlacer = FindObjectOfType<BuildingPlacer>();
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerManager"), Vector3.zero, Quaternion.identity);
            
        }
    }
    // inserir aqui todas as chamadas que o jogador faça.

    //trigger de skill
    public void TriggerSkill(Unit caller, int index, GameObject target = null)
    {if (PV.IsMine)
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
}
