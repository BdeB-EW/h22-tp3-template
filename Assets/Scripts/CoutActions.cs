using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoutActions
{
    public static CoutActions instance = new CoutActions();

    public static CoutActions Instance
    {
        get { return instance; }
    }

    private int[] coutVillageois;
    public int[] CoutVillageois
    {
        set { coutVillageois = value; }
        get { return coutVillageois; }
    }

    private int[] coutFerme;
    public int[] CoutFerme
    {
        set { coutFerme = value; }
        get { return coutFerme; }
    }

    private int[] coutMaison;
    public int[] CoutMaison
    {
        set { coutMaison = value; }
        get { return coutMaison; }
    }


    private CoutActions()
    {
    }
}
