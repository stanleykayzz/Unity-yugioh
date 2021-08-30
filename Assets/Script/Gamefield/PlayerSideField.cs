using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideField  {

    StackCard Deck, fieldZone, graveyard, extradeck, outzone;
    MonsterZone pendulum1, pendulum2;
    public MonsterZone monsterZone1, monsterZone2, monsterZone3, monsterZone4, monsterZone5;
    TrapMagicZone mpZone1, mpZone2, mpZone3, mpZone4, mpZone5;

    public PlayerSideField()
    {
        this.monsterZone1 = new MonsterZone();
        this.monsterZone2 = new MonsterZone();
        this.monsterZone3 = new MonsterZone();
        this.monsterZone4 = new MonsterZone();
        this.monsterZone5 = new MonsterZone();
        this.mpZone1 = new TrapMagicZone();
        this.mpZone2 = new TrapMagicZone();
        this.mpZone3 = new TrapMagicZone();
        this.mpZone4 = new TrapMagicZone();
        this.mpZone5 = new TrapMagicZone();    
        this.fieldZone = new StackCard();           
        this.graveyard = new StackCard();           
        this.extradeck = new StackCard();           
        this.outzone = new StackCard();           
        this.Deck = new StackCard();           
    }

    public bool monsterZone1IsEmpty() {
    if (this.monsterZone1.monsterPosition.Count == 0)
        return true;
    else
        return false;
    }
    public bool monsterZone2IsEmpty() {
        if (this.monsterZone2.monsterPosition.Count == 0)
            return true;
        else
            return false;
    }
    public bool monsterZone3IsEmpty() {
        if (this.monsterZone3.monsterPosition.Count == 0)
            return true;
        else
            return false;
    }
    public bool monsterZone4IsEmpty() {
        if (this.monsterZone4.monsterPosition.Count == 0)
            return true;
        else
            return false;
    }
    public bool monsterZone5IsEmpty() {
        if (this.monsterZone5.monsterPosition.Count == 0)
            return true;
        else
            return false;
    }
    public int getDeckSize()
    {
        return this.Deck.getListSize();
    }
    public int getExtraDeckSize()
    {
        return this.extradeck.getListSize();
    }
    public int getOutzoneSize()
    {
        return this.outzone.getListSize();
    }
    public int getGraveyardSize()
    {
        return this.graveyard.getListSize();
    }
}
