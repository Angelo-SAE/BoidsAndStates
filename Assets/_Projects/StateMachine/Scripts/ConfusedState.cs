using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusedState : IPlayerState
{
    public IPlayerState DoState(PlayerState player)
    {
      player.PlayerMaterial.color = Color.green;
      if(player.ClosestBall is null)
      {
        return player.baseState;
      }
      return player.confusedState;
    }
}
