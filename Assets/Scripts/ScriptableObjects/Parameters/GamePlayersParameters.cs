﻿using System.Runtime.Serialization;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class PlayerData : BinarySerializable
{
    public string name;
    public Color color;
    public Player player;
    public int facção;

    public PlayerData(string name, Color color, Player player, int facção
        )
    {
        this.name = name;
        this.color = color;
        this.player = player;
        
        
        this.facção = facção;

    }

    protected PlayerData(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}

[CreateAssetMenu(fileName = "Players Parameters", menuName = "Scriptable Objects/Game Players Parameters", order = 12)]
public class GamePlayersParameters : GameParameters
{
    public override string GetParametersName() => "Players";
    //public override string GetParametersName() => "Players";
    public PlayerData[] players;
    
    public int myPlayerId;
    
}
