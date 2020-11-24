using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelGameManager : MonoBehaviour {

    //public List<Player> playerList;
    //un duel est composé de deux ou plusieurs joueurs
    //dans notrecas deux joueurs car duel simple
    public Player FirstPlayer, SecondPlayer;
    public List<Player> playerList, duelists ;
    // public Player[] playerList, duelists ;
    public int countTurns;
    public Player winner, looser, draw;
    public List<Card> playerDeck;
    // public List<Card>[] playerDeck;
    // public List<Card> playerHand1,playerHand2;
    // public CardZone myDeckZone;
    // public GameObject myDeckZonePanel;
    // public GameObject MonsterCardInstance;
    // public GameObject preff;
    // public float cardScaleX/* = 5*/, cardScaleY /*= 2.3f*/, cardScaleZ /*= 1*/;
    // public double DeckPosX /*= 658*/, DeckPosY /*= 40*/, DeckPosZ/* = 1*/;
    public int turnCounter;
    public int counterForTurn;

    public bool canBegin;
    public bool endDuel;
    public TurnManager duelTurn;
    // public Transform myDeckPanel;

    // draw: Player[];
    // GameField: GameField;

    // Use this for initialization
    // void Start () {
    //     Debug.Log("On commence");
    //     //chaque joeurs fait un pierre papier ciseau
    //     //le gagnant choisisson tour
    //     //on génère les cartes sur le terrain
    //     Debug.Log("on génère les cartes sur le terrain");
    //     //generateDeck();
    //     //chaque joeuurs piochent 5 cartes
    //     //chaque joeurs pioche ses cartes
    //    // var myDeckPanel = GameObject.FindGameObjectsWithTag("myDeckPanel");
    //     var myDeckPanel = GameObject.Find("myDeckPanel");
    //     //var panel = GameObject.Find("myDeckPanel");
    //     if (myDeckPanel != null)  // make sure you actually found it!
    //     {
    //         GameObject a = (GameObject)Instantiate(preff);
    //         var components = a.GetComponentsInChildren<Text>();
    //         //to access values in card label
    //         Debug.Log(components[0].text);
    //         Debug.Log(components[1].text.ToString());
    //         Debug.Log(components[2]);
    //         Debug.Log(components[3]);
    //         Debug.Log(components[4]);

    //         a.transform.SetParent(myDeckPanel.transform, false);
    //        // a.transform.localScale = new Vector3(cardScaleX, cardScaleY, cardScaleZ);
    //         a.transform.localScale = new Vector3(cardScaleX, cardScaleY, cardScaleZ);
    //         //            a.transform.localScale(cardScaleX, cardScaleY, cardScaleZ);
    //         //            a.transform.SetParent(myDeckPanel.transform, false);
    //     }
    //     //-----------------duel loop ---------------------
    //     //on passe en dp du duel
    //     //le joueur pioche une carte
    //     //on passe les autres phases
    //     //on fait la somme des tours
    //     //si c'est le premier tour on ne peut pas attaquer
    //     //fin du tour
    //     //on reboucle

    // }

    // Update is called once per frame
    // void Update () {
		
	// }

    public DuelGameManager(List<Player> duelists)
    {
        Debug.Log("duel gamemanager created");
        //On crée le duel entre deux joueurs
        this.playerList = duelists;

        // on crée le deck de chaque joueurs en commencant par le first
        // generatePlayerDeck(FirstPlayer);
        Debug.Log("On créé visuellement toutees les cartes utilisé ici");

        //on crée le gestionnaire de tours
        TurnManager turn = new TurnManager();

        this.counterForTurn = 0;
        this.winner = null;
        this.looser = null;
        this.draw = null;
        this.duelists = playerList;
        //        this.GameField = new GameField();
        // this.GameField = new GameField(new PlayerSideField(), new PlayerSideField());
        this.countTurns = 0;
        this.FirstPlayer = this.duelists[0];//on met le premier en premier pour tests
        this.SecondPlayer = this.duelists[1];//on met le premier en 2nd pour tests

        //on shuffle le deck des joueurs
        this.duelists[0].shuffleDeck();
        this.duelists[1].shuffleDeck();

        //on pioche 5 cartes pour chaque joueurs
        this.duelists[0].beginingDuelDraw();
        this.duelists[1].beginingDuelDraw();
        for(int startupHand = 1; startupHand < 5; startupHand++)
        {
            this.FirstPlayer.drawCard();
            this.SecondPlayer.drawCard();
        }

        Debug.Log("duelist 1 hand count ==> "+this.duelists[0].hand.Count);
        Debug.Log("duelist 2 hand count ==> "+this.duelists[1].hand.Count);

    //     /*
    //     this.drawCard(this.duelists[0], 5);
    //     this.drawCard(this.duelists[1], 5);*/

    //     ///// DuelUntilVictory
        this.canBegin = true;
        //checking for a winner until one is selected
       this.duelManagerCheckTurn();


    }

//     public void generateDeckkk()
//     {
//         var x = Resources.Load("folder/file");
//         //var deckPosition = myDeckZonePanel.GetComponent<GameObject>().transform.position;
//         var deckPosition = myDeckZonePanel.transform.position;
//         //double xScale = 49, yScale = 54, zScale = 0.02;
//         //        double xPos = 652, yPos = 85, zPos = 50;
//         Vector3 deckPos = new Vector3(652, 85, 50);
//         Vector3 deckScale = new Vector3(49, 54, float.Parse("0.02"));
//         //on crée 5 cartes pour commencer
//         int j = 5;
//        // int zPosition = 0;
//         for(int i= 0; i < j; i++)
//         {
//             //            var createdCard = new GameObject("Card");
//             //            var createdCard = new GameObject("preff");
//             var createdCard = Instantiate(preff, deckPos,Quaternion.identity);
// //            var createdCard = Instantiate(GameObject.FindGameObjectsWithTag("preff"), deckPos);
//             //createdCard.GetComponent<>()
//             //            createdCard.gameObject.transform.position.x = xPos;
//             // createdCard.transform.position = new Vector3(transform.position.x/*float.Parse(xPos.ToString())*/, transform.position.y, transform.position.z);
//             createdCard.transform.position = deckPos;
//             createdCard.transform.localScale = deckScale;
//             //            createdCard.transform.localScale.x = xScale;
//             // createdCard.transform.localScale.x = xScale;

//             /*createdCard.transform.position.x = xPos;
//             createdCard.transform.position.x = xPos;*/
//             // var createdCard = new Card();
//             Debug.Log(" creating card number " + i);
//             Debug.Log(" card created info  card number " + createdCard.ToString());

//             //            createdCard.card.transform.GetComponents<GameObject>.tr
//             //createdCard.card.transform.position.z = float.Parse(zPosition.ToString());

//         }

//     }

    public void generatePlayerDeck(Player player)
    {
        Debug.Log("creating deck of player "+player);
        // if(player == playerList[0])
        // {
        //     //pour chaque cartes dans le deck on cree une carte avec ses infos
        //     foreach (var card in player.deck)
        //     {                
        //         //c est une carte avec les data
        //         playerDeck[0].Add(card);
        //         Debug.Log("player1 created card name ==> ", card.name);
        //         // playerDeck[0].Add(card);
        //         // Debug.Log("player1 created card name ==> ", card.name);
        //     }
        // }
        // else
        // {
        //     foreach (var card in player.deck)
        //     {
        //         //c est une carte avec les data
        //         playerDeck[1].Add(card);
        //         Debug.Log("player2 created card name ==> ", card.name);

        //     }
        // }
    }


    public void playerDrawCard(Player playerDrawing,int count=1)
    {
        // if(playerDrawing == playerList[0])
        // {
        //     for(int i = 0 ; i < count; i++)
        //     {
        //         Card card = new Card();
        //     }
        //     foreach(var card in playerDrawing.deck)
        //     {
        //         playerHand1.Add(card);
        //     }
        // }
    }


    /*
    drawCard(player:Player,many: number = 1): void {
        var c = 0;
        //On recupère la carte au sommet du deck et on l'ajoute à la main si il y a au moins une carte dans le deck
        if (player.deck.length > 0) {
            Debug.Log("tu as des cartes dans le deck donc on pioche");
            while (c < many) {
                player.hand.push(player.deck.pop());
                c += 1;
            }
        }
        else {
            while (c < many) {
                player.hand.push(player.deck.pop());
                c += 1;
            }
            Debug.Log("vous n'avez plus de carte dans le deck");
            this.looser = player;
        }
    }*/

    public void summonMonster(Player player,PlayerSideField playerSide, int handCardPosition) {
        // if (player.canNormalSummon == true) {
        //     if (playerSide.monsterZone1IsEmpty) {
        //         playerSide.monsterZone1.monsterPosition.push(player.hand[handCardPosition]);
        //         player.hand.splice(handCardPosition, 1);
        //     }
        //     else if (playerSide.monsterZone2IsEmpty) {
        //         Debug.Log("Le deuxième zM est vide");
        //         playerSide.monsterZone2.monsterPosition.push(player.hand[handCardPosition]);
        //         player.hand.splice(handCardPosition, 1);
        //     }
        //     else if (playerSide.monsterZone3IsEmpty) {
        //         Debug.Log("Le troisième zM est vide");
        //         playerSide.monsterZone3.monsterPosition.push(player.hand[handCardPosition]);
        //         player.hand.splice(handCardPosition, 1);
        //     }

        //     else if (playerSide.monsterZone4IsEmpty) {
        //         Debug.Log("Le quatrième zM est vide");
        //         playerSide.monsterZone4.monsterPosition.push(player.hand[handCardPosition]);
        //         player.hand.splice(handCardPosition, 1);
        //     }
        //     else if (playerSide.monsterZone5IsEmpty) {
        //         Debug.Log("Le cinquième zM est vide");
        //         playerSide.monsterZone5.monsterPosition.push(player.hand[handCardPosition]);
        //         player.hand.splice(handCardPosition, 1);
        //     }
        //     //On ne fait qu'une invocation normale par tour donc après cNs is false
        //     player.canNormalSummon = false;
        // }
        // else if (player.canNormalSummon == false) {
        //     Debug.Log("Vous avez deja fait une invocation normal ce tour");
        // }
    }

    public void surrender(Player losingPlayer) {
        Debug.Log("Le joueur " + losingPlayer.pseudo + " viens d'abondonner");
        this.looser = losingPlayer;
        if (this.looser.pseudo == this.FirstPlayer.pseudo)
            this.winner = this.SecondPlayer;
        else
            this.winner = this.FirstPlayer;
        // return this;
    }

    public void checkForWinner(){
        if (this.duelists[0].getLifePoints() <= 0) {
            this.looser = this.duelists[0];
            Debug.Log(" " + this.duelists[0] + " loose and " + this.duelists[1] + " win");
            this.winner = this.duelists[1];
        }
        else if (this.duelists[1].getLifePoints() <= 0) {
            this.looser = this.duelists[1];
            Debug.Log(" " + this.duelists[1] + " loose and " + this.duelists[0] + " win");
            this.winner = this.duelists[0];
        }
    }

    //Fonction qui va gérer le bon déroulement du duel jusqu'à la victoire d'un des joueurs
    public void duelManagerCheckTurn(/*listOfPlayers: Player[]*/)
    {
        Debug.Log("turn handler");
        if (this.winner == null || this.looser == null || this.draw == null)
        {
            //au début les deux ne peuvent pas jouer donc on met le premier a true
            if (this.duelists[0].turnToPlay == false && this.duelists[1].turnToPlay == false)
            {
                //on fait jouer chacun tour à tour
                this.duelists[this.counterForTurn].turnToPlay = true;
                if (this.duelists[this.counterForTurn].playerTurn.EndPhase == true)
                {
                    this.duelists[this.counterForTurn].turnToPlay = false;
                    if (this.counterForTurn == 0)
                    {
                        this.counterForTurn = 1;
                    }
                    else
                    {
                        this.counterForTurn = 0;
                    }
                    this.duelists[this.counterForTurn].turnToPlay = true;
                }
            }
            else if (this.duelists[0].turnToPlay == true && this.duelists[1].turnToPlay == false)
            {
                if (this.duelists[0].playerTurn.EndPhase == true)
                {
                    this.duelists[0].turnToPlay = false;
                    this.duelists[1].turnToPlay = true;
                    this.countTurns += 1;

                }
                else if (this.duelists[1].turnToPlay == true && this.duelists[0].turnToPlay == false)
                {
                    if (this.duelists[1].playerTurn.EndPhase == true)
                    {
                        this.duelists[1].turnToPlay = false;
                        this.duelists[0].turnToPlay = true;
                        this.countTurns += 1;

                    }
                }

            }
        }
    }

}
