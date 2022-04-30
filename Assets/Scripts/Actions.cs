using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe qui comprend les différentes actions. Les actions sont affichées dans le HUD quand un objet est sélectionné.
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class Actions : MonoBehaviour
{
    public Action NouveauVillageois
    {
        private set;
        get;
    }

    public Action NouvelleFerme
    {
        private set;
        get;
    }

    public Action NouvelleMaison
    {
        private set;
        get;
    }

    private void Awake()
    {
        int[] tab = CoutActions.Instance.CoutVillageois;
        NouveauVillageois = new Action(GameObject.Find("ImageVillageois").GetComponent<SpriteRenderer>().sprite, tab[0], tab[1], tab[2], tab[3]);

        tab = CoutActions.Instance.CoutFerme;
        NouvelleFerme = new Action(GameObject.Find("ImageFerme").GetComponent<SpriteRenderer>().sprite, tab[0], tab[1], tab[2], tab[3]);

        tab = CoutActions.Instance.CoutMaison;
        NouvelleMaison = new Action(GameObject.Find("ImageMaison").GetComponent<SpriteRenderer>().sprite, tab[0], tab[1], tab[2], tab[3]);
    }
}
