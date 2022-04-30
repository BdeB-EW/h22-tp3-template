using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action
{
    public Sprite ImageIcon
    {
        private set;
        get;
    }

    public int CoutBois
    {
        private set;
        get;
    }

    public int CoutPierre
    {
        private set;
        get;
    }

    public int CoutFood
    {
        private set;
        get;
    }

    public int CoutOr
    {
        private set;
        get;
    }

    public Action(Sprite icon, int wood, int rock, int food, int gold)
    {
        ImageIcon = icon;
        CoutBois = wood;
        CoutPierre = rock;
        CoutFood = food;
        CoutOr = gold;
    }

    public void RetirerRessources()
    {
        RessourceManager.Instance.ReserveBois -= CoutBois;
        RessourceManager.Instance.ReserveNourriture -= CoutFood;
        RessourceManager.Instance.ReservePierre -= CoutPierre;
        RessourceManager.Instance.ReserveOr -= CoutOr;
    }
}
