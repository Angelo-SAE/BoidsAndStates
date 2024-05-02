using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : IPlayerState
{
    public IPlayerState DoState(PlayerState player)
    {
      player.PlayerMaterial.color = Color.white;
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
        return player.happyState;
      }
      return player.baseState;
    }
}
