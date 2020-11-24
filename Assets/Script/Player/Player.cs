using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player /*: MonoBehaviour*/ {

    public string playerId;
    public string email;
    public string password;
    public string pseudo;
    public List<Card> deck;

    public int lifePoints;
    public List<Card> sideDeck;
    public Card[] Trunk;
    public List<Card> hand;
    // public Card[] hand;
    public TurnManager playerTurn;
    public bool canAttack;
    public bool canNormalSummon;
    public List<Card> extraDeck;
    public bool turnToPlay = false;
    
    // public Player()
    // {
    // }

    public Player()
    {
        // deck = new List<Card> {
        //     new Monster(8,3000,2500,MonsterType.Dragon,MonsterAttribute.Light,"dragon blanc aux yeux blancs",
        //     "dragon super puissant",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"))
        // };

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Player(string nom, int lp, List<Card> deck, List<Card> trunk, List<Card> hand, List<Card> side,List<Card> extra,TurnManager myTurn,bool IcanSummon) {
        this.pseudo = nom;
        this.lifePoints = lp;
        this.deck = deck;
        //this.sideDeck: Card;
        //this.Trunk: Card;
        this.hand = hand;
        this.playerTurn = myTurn;
        //this.canNormalSummon: boolean;
        //this.extraDeck: Card;
    }

    // public Player(string nom,int lp,List<Card> deck,List<Card> hand) {
    //     this.playerID = 0;
    //     this.pseudo = nom;
    //     this.lifePoints = lp;
    //     this.deck = deck;
    //     this.hand = hand;
    //     this.playerTurn = new TurnManager();
    // }

    // public Player(string name, int id) {
    //     this.playerID = id;
    //     this.pseudo = name;
    //     this.lifePoints = 0;
    //     this.canNormalSummon = true;
    //     this.canAttack = false;
    //     this.deck = new List<Card>();
    //     this.hand = new List<Card>();
    //     this.turnToPlay = false;
    //     this.playerTurn = new TurnManager();
    // }

    public int getLifePoints(){
        return this.lifePoints;
    }

    public void newTurn(Player parameterPlayer) {
        this.playerTurn = new TurnManager(/*parameterPlayer*/);
    }
    
   /* directAttack(positionMonsterOnField:number,positionTargetAttack:number): void {
        // TODO implement here

    }*/
    
    public void summonMonster(PlayerSideField playerSide, int position){
        // if (this.canNormalSummon == true) {
        //     Debug.Log("Vous pouvez faire une invocation normal ce tour");
        //     if (playerSide.monsterZone1IsEmpty() == true ) {
        //         Debug.Log("La première zone monstre est vide");
        //         playerSide.monsterZone1.monsterPosition.push(this.hand[position]);
        //         playerSide.monsterZone1.monsterPosition[playerSide.monsterZone1.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
        //         this.hand.splice(position, 1);
        //     }
        //     else if (playerSide.monsterZone2IsEmpty() == true ) {
        //         Debug.Log("La deuxième zone monstre est vide");
        //         playerSide.monsterZone2.monsterPosition.push(this.hand[position]);
        //         playerSide.monsterZone2.monsterPosition[playerSide.monsterZone2.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
        //         this.hand.splice(position, 1);
        //     }
        //     else if (playerSide.monsterZone3IsEmpty() == true ) {
        //         Debug.Log("La troisième zone monstre est vide");
        //         playerSide.monsterZone3.monsterPosition.push(this.hand[position]);
        //         playerSide.monsterZone3.monsterPosition[playerSide.monsterZone3.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
        //         this.hand.splice(position, 1);
        //     }
        //     else if (playerSide.monsterZone4IsEmpty() == true ) {
        //         Debug.Log("La quatrième zone monstre est vide");
        //         playerSide.monsterZone4.monsterPosition.push(this.hand[position]);
        //         playerSide.monsterZone4.monsterPosition[playerSide.monsterZone4.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
        //         this.hand.splice(position, 1);
        //     }
        //     else if (playerSide.monsterZone5IsEmpty() == true ) {
        //         Debug.Log("La cinquième zone monstre est vide");
        //         playerSide.monsterZone5.monsterPosition.push(this.hand[position]);
        //         playerSide.monsterZone5.monsterPosition[playerSide.monsterZone5.monsterPosition.length - 1].faceMode = monsterFightMode.faceUpAttack;
        //         this.hand.splice(position, 1);
        //     }
        //     this.canNormalSummon = false;
        // }
        // else if (this.canNormalSummon == false) {
        //     Debug.Log("Vous avez deja fait une invocation normal ce tour");
        // }
    }

    // setMonster(playerSide: PlayerSideField, myCard: Monster): void {
    //     // TODO implement here
    //     if (playerSide.monsterZone1IsEmpty)
    //         playerSide.monsterZone1.monsterPosition.push(myCard)
    //     else if (playerSide.monsterZone2IsEmpty)
    //         playerSide.monsterZone2.monsterPosition.push(myCard)
    //     else if (playerSide.monsterZone3IsEmpty)
    //         playerSide.monsterZone3.monsterPosition.push(myCard)
    //     else if (playerSide.monsterZone4IsEmpty)
    //         playerSide.monsterZone4.monsterPosition.push(myCard)
    //     else if (playerSide.monsterZone5IsEmpty)
    //         playerSide.monsterZone5.monsterPosition.push(myCard)
    // }
    
    // setCardInTMZone() :  void {
    //     // TODO implement here
    // }

    public void shuffleDeck(){        
        Debug.Log("Moi, le joueur " + this.pseudo + " Je bat mes cartes pour bien les mélanger ");
    }

    public void beginingDuelDraw(){
        Debug.Log("C'est le début du duel donc " + this.pseudo + " pioche 5 cartes");
        //on ajoute les 5 cartes du dessus du deck dans la main du joueur
        this.drawCard(5);
    }

    public void drawCard(int countCards = 1){
        // var c = 0;
        //On recupère la carte au sommet du deck et on l'ajoute à la main si il y a au moins une carte dans le deck
        if (this.deck.Count > 0) {
            Debug.Log(this.pseudo+" a des cartes dans le deck donc on pioche ");
            //while (c < many) {
                this.hand.Add(this.deck.Last());
                this.deck.RemoveAt(this.deck.Count - 1);
                // this.hand.push(this.deck.pop());
              //  c += 1;
            //}
        }
        else {
            //while (c < many) {
              //  this.hand.push(this.deck.pop());
                //c += 1;
            //}
            Debug.Log(this.pseudo+" n'a plus de carte dans le deck");
            //this.loser = player;
        }
        Debug.Log(this.pseudo + " drawed a card and has "+ this.hand.Count+" cards in his hand,  "+this.deck.Count+" in his deck");
    }
    
    public void goToDrawPhase(){
        this.playerTurn.StandByPhase = false;
        this.playerTurn.DrawPhase = true;
        Debug.Log("DP");
        this.drawCard();
    }
    public void goToStandByPhase(){
        this.playerTurn.EndPhase = false;
        this.playerTurn.StandByPhase = true;
        Debug.Log("SP");
    }
    public void goToMainPhase1(){
        this.playerTurn.StandByPhase = false;
        this.playerTurn.MainPhase1 = true;
        Debug.Log("MP1");
    }
    public void goToBattlePhase(){
        this.playerTurn.MainPhase1 = false;
        this.playerTurn.BattlePhase = true;
        Debug.Log("BP");
    }
    public void goToMainPhase2(){
        this.playerTurn.BattlePhase = false;
        this.playerTurn.MainPhase2 = true;
        Debug.Log("MP2");
    }
    public void goToEndPhase(){
        //on peut passer de la mp1, de la mp2 ou de la bp à la ep
        this.playerTurn.MainPhase1 = false;
        this.playerTurn.BattlePhase = false;
        this.playerTurn.MainPhase2 = false;
        this.playerTurn.EndPhase = true;
        Debug.Log("EP");

        // this.duelManager();

    }



}
