using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour, ICard{
    public string name;
    public Image cardArt;
    public string description;
    public bool front;
    public bool back;
    public GameObject card;
    public bool faceUp = false;

    /*Image ICard.cardArt
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
            throw new System.NotImplementedException();
        }
    }

    string ICard.description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    bool ICard.back { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    bool ICard.faceUp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool faceDown { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }*/

    public Card()
    {
        this.name = "a";
        this.description = "b";
        /*this.front = front;
        this.back = back;
        this.cardArt = art;*/
        this.card = new GameObject();
    }

    public Card(string name, string des, bool front, bool back, Image art)
    {
        this.name = name;
        this.description = des;
        this.front = front;
        this.back = back;
        this.cardArt = art;
        //this.card = art;
    }

    public void SetCard()
    {
        SetBackTrue();
    }
    public void SetFrontTrue()
    {
        this.back = false;
        this.front = true;
    }
    public void SetBackTrue()
    {
        this.front = false;
        this.back = true;
    }
    public void toggleCard()
    {

    }

    public void setCard()
    {
        throw new System.NotImplementedException();
    }

    public void setFaceUp()
    {
        throw new System.NotImplementedException();
    }

    public void setFaceDown()
    {
        throw new System.NotImplementedException();
    }
}
