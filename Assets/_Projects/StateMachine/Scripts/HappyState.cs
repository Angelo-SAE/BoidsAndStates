using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyState : IPlayerState
{
    public IPlayerState DoState(PlayerState player)
    {
      player.PlayerMaterial.color = Color.magenta;
      if(player.ClosestBall is null)
      {
        return player.baseState;
      }
      switch(player.ClosestBall.tag)
      {
        case("Scared"):
        return player.scaredState;
        case("Sad"):
        return player.confusedState;
        case("Happy"):
        return player.happyState;
      }
      return player.baseState;
    }
}
