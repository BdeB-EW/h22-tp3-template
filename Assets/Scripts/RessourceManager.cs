using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class RessourceManager
{
    private static RessourceManager instance = new RessourceManager();

    internal float ReserveOr
    {
        get;
        set;
    }

    internal float ReserveBois
    {
        set;
        get;
    }

    internal float ReservePierre
    {
        set;
        get;
    }

    internal float ReserveNourriture
    {
        set;
        get;
    }

    private RessourceManager()
    {
        Initialiser();
    }

    internal void Initialiser()
    {
        ReserveOr = 0;
        ReserveBois = 0;
        ReservePierre = 0;
        ReserveNourriture = 0;
    }

    internal static RessourceManager Instance
    {
        get { return instance; }
    }

    internal bool ActionPossible(Action uneAction)
    {
        bool possible = ReserveBois >= uneAction.CoutBois;
        possible = possible && ReservePierre >= uneAction.CoutPierre;
        possible = possible && ReserveNourriture >= uneAction.CoutFood;
        possible = possible && ReserveOr >= uneAction.CoutOr;
        return possible;
    }


}
