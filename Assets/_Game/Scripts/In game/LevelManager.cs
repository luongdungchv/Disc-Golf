using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private List<LevelSession> sessionList;
    private int currentSession;
    private int currentThrow;
    [SerializeField] private LevelSession currentSessionInfo;

    public LevelSession CurrentSessionInfo => this.currentSessionInfo;

    private void Awake(){
        Instance = this;
        UIManager.Instance.UIDiscSelector.ShowUI();
        this.StartSession(0);
    }

    public void StartSession(int index){
        this.currentSession = index;
        this.currentSessionInfo = sessionList[index];
        this.currentThrow = 0;
    }

    public void NextSession(){
        if(currentSession == sessionList.Count - 1) return;
        this.currentSessionInfo.throwTarget.gameObject.SetActive(false);
        StartSession(currentSession + 1);
        this.currentSessionInfo.throwTarget.gameObject.SetActive(true);
    }

    public void IncreaseThrow() => this.currentThrow++;
}   
[System.Serializable]
public class LevelSession{
    public ThrowTarget throwTarget;
    public Transform startInfo;
    public int par;
}
