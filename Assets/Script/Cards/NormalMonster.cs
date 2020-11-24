using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalMonster : MonoBehaviour {
    public Monster thisCard;
    public GameObject[] attributeArray;
    public GameObject panel;
    public GameObject attributePanel;
    public Image star;
    public int atk;
    public int def;
    public int lv;
    public string codeCard;
    public string name;
    public string des;
    public MonsterType monsterType;
    public MonsterAttribute monsterAttribute;

    public Text atkLabel;
    public Text defLabel;
    public int lvLabel;
    public Text codeCardLabel;
    public Text nameLabel;
    public Text desLabel;
    public Text monsterTypeLabel;
    //    public MonsterAttribute monsterAttribute;

//    clone = Instantiate(projectile, transform.position, transform.rotation);

    // Use this for initialization
    void Start () {
        atkLabel.text = atk.ToString();
        defLabel.text = def.ToString();
        nameLabel.text = name;
        codeCardLabel.text = codeCard.ToString();
        desLabel.text = des;
        monsterTypeLabel.text = MonsterType.Machine.ToString();
        monsterAttribute = MonsterAttribute.Earth;
        //atkLabel.text = atk.ToString();
        setAttributeOnCardLayout(monsterAttribute);

        for (int count = 0; count < lv; count++)
        {
            // To add Ui component to gridLayout, we just need to move component to grid and it will update automatically
            var clone = Instantiate(star,panel.transform);
            //star.GetComponent<Image>();
            //            panel.GetComponent<Image>().obj
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void setAttributeOnCardLayout(MonsterAttribute attribute)
    {
        //feu
        //eau
        //vent
        //terre
        //lumière
        //tenebres
        //divin
        if (attribute == MonsterAttribute.Fire)
        {
            var cardAttribute = Instantiate(attributeArray[0], attributePanel.transform);
        }
        else if (attribute == MonsterAttribute.Water)
        {
            var cardAttribute = Instantiate(attributeArray[1], attributePanel.transform);
        }
        else if (attribute == MonsterAttribute.Wind)
        {
            var cardAttribute = Instantiate(attributeArray[2], attributePanel.transform);
        }
        else if (attribute == MonsterAttribute.Earth)
        {
            var cardAttribute = Instantiate(attributeArray[3], attributePanel.transform);
        }
        else if (attribute == MonsterAttribute.Light)
        {
            var cardAttribute = Instantiate(attributeArray[4], attributePanel.transform);
        }
        else if (attribute == MonsterAttribute.Dark)
        {
            var cardAttribute = Instantiate(attributeArray[5], attributePanel.transform);
        }
        else if (attribute == MonsterAttribute.Divine)
        {
            var cardAttribute = Instantiate(attributeArray[6], attributePanel.transform);
        }
    }
}
