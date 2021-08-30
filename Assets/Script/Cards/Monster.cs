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
        string name, string des, bool front, bool back, Image art) : base(name, des, front, back, art)
    {
        this.stars = countStars;
        this.attackPoints = atk;
        this.defensePoints = def;
        this.type = mType;
        this.attribute = mAttribute;
    }


    public NormalMonster GetNormalMonster()
    {
        var m = new NormalMonster();
        Debug.Log("getNORMAL MONSTER ==> " + this.stars);
        m.lv = this.stars;
        m.name = this.name;
        m.atk = (int)this.attackPoints;
        m.def = (int)this.defensePoints;
        m.monsterAttribute = this.attribute;
        m.monsterType = this.type;
        return m;
    }

}
