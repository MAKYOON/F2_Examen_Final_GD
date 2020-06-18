using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingHealthState : BaseState
{

    public override void EnterState(PlayerInfection player)
    {
        player.InvokeRepeating("RemoveHealth", 0, 1f);
    }

    public override void OnTriggerEnter2D(PlayerInfection player)
    {
        player.CancelInvoke();
        player.TransitionToState(player.IncreasingLifeState);
        
    }

    public override void OnTriggerExit2D(PlayerInfection player)
    {
        return;
    }

    public override void Update(PlayerInfection player)
    {
        return;
    }


}
