using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DL.StateMachine;

public class FlyingState : StateBehaviour
{
    private float cd;
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

    public override void OnStateLateUpdate(StateController stateController)
    {
        (stateController as ThrowStateController).CameraFollow.Follow();
    }

    public override void OnStateUpdate(StateController stateController)
    {
        var throwController = stateController as ThrowStateController;
        var disc = throwController.Thrower.Disc;
        var discSpd = disc.GetComponent<Rigidbody>().velocity.magnitude;
        if(Mathf.Abs(discSpd) < 0.01f){
            cd += Time.deltaTime;
            if(cd > 2){
                throwController.ChangeState("After Throw");
            }
        }
        else{
            cd = 0;
        }
    }
}
