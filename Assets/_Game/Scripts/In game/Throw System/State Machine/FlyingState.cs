using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DL.StateMachine;

public class FlyingState : StateBehaviour
{
    public override void OnStateEnter(StateController stateController)
    {
        var throwController = stateController as ThrowStateController;
        throwController.UIPreThrow.gameObject.SetActive(false);
        Debug.Log("drop");
        throwController.Thrower.Throw();
    }

    public override void OnStateExit(StateController stateController)
    {
    }

    public override void OnStateFixedUpdate(StateController stateController)
    {
    }

    public override void OnStateUpdate(StateController stateController)
    {
    }
}
