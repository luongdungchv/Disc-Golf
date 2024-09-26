using System.Collections;
using System.Collections.Generic;
using DL.StateMachine;
using UnityEngine;

public class PreThrowState : StateBehaviour
{
    public override void OnStateEnter(StateController stateController)
    {
        var throwController = stateController as ThrowStateController;
        UIManager.Instance.UIPreThrow.gameObject.SetActive(true);
        UIManager.Instance.UISessionComplete.gameObject.SetActive(false);
        Debug.Log(throwController.Thrower);
        throwController.Thrower.Init();
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
