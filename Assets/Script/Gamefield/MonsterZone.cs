﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterZone : CardZone {

    public List<Card> monsterPosition;

    public MonsterZone() {
        this.monsterPosition = new List<Card>();
    }

    public Monster getMonster()
    {
        return (Monster) this.monsterPosition[0];
    }
	
}
