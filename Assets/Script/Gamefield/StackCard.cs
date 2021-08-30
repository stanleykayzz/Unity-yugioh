using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCard {

//    public Stack<Card> cardList;
    public List<Card> cardList;

    public StackCard()
    {
//        this.cardList = new Stack<Card>();
        this.cardList = new List<Card>();
    }

    public StackCard(List<Card> list)
    {
                this.cardList = list;
        //this.cardList = (List<Card>)list;
        //        this.cardList = list;
    }
    
    public int getListSize()
    {
        return this.cardList.Count;
    }


    ////////////////////////////////// Implementer fonctions pop() ==> retourner l'objet au haut de la liste et le supprimer dela liste /////////////////////////

    ////////////////////////////////// Implementer fonctions peek() ==> retourner l'objet au haut de la liste sans le supprimer dela liste /////////////////////////

    ////////////////////////////////// Implementer fonctions push() ==> ajouter l'objet au haut de la liste et retourner la liste/////////////////////////

    ////////////////////////////////// Implementer fonctions sort() ==>  /////////////////////////

    ////////////////////////////////// Implementer fonctions shuffle() ==>  /////////////////////////
}
