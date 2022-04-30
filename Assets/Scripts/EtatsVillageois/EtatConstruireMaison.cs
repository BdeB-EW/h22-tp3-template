using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatConstruireMaison : EtatVillageois
{
    private Maisons lesMaisons;
    private Vector3 positionMaison;

    public EtatConstruireMaison(GameObject villageois) : base(villageois)
    {
    }

    public override void Enter()
    {
        lesMaisons = GameObject.Find("GameManager").GetComponent<Maisons>();
        positionMaison = lesMaisons.ProchaineMaison.transform.position;
        AgentAI.SetDestination(positionMaison);
        Animateur.SetBool("Run", true);
    }

    public override void Exit()
    {
        Animateur.SetBool("Run", false);
    }

    public override void Handle()
    {
        if (! AgentAI.pathPending && AgentAI.remainingDistance <= AgentAI.stoppingDistance)
        {
            lesMaisons.ConstruireMaison(positionMaison);
            MachineEtat.ChangerEtat(new EtatInactif(Villageois.gameObject));
        }
    }
}
