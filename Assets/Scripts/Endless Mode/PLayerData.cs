using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//needs to be studied more rather than only being copied

[System.Serializable]
public class PlayerData
{
    public int highscore;


    public PlayerData (playerMovement player)
    {
        highscore = player.highScore;
    }
}
