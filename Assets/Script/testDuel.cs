using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testDuel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// var emptyDuelManager = (GameObject.FindGameObjectsWithTag("duelManagerTag"));
		// this.emptyDuelManager = Instantiate(GameObject.FindGameObjectsWithTag("duelManagerTag"));

		Debug.Log("on démarre le test");
		// Console.WriteLine("empty duel manager "+ emptyDuelManager);

		//on crée une carte
		var bursti = new Monster(4,1200,800,MonsterType.Warrior,MonsterAttribute.Fire,"Burstinatrix Hero elementaire","hero manipulatrice du feu",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		var whiteDragon = new Monster(4,3000,2500,MonsterType.Dragon,MonsterAttribute.Light,"dragon blanc aux yeux blancs","dragon de lumiere",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		var blackDragon = new Monster(4,2500,2000,MonsterType.Dragon,MonsterAttribute.Dark,"Burstinatrix Hero elementaire","dragon malefique",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		var fgd = new Monster(4,1200,800,MonsterType.Dragon,MonsterAttribute.Dark,"Five God Dragon ","le dieu dragon",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		var kumori = new Monster(4,1500,800,MonsterType.Dragon,MonsterAttribute.Dark,"Dragon Kumori","dragon des tenebres",false,true,(Image)Resources.Load("Assets/CardLayout/ElementalHEROBurstinatrix-TF04-JP-VG"));
		
		Debug.Log("carte 1 ==> "+bursti.name);
		Debug.Log("carte 2 ==> "+whiteDragon.name);
		Debug.Log("carte 3 ==> "+blackDragon.name);
		Debug.Log("carte 4 ==> "+fgd.name);
		Debug.Log("carte 5 ==> "+kumori.name);

		// Console.WriteLine("fgd to string ==> "+fgd.ToString());

        var deck1 = new List<Card> {
			whiteDragon,kumori,bursti,whiteDragon,kumori,bursti,whiteDragon,fgd,whiteDragon,fgd,fgd,fgd,fgd,whiteDragon,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd			
        };
        var deck2 = new List<Card> {
			whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,whiteDragon,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd,fgd			
        };

		Debug.Log("deck 1  count ==> "+deck1.Count+ " name card3 ==> "+deck1[2].name);
		Debug.Log("deck 2  count ==> "+deck2.Count+ " name card32 ==> "+deck2[31].name);

		// On crée les decks des deux joueurs
		Player yugi = new Player("Yugi Muto",8000,deck1,null,new List<Card>(),null,null,new TurnManager(),false);
		Player kaiba = new Player("Seto Kaiba",8000,deck2,null,new List<Card>(),null,null,new TurnManager(),false);

		Debug.Log("player 1 ==> "+yugi.pseudo);
		Debug.Log("player 2 ==> "+kaiba.pseudo);

		// On crée deux joueurs pour démarrer la partie
		var duelists = new List<Player>{
			yugi,kaiba
		};
		DuelGameManager duel = new DuelGameManager(duelists);

		// Debug.Log("duel game manager ==> "+duel);
		
		// les deux players font un rock paper pour déterminer l'ordre 

		// le gagnant choisis l'ordre		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
