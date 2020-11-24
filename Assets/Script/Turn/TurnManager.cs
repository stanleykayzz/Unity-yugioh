using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnManager {

public bool DrawPhase; 
public bool StandByPhase; 
public bool MainPhase1; 
public bool BattlePhase; 
public bool MainPhase2; 
public bool EndPhase;

	public TurnManager()
	{
		this.DrawPhase = false;
		this.StandByPhase = false;
		this.MainPhase1 = false;
		this.BattlePhase = false;
		this.MainPhase2 = false;
		this.EndPhase = false;
		Debug.Log("not in trun for now ...");
	}

	public void goToDrawPhase()
	{
        this.DrawPhase = true;
        Debug.Log("DP");
    }

    public void  goStandByPhase()
    {
        this.DrawPhase = false;
        this.StandByPhase = true;
        Debug.Log("SP");
    }

    public void  goToMainPhase1()
    {
        this.StandByPhase = false;
        this.MainPhase1 = true;
        Debug.Log("MP1");
    }

    public void  goToBattlePhase()
    {
        this.MainPhase1 = false;
        this.BattlePhase = true;
        Debug.Log("BP");
    }

    public void  goToMainPhase2()
    {
        this.BattlePhase = false;
        this.MainPhase2 = true;
        Debug.Log("MP2");
    }

    public void  goToEndPhase()
    {
        //on peut passer de la mp1, de la mp2 ou de la bp à la ep
        this.MainPhase1 = false;
        this.BattlePhase = false;
        this.MainPhase2 = false;
        this.EndPhase = true;
        Debug.Log("EP");
    }
}
