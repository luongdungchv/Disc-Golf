using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscDriver : DiscThrower
{
    private void Start() {
        UIManager.Instance.UIPreThrow.UIBender.RegisterOnDragCallback(this.UIBendDragCallback);
        UIManager.Instance.UIPreThrow.UIBender.RegisterOnDropCallback(this.UIBendDropCallback);
    }
    public override void Throw()
    {
        this.discObj.transform.SetParent(null);
        this.discObj.StartDriveFlying(aimer.Direction, this.curl, this.throwStrength);
        this.aimer.DetachCamera();
        this.cameraFollow.SetFollow(true);
    }

    private void UIBendDragCallback(float dragLength, float hValue){
        this.curl = -hValue / dragLength;
        this.discObj.Bend(Mathf.Asin(hValue / dragLength) * Mathf.Rad2Deg);
        this.throwStrength = dragLength / 265;
    }
    private void UIBendDropCallback(){
        ThrowStateController.Instance.ChangeState("Flying");
    }
}
