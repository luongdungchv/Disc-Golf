using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DL.StateMachine;
using Unity.VisualScripting;

public class ThrowStateController : StateController
{
    [SerializeField] private DiscThrower thrower;
    [SerializeField] private DiscAimer aimer;
    [SerializeField] private GameObject uiPreThrow;

    [SerializeField] private UIBender uiBender;

    private void Start(){
        uiBender.RegisterOnDragCallback(this.thrower.UIBendDragCallback);
        uiBender.RegisterOnDropCallback(this.UIBendDropCallback);
    }

    private void UIBendDropCallback(){
        
        this.ChangeState("Flying");
    }

    public DiscThrower Thrower => this.thrower;
    public DiscAimer Aimer => this.aimer;
    public GameObject UIPreThrow => this.uiPreThrow;
}
