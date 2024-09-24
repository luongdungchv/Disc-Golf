using System.Collections;
using System.Collections.Generic;
using DL.StateMachine;
using UnityEngine;

public class AfterThrowState : DL.StateMachine.StateBehaviour
{
    public override void OnStateEnter(StateController stateController)
    {
            
    }

    public override void OnStateExit(StateController stateController)
    {
    }

    public override void OnStateFixedUpdate(StateController stateController)
    {
    }

    public override void OnStateUpdate(StateController stateController)
    {
        var throwController = stateController as ThrowStateController;
        var targetPos = LevelManager.Instance.CurrentSessionInfo.throwTarget.transform.position;
        var discPos = throwController.Thrower.Disc.transform.position;
        var dirToTarget = (targetPos - discPos).Set(y: 0).normalized;

        var targetCamPos = discPos - dirToTarget * 4f + Vector3.up;
        var targetCamRotation = Quaternion.LookRotation(targetPos - targetCamPos, Vector3.up);  

        throwController.CameraFollow.AdjustLookatTarget(targetCamPos, targetCamRotation);
    }
}
