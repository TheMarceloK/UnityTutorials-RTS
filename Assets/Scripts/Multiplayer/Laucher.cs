using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;
using ExitGames.Client.Photon;

public class Laucher : MonoBehaviourPunCallbacks
{

    public static Laucher Instance;

    [SerializeField]
    TMP_InputField roomNameInputField;
    [SerializeField]
    TMP_Text errorText;
    [SerializeField]
    TMP_Text roomNameText;    
    [SerializeField]
    TMP_Text playersCount;
    [SerializeField]
    Transform roomListContent;
    [SerializeField] 
    Transform playerListContent;
    [SerializeField]
    GameObject roomListPrefab;    
    [SerializeField]
    GameObject playerListPrefab;
    [SerializeField]
    TMP_InputField playerName;
    [SerializeField]
    int playerCountNum;
    [SerializeField]
    GameObject startGameButton;
    private static Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();
    [SerializeField]
    GamePlayersParameters gamePlayersParameters;
    private Dictionary<int, PlayerData> _playersData;
    bool entrou = false;
    Player[] players ;
    public int fac��o =1;

    private static readonly Color[] _playerColors = new Color[]
    {
            Color.red,
            Color.blue,
            Color.yellow,
            Color.green,
            Color.cyan,
            Color.magenta,
            Color.white,
            Color.gray,
    };

    public int PlayerCountNum { get => playerCountNum;}

    private void Awake()
    {
        _playersData = new Dictionary<int, PlayerData>();
        Instance = this;
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        EventManager.TriggerEvent("LoadedScene");
        //PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        PhotonNetwork.NickName = playerName.text;

        playersCount.text = playerCountNum.ToString();

        if (entrou)
        {
            for (int i = 0; i < players.Length; i++)
            {
                _playersData[i] = new PlayerData(players[i].NickName, _playerColors[i], players[i],fac��o);
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
    }

    public void StartGame(string s)
    {
        //GamePlayersParameters p = ScriptableObject.CreateInstance<GamePlayersParameters>();
        
        PhotonNetwork.LoadLevel(s);
        
    }
    private void OnDisable()
    {
        gamePlayersParameters.players = _playersData
            //.Where((KeyValuePair<int, PlayerData> p) => _activePlayers[p.Key])
            .Select((KeyValuePair<int, PlayerData> p) => p.Value)
            .ToArray();
        RoomManager.instance.gamePlayersParameters = gamePlayersParameters;
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        players = PhotonNetwork.PlayerList;


        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        playerCountNum = players.Count();

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        gamePlayersParameters.myPlayerId = playerCountNum -1 ;
        Debug.Log(gamePlayersParameters.myPlayerId);

        entrou = true;
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed" + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        MenuManager.Instance.OpenMenu("loading");
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("room");
        
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            RoomInfo info = roomList[i];
            if (info.RemovedFromList)
            {
                cachedRoomList.Remove(info.Name);
            }
            else
            {
                cachedRoomList[info.Name] = info;
            }
        }

        foreach (KeyValuePair<string, RoomInfo> entry in cachedRoomList)
        {
            Instantiate(roomListPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(cachedRoomList[entry.Key]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        players = PhotonNetwork.PlayerList;
        entrou = true;
        Instantiate(playerListPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }
}
