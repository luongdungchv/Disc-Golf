using System;
using System.Collections;
using System.Collections.Generic;
using DL.StateMachine;
using UnityEngine;

public class AfterThrowState : DL.StateMachine.StateBehaviour
{
    private Vector3 targetPos;
    private Vector3 discPos;
    private Vector3 targetCamPos;
    private float targetXAngle, targetYAngle;
    public override void OnStateEnter(StateController stateController)
    {
        var throwController = stateController as ThrowStateController;
        targetPos = LevelManager.Instance.CurrentSessionInfo.throwTarget.transform.position;
        discPos = throwController.Thrower.Disc.transform.position;
        var dirToTarget = (targetPos - discPos);

        targetCamPos = discPos - dirToTarget.Set(y: 0).normalized * 4f + Vector3.up * 2;
        var camDirToTarget = targetPos - targetCamPos;
        targetXAngle = Mathf.Asin(Mathf.Abs(camDirToTarget.y) / camDirToTarget.magnitude) * -camDirToTarget.y / Mathf.Abs(camDirToTarget.y) * Mathf.Rad2Deg;
        targetYAngle = Mathf.Atan2(camDirToTarget.x, camDirToTarget.z) * Mathf.Rad2Deg;
    }

    public override void OnStateExit(StateController stateController)
    {
        var throwController = stateController as ThrowStateController;
        throwController.UIAfterThrow.SetActive(false);
    }

    public override void OnStateFixedUpdate(StateController stateController)
    {
    }

    public override void OnStateUpdate(StateController stateController)
    {
        var throwController = stateController as ThrowStateController;

        var throwTarget = LevelManager.Instance.CurrentSessionInfo.throwTarget;
        //throwController.CameraFollow.AdjustLookatTarget(targetCamPos, targetXAngle, targetYAngle);
        if (throwTarget.IsInBasket(throwController.Thrower.Disc))
        {

        }
        else
        {
            throwController.CameraFollow.AdjustLookatTarget(targetCamPos, targetXAngle, targetYAngle);
            throwController.UIAfterThrow.SetActive(true);
        }
    }
}
