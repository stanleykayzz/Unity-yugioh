using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelGameManager : MonoBehaviour {

    //public List<Player> playerList;
    //un duel est composé de deux ou plusieurs joueurs
    public Player[] playerList;
    public Card[] deckCards;
    public CardZone myDeckZone;
    public GameObject myDeckZonePanel;
    public GameObject MonsterCardInstance;
    public GameObject preff;
    public float cardScaleX/* = 5*/, cardScaleY /*= 2.3f*/, cardScaleZ /*= 1*/;
    public double DeckPosX /*= 658*/, DeckPosY /*= 40*/, DeckPosZ/* = 1*/;


    public Transform myDeckPanel;
    // Use this for initialization
    void Start () {
        Debug.Log("On commence");
        //chaque joeurs fait un pierre papier ciseau
        //le gagnant choisisson tour
        //on génère les cartes sur le terrain
        Debug.Log("on génère les cartes sur le terrain");
        //generateDeck();
        //chaque joeuurs piochent 5 cartes
        //chaque joeurs pioche ses cartes
       // var myDeckPanel = GameObject.FindGameObjectsWithTag("myDeckPanel");
        var myDeckPanel = GameObject.Find("myDeckPanel");
        //var panel = GameObject.Find("myDeckPanel");
        if (myDeckPanel != null)  // make sure you actually found it!
        {
            GameObject a = (GameObject)Instantiate(preff);
            var components = a.GetComponentsInChildren<Text>();
            //to access values in card label
            Debug.Log(components[0].text);
            Debug.Log(components[1].text.ToString());
            Debug.Log(components[2]);
            Debug.Log(components[3]);
            Debug.Log(components[4]);

            a.transform.SetParent(myDeckPanel.transform, false);
           // a.transform.localScale = new Vector3(cardScaleX, cardScaleY, cardScaleZ);
            a.transform.localScale = new Vector3(cardScaleX, cardScaleY, cardScaleZ);
            //            a.transform.localScale(cardScaleX, cardScaleY, cardScaleZ);
            //            a.transform.SetParent(myDeckPanel.transform, false);
        }
        //-----------------duel loop ---------------------
        //on passe en dp du duel
        //le joueur pioche une carte
        //on passe les autres phases
        //on fait la somme des tours
        //si c'est le premier tour on ne peut pas attaquer
        //fin du tour
        //on reboucle

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void generateDeck()
    {
        //var deckPosition = myDeckZonePanel.GetComponent<GameObject>().transform.position;
        var deckPosition = myDeckZonePanel.transform.position;
        //double xScale = 49, yScale = 54, zScale = 0.02;
        //        double xPos = 652, yPos = 85, zPos = 50;
        Vector3 deckPos = new Vector3(652, 85, 50);
        Vector3 deckScale = new Vector3(49, 54, float.Parse("0.02"));
        //on crée 5 cartes pour commencer
        int j = 5;
       // int zPosition = 0;
        for(int i= 0; i < j; i++)
        {
            //            var createdCard = new GameObject("Card");
            //            var createdCard = new GameObject("preff");
            var createdCard = Instantiate(preff, deckPos,Quaternion.identity);
//            var createdCard = Instantiate(GameObject.FindGameObjectsWithTag("preff"), deckPos);
            //createdCard.GetComponent<>()
            //            createdCard.gameObject.transform.position.x = xPos;
            // createdCard.transform.position = new Vector3(transform.position.x/*float.Parse(xPos.ToString())*/, transform.position.y, transform.position.z);
            createdCard.transform.position = deckPos;
            createdCard.transform.localScale = deckScale;
            //            createdCard.transform.localScale.x = xScale;
            // createdCard.transform.localScale.x = xScale;

            /*createdCard.transform.position.x = xPos;
            createdCard.transform.position.x = xPos;*/
            // var createdCard = new Card();
            Debug.Log(" creating card number " + i);
            Debug.Log(" card created info  card number " + createdCard.ToString());

            //            createdCard.card.transform.GetComponents<GameObject>.tr
            //createdCard.card.transform.position.z = float.Parse(zPosition.ToString());

        }

    }
}
