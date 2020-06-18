using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(PlayerInfection player);
    public abstract void OnTriggerEnter2D(PlayerInfection player);
    public abstract void OnTriggerExit2D(PlayerInfection player);
    public abstract void Update(PlayerInfection player);
}
