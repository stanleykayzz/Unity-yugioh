using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Card {

    public RankOrLevel level;
    public int stars;
    public double attackPoints;
    public double defensePoints;
    //public bool canAttack;
    public MonsterType type;
    public MonsterAttribute attribute;
    //public CardFrame frame;

    public Monster()
    {

    }

    public Monster(int countStars, double atk, double def, MonsterType mType, MonsterAttribute mAttribute,
        string name,string des,bool front,bool back,Image art) :base(name,des,front,back,art)
    {
        this.stars = countStars;
        this.attackPoints = atk;
        this.defensePoints = def;
        this.type = mType;
        this.attribute = mAttribute;
    }


}
