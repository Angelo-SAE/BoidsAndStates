using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadState : IPlayerState
{
    public IPlayerState DoState(PlayerState player)
    {
      player.PlayerMaterial.color = Color.blue;
      if(player.ClosestBall is null)
      {
        return player.baseState;
      }
      switch(player.ClosestBall.tag)
      {
        case("Scared"):
        return player.scaredState;
        case("Sad"):
        return player.sadState;
        case("Happy"):
        return player.confusedState;
      }
      return player.baseState;
    }
}
