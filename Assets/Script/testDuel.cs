using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class testDuel : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler

{
    //on cree les variables pour les cartes physiques (game object) 
    //tous les types de cartes monstre/magie/piège
    public NormalMonster normalMonster;
    //public GameObject normalMonster, effectMonster, fusionMonster, xyzMonster, ritualMonster, synchroMonster;
    //cartes magiques
    //    public GameObject magicCard;
    //cartes pièges
    //  public GameObject trapCard;
    //player one deckZone;
    public GameObject Player1DeckZone;
    public GameObject player1Hand;
    public GameObject monsterZone1;
    public GameObject monsterZone2;
    public GameObject monsterZone3;
    public GameObject monsterZone4;
    public GameObject monsterZone5;
    public List<NormalMonster> listObjectInHand = new List<NormalMonster>();
    public List<NormalMonster> listObjectInDeck;
    public DuelGameManager duel;
    public GameObject detailCardName;
    public GameObject detailCardDescription;
    public GameObject detailCardArt;

    // Use this for initialization
    void Start () {
		// var emptyDuelManager = (GameObject.FindGameObjectsWithTag("duelManagerTag"));
		// this.emptyDuelManager = Instantiate(GameObject.FindGameObjectsWithTag("duelManagerTag"));

		Debug.Log("on démarre le test");
        // Console.WriteLine("empty duel manager "+ emptyDuelManager);

        //On crée les variables pour les cartes virtuelles. la partie logique de la manipulation de cartes
        //on crée une carte
        var bursti = new Monster(3,1200,800,MonsterType.Warrior,MonsterAttribute.Fire,"Burstinatrix Hero elementaire","hero manipulatrice du feu",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		var whiteDragon = new Monster(8,3000,2500,MonsterType.Dragon,MonsterAttribute.Light,"dragon blanc aux yeux blancs","dragon de lumiere",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		var blackDragon = new Monster(4,2500,2000,MonsterType.Dragon,MonsterAttribute.Dark,"red eyes black dragon","dragon malefique",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		var fgd = new Monster(12,1200,800,MonsterType.Dragon,MonsterAttribute.Dark,"Five God Dragon ","le dieu dragon",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		var kumori = new Monster(4,1500,800,MonsterType.Dragon,MonsterAttribute.Dark,"Dragon Kumori","dragon des tenebres",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
        //var xxxx = new NormalMonster();
		Debug.Log("carte 1 ==> "+bursti.name);
		Debug.Log("carte 2 ==> "+whiteDragon.name);
		Debug.Log("carte 3 ==> "+blackDragon.name);
		Debug.Log("carte 4 ==> "+fgd.name);
		Debug.Log("carte 5 ==> "+kumori.name);

        var deck1 = new List<Card> {
			whiteDragon,kumori,bursti,whiteDragon,kumori,bursti,whiteDragon,fgd,whiteDragon,fgd,fgd,fgd,fgd,whiteDragon,
            fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,blackDragon
        };
        var deck2 = new List<Card> {
			whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,
            whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,
            fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,blackDragon
        };
        
		//Debug.Log("deck 1  count ==> "+deck1.Count+ " name card3 ==> "+deck1[2].name);
		//Debug.Log("deck 2  count ==> "+deck2.Count+ " name card32 ==> "+deck2[31].name);

		// On crée les decks des deux joueurs
		Player yugi = new Player("Yugi Muto",8000,deck1, null, new List<Card>(),null,null,new TurnManager(),false);
		Player kaiba = new Player("Seto Kaiba",8000,deck2,null,new List<Card>(),null,null,new TurnManager(),false);

		Debug.Log("player 1 ==> "+yugi.pseudo);
		Debug.Log("player 2 ==> "+kaiba.pseudo);

		// On crée deux joueurs pour démarrer la partie
		var duelists = new List<Player>{
			yugi,kaiba
		};

        generateCardsTest(deck1);

        this.duel = new DuelGameManager(duelists);

        //une fois le duel créé on verifie lequel des deux jouer peut jouer en premier
        Debug.Log("turn to play check p1 : "+duel.FirstPlayer.turnToPlay);
        Debug.Log("turn to play check p2 : "+duel.SecondPlayer.turnToPlay);
        //si le joueur peut invoquer, on invoque un monstre
        Debug.Log("p1 can summon: " + duel.FirstPlayer.canNormalSummon);
        Debug.Log("p2 can summon: " + duel.SecondPlayer.canNormalSummon);
        //        duel.summonMonster()
        duel.FirstPlayer.goToDrawPhase();
        duel.FirstPlayer.goToStandByPhase();
        duel.FirstPlayer.goToMainPhase1();
        Debug.Log("again p1 can summon: " + duel.FirstPlayer.canNormalSummon);

        /*duel.summonMonster(duel.FirstPlayer);
        //on essaie d'en invoquer un deuxièmepour vérifier si c'est bien possible
        duel.summonMonster(duel.FirstPlayer);

        //on verifie la première zone monstre au moins pour confirmer l'invocation
        Debug.Log("monster zone 1 contain how much monster ? " + duel.player1SideField.monsterZone1.monsterPosition.Count);
        Debug.Log("monster zone 1 monster name: " + duel.player1SideField.monsterZone1.monsterPosition[0].name);*/
        //si pas possible, on change de phase pour la battlephase
        /*duel.attack(yugi, kaiba);
        duel.attack(yugi, kaiba);
        duel.attack(yugi, kaiba);
        duel.attack(yugi, kaiba);
        duel.attack(yugi, kaiba);
        duel.attack(yugi, kaiba);
        duel.attack(yugi, kaiba);*/
        //si c'est le tout premier tour on vérifie si le joueur peut attaquer

        //on passe à la ep

        //on test les features du deuxième joueur

        //au 3ème tour on vérifie le count des tours pour voir si il est ok

        //on vérifie en suite l'attaque et on test la fin de duel
        /*if (this.duel.winner == null || this.duel.looser == null)
        {
            this.duel.checkForWinner();
        }*/
        /*
        //---------------------------------------------------------------------
        var eventSystem = GameObject.FindObjectOfType<EventSystem>();
        //uiRaycast = eventSystem.GetComponent<GraphicRaycaster>();

        //List<RaycastResult> results = new List<RaycastResult>();
        //uiRaycast.Raycast(eventData, results);

        //results has all of the canvas objects

        if (eventSystem.IsPointerOverGameObject())
        {
  //          PointerEventData test = ExtendedStandaloneInputModule.GetPointerEventData();
//            PointerEventData test = ExtendedStandaloneInputModule.GetPointerEventData();
            Debug.Log("Pointer over gameObject");

            if (eventSystem.currentSelectedGameObject.tag.Equals("yellow"))
            {
                Debug.Log("tag yellow");
            }
            if (eventSystem.currentSelectedGameObject.tag.Equals("detailCard"))
            {
                Debug.Log("tag card detail");
            }
            //inventory, stats or minimap
        }
        //---------------------------------------------------------------------
        */
    }

    // Update is called once per frame
    void Update () {
        if (this.duel.winner == null || this.duel.looser == null)
        {
            this.duel.checkForWinner();
        }
        //        Debug.Log("xxxxxxxxxxx " + EventSystem.current.name);

        //        Debug.Log("Mouse Over: " + EventSystem.current.currentSelectedGameObject.name);
        
        /*
        if(listObjectInDeck != null)
        {
//            Debug.Log("liste not null");
            foreach(var obj in listObjectInDeck)
            {
  //              Debug.Log("obj");
//                if (obj.OnPointerEnter.IsInvoking())
                if (obj.IsInvoking("OnPointerEnter"))
                {
                    Debug.Log("obj on pointer enter ok");
                }

            }
        }*/
    }

    public void drawOneCard()
    {
        var hand1PositionX = player1Hand.transform.position.x;
        var hand1PositionY = player1Hand.transform.position.y;
        var hand1PositionZ = player1Hand.transform.position.z;

        var cardScaleX = 0.45f;
        var cardScaleY = 2.95f;
        var cardScaleZ = 0.8f;

        //draw card from logical list

        //then draw card from graphical list

        Debug.Log("what we have in deck 1 1.5 ==> " + listObjectInDeck.Count);
        var tmp = listObjectInDeck[listObjectInDeck.Count-1];
        Vector3 cardScale = new Vector3(cardScaleX, cardScaleY, cardScaleZ);

        //var tmp = listObjectInDeck[listObjectInDeck.Count-1].transform.SetParent(player1Hand.transform, false);
        listObjectInDeck.RemoveAt(listObjectInDeck.Count - 1);
        tmp.transform.SetParent(player1Hand.transform, false);
        tmp.transform.localScale = cardScale;
        Debug.Log("localScale ==> " + cardScale);

        tmp.gameObject.transform.tag = "yellow";
        tmp.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        //nM.transform.SetParent(Player1DeckZone.transform, false);
        //nM.transform.SetPositionAndRotation(new Vector3(deck1PositionX, deck1PositionY, deck1PositionZ), new Quaternion());
        //        Debug.Log("what we have in deck 1 3 ==> " + l.ToString());

    }

    public void summon1Monster()
    {
        //if normal monster level between 1 and 4 ==>no sacrifice
        //if normal monster level between 5 and 6 ==> 1 sacrifice
        //if normal monster level between 7 and more ==>2 sacrifice
        /////////////////////////////////////////////////////////////////
        //we get all monster zone positions to send card there
        var monsterZone1PosX = monsterZone1.transform.position.x;
        var monsterZone1PosY = monsterZone1.transform.position.y;
        var monsterZone1PosZ = monsterZone1.transform.position.z;

        var monsterZone2PosX = monsterZone2.transform.position.x;
        var monsterZone2PosY = monsterZone2.transform.position.y;
        var monsterZone2PosZ = monsterZone2.transform.position.z;

        var monsterZone3PosX = monsterZone3.transform.position.x;
        var monsterZone3PosY = monsterZone3.transform.position.y;
        var monsterZone3PosZ = monsterZone3.transform.position.z;

        var monsterZone4PosX = monsterZone4.transform.position.x;
        var monsterZone4PosY = monsterZone4.transform.position.y;
        var monsterZone4PosZ = monsterZone4.transform.position.z;

        var monsterZone5PosX = monsterZone5.transform.position.x;
        var monsterZone5PosY = monsterZone5.transform.position.y;
        var monsterZone5PosZ = monsterZone5.transform.position.z;
        
        var monsterZoneScaleX = 0.2608083f;
        var monsterZoneScaleY = 0.2792392f;
        var monsterZoneScaleZ = 0.2997899f;

        //list card in player hand
        var listObjectInHand = new List<NormalMonster>(player1Hand.GetComponentsInChildren<NormalMonster>());
        //temporary card that will be removed from hand when moved
        var tmp = listObjectInHand[0];
        //CARD scale on game field
        Vector3 cardScale = new Vector3(monsterZoneScaleX, monsterZoneScaleY, monsterZoneScaleZ);

        if (duel.player1SideField.monsterZone1IsEmpty()) {
            duel.player1SideField.monsterZone1.monsterPosition.Add(duel.FirstPlayer.hand[0]);
            //playerSide.monsterZone1.monsterPosition[playerSide.monsterZone1.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
            duel.FirstPlayer.hand.RemoveAt(0);
            //this.hand.splice(position, 1);

            listObjectInHand.RemoveAt(0);
            tmp.transform.SetParent(monsterZone1.transform, false);
            tmp.transform.localScale = cardScale;
            Debug.Log("mz1 ==> ");
        }
        else if (duel.player1SideField.monsterZone2IsEmpty()) {
            duel.player1SideField.monsterZone2.monsterPosition.Add(duel.FirstPlayer.hand[0]);
            //playerSide.monsterZone1.monsterPosition[playerSide.monsterZone1.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
            duel.FirstPlayer.hand.RemoveAt(0);
            //this.hand.splice(position, 1);

            listObjectInHand.RemoveAt(0);
            tmp.transform.SetParent(monsterZone2.transform, false);
            tmp.transform.localScale = cardScale;
            Debug.Log("mz2 ==> " );
        }
        else if (duel.player1SideField.monsterZone3IsEmpty()) {
            duel.player1SideField.monsterZone3.monsterPosition.Add(duel.FirstPlayer.hand[0]);
            //playerSide.monsterZone1.monsterPosition[playerSide.monsterZone1.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
            duel.FirstPlayer.hand.RemoveAt(0);
            //this.hand.splice(position, 1);

            listObjectInHand.RemoveAt(0);
            tmp.transform.SetParent(monsterZone3.transform, false);
            tmp.transform.localScale = cardScale;
            Debug.Log("mz3 ==> ");
        }
        else if (duel.player1SideField.monsterZone4IsEmpty()) {
            duel.player1SideField.monsterZone4.monsterPosition.Add(duel.FirstPlayer.hand[0]);
            //playerSide.monsterZone1.monsterPosition[playerSide.monsterZone1.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
            duel.FirstPlayer.hand.RemoveAt(0);
            //this.hand.splice(position, 1);


            listObjectInHand.RemoveAt(0);
            tmp.transform.SetParent(monsterZone4.transform, false);
            tmp.transform.localScale = cardScale;
            Debug.Log("mz4 ==> ");
        }
        else if (duel.player1SideField.monsterZone5IsEmpty()) {
            duel.player1SideField.monsterZone4.monsterPosition.Add(duel.FirstPlayer.hand[0]);
            //playerSide.monsterZone1.monsterPosition[playerSide.monsterZone1.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
            duel.FirstPlayer.hand.RemoveAt(0);
            //this.hand.splice(position, 1);

            duel.player1SideField.monsterZone1.monsterPosition.Add(duel.FirstPlayer.hand[0]);
            //playerSide.monsterZone1.monsterPosition[playerSide.monsterZone1.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
            duel.FirstPlayer.hand.RemoveAt(0);
            //this.hand.splice(position, 1);
            listObjectInHand.RemoveAt(0);
            tmp.transform.SetParent(monsterZone5.transform, false);
            tmp.transform.localScale = cardScale;
            Debug.Log("mz5 ==> " );
        }


        //tmp.transform.SetParent(monsterZone1.transform, false);

        //tmp.transform.SetPositionAndRotation(cardScale, new Quaternion());
    }


    //Generate all decks cards at deck positions
    void generateCardsTest(List<Card> d1)
    {
        listObjectInDeck = new List<NormalMonster>();

        var deck1PositionX = Player1DeckZone.transform.position.x;
        var deck1PositionY = Player1DeckZone.transform.position.y;
        var deck1PositionZ = Player1DeckZone.transform.position.z;
        float offsetZ = 0.4f;
        //double offsetY = 0.4;
        int count = 0;
        foreach(Monster monster in d1)
        {
            Debug.Log("monster "+count+" ==> "+ monster.GetNormalMonster().name);
            Debug.Log("monster "+count+ " atk ==> " + monster.GetNormalMonster().atk);
            
            //on génère les cartes face cachées
            monster.SetBackTrue();
            //on crée un objet 3d à la position du deck

            //NormalMonster nM = (NormalMonster)Instantiate(normalMonster);
            //NormalMonster nM = (GameObject)Instantiate(normalMonster);
            //GameObject nM = (GameObject)Instantiate(normalMonster);
            //GameObject nM = (GameObject)Instantiate(normalMonster);
            //=====> GameObject nM = (GameObject)Instantiate(normalMonster);
            NormalMonster nM = (NormalMonster)Instantiate(normalMonster);



            //            Card newCard = instantiate(cardPrefab, new Vector3(x, y, z), transform.rotation);
//            nM.gameObject.name = "azerty";
            nM.gameObject.name = "card"+count;
            //            nM = monster.GetNormalMonster();
            nM.name = monster.name;
            Debug.Log("aaaaaaaaaaaa "+ monster.name);
            nM.atk = (int)monster.attackPoints;
            nM.def = (int)monster.defensePoints;
            /*nM.lv = monster.stars;
            nM.monsterAttribute = monster.attribute;*/
            nM.monsterType = monster.type;
            nM.des = monster.description;

            listObjectInDeck.Add(nM);
            /*nM.name =
            newCard.gameObject.name = "someName";
            newCard.faceValue = value;
            newCard.suitValue = suitValue;*/

            //nM.GetComponent(NormalMonster).

            nM.transform.position = Player1DeckZone.transform.position;
            //sphere.transform.position = jaune.transform.position;
            nM.transform.SetParent(Player1DeckZone.transform, false);

            nM.transform.SetPositionAndRotation(new Vector3(deck1PositionX, deck1PositionY, deck1PositionZ), new Quaternion());
//            sphere.transform.SetPositionAndRotation(new Vector3(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z + increment), new Quaternion());


//            GameObject nM = (GameObject)Instantiate(normalMonster,);
            // Instantiate(blue);
//            normalMonster.transform.SetParent(new Transform())
           // normalMonster.transform.SetParent(Player1DeckZone.transform, false);
            deck1PositionZ -= offsetZ;
            //deck1PositionZ -= /*deck1PositionZ -*/ offsetZ;

            nM.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            count++;
        }
    }

    void displayCardInDetailArea()
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("SliderWheel: OnPointerEnter=" + eventData.pointerEnter.transform.parent.name);
        //Debug.Log("SliderWheel: OnPointerEnter=" + eventData.pointerEnter.transform.parent.parent.name);
     /*   var xxx = eventData.pointerEnter.transform.GetChild(1).gameObject.name;
        Debug.Log("zazazaza " + eventData.pointerEnter.transform.GetChild(1).gameObject.name);*/
//        eventData.pointerEnter.transform.gameObject
//        if (eventData.pointerEnter.transform.parent.tag == "yellow")
      /*  if (eventData.pointerEnter.transform.parent.tag == "yellow")
            activeSlider = GameObject.Find(eventData.pointerEnter.transform.parent.name).GetComponent<Slider>();
        else if (eventData.pointerEnter.transform.parent.parent.tag == "Slider")
            activeSlider = GameObject.Find(eventData.pointerEnter.transform.parent.parent.name).GetComponent<Slider>();
    */
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
