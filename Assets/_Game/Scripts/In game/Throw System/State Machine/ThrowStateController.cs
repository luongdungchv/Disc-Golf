using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DL.StateMachine;
using Unity.VisualScripting;

public class ThrowStateController : StateController
{
    [SerializeField] private DiscThrower thrower;
    [SerializeField] private DiscAimer aimer;
    [SerializeField] private GameObject uiPreThrow, uiAfterThrow;
    [SerializeField] private CameraFollow cameraFollow;

    [SerializeField] private UIBender uiBender;

    private void Start(){
        uiBender.RegisterOnDragCallback(this.thrower.UIBendDragCallback);
        uiBender.RegisterOnDropCallback(this.UIBendDropCallback);
    }

    private void UIBendDropCallback(){
        
        this.ChangeState("Flying");
    }

    public void ThrowAgain(){
        LevelManager.Instance.IncreaseThrow();
        this.ChangeState("Pre Throw");
    }
    public void MoveToTie(){        
        var newPos = Thrower.Disc.transform.position + Vector3.up;
        Thrower.transform.position = newPos;
        Aimer.transform.position = newPos;
        LevelManager.Instance.IncreaseThrow();
        this.ChangeState("Pre Throw");
    }

    public DiscThrower Thrower => this.thrower;
    public DiscAimer Aimer => this.aimer;
    public GameObject UIPreThrow => this.uiPreThrow;
    public GameObject UIAfterThrow => this.uiAfterThrow;
    public CameraFollow CameraFollow => this.cameraFollow;
}
