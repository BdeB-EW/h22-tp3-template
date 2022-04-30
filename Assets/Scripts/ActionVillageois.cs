using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe qui contient les actions qu'un villageois peut faire
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class ActionVillageois : GenerateurAction
{
    private GameObject gameManager;
    private Action[] actionsVillageois;

    private void Start()
    {
        Actions actions = GameObject.Find("GameManager").GetComponent<Actions>();
        actionsVillageois = new Action[2];
        actionsVillageois[0] = actions.NouvelleFerme;
        actionsVillageois[1] = actions.NouvelleMaison;
    }

    public override Action[] GetActions()
    {
        return actionsVillageois;
    }

    public override void Action0()
    {
        GameObject[] fermes = GameObject.FindGameObjectsWithTag("Ferme");
        if (fermes.Length < 4)
        {
            gameObject.GetComponent<DeplacementVillageois>().ChangerEtat(new EtatConstruireFerme(gameObject));
            actionsVillageois[0].RetirerRessources();
        }
        GetComponent<DeplacementVillageois>().Selectionne = false;
    }

    public override void Action1()
    {
        GameObject[] maisons = GameObject.FindGameObjectsWithTag("Maison");
        if (maisons.Length < 8)
        {
            gameObject.GetComponent<DeplacementVillageois>().ChangerEtat(new EtatConstruireMaison(gameObject));
            actionsVillageois[1].RetirerRessources();
        }
        GetComponent<DeplacementVillageois>().Selectionne = false;
    }

    public override void Action2()
    {
    }
}
