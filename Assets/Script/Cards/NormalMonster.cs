using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NormalMonster : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
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
        //monsterAttribute = MonsterAttribute.Earth;
        //atkLabel.text = atk.ToString();
        setAttributeOnCardLayout(monsterAttribute);

        for (int count = 0; count < lv; count++)
        {
            // To add Ui component to gridLayout, we just need to move component to grid and it will update automatically
            //var clone = Instantiate(star,panel.transform);
            var clone = Instantiate(star,panel.transform);
            //var clonePositionZ = clone.transform.position.z;
            //star.transform.position( = clonePositionZ;
//            star.transform.position = clone.transform.position;
//            star.transform.position.z = clonePositionZ;
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

        public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Selected");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("De-Selected");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
        Debug.Log("this card name is " + this.name);
        //        this.panel.gameObject.GetComponent<RectTransform>().rect.
        this.gameObject.transform.GetChild(1).GetComponent<Image>().color = Color.green;

        //var xxx = eventData.pointerEnter.transform.GetChild(1).gameObject.name;
        var xxx = eventData.pointerEnter.transform.GetChild(0).gameObject.GetComponent<Text>().text;
//        var xxx = eventData.pointerEnter.transform.gameObject.GetComponent<Text>().text;
//        var xxx = eventData.pointerEnter.transform.GetChild(0).gameObject.name;
        Debug.Log("zazazaza " + xxx);
        //        this.panel.gameObject.transform.GetChild(1).
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
        this.gameObject.transform.GetChild(1).GetComponent<Image>().color = Color.white;
    }
}
