using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatConstruireFerme : EtatVillageois
{
    private Fermes lesFermes;
    private Vector3 positionFerme;
    private GameObject laFerme;

    public EtatConstruireFerme(GameObject villageois) : base(villageois)
    {
    }

    public override void Enter()
    {
        lesFermes = GameObject.Find("GameManager").GetComponent<Fermes>();
        laFerme = lesFermes.ProchaineFerme;

        if (laFerme == null)
        {
            MachineEtat.ChangerEtat(new EtatInactif(Villageois.gameObject));
        }
        else
        {
            positionFerme = laFerme.transform.position;
            AgentAI.SetDestination(positionFerme);
            Animateur.SetBool("Run", true);
        }

    }

    public override void Exit()
    {
        Animateur.SetBool("Run", false);
    }

    public override void Handle()
    {
        if (!AgentAI.pathPending && AgentAI.remainingDistance <= AgentAI.stoppingDistance)
        {
            lesFermes.ConstruireFerme(positionFerme);
            Ressource nouvelleRessource = laFerme.AddComponent<Ressource>();
            nouvelleRessource.Type = "Nourriture";
            nouvelleRessource.QuantiteDisponible = 50;
            MachineEtat.ChangerEtat(new EtatTravail(Villageois.gameObject, laFerme));
        }
    }
}
