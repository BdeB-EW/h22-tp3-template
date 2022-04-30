using UnityEngine;
using UnityEngine.AI;

public class EtatMarche : EtatVillageois
{
    private Vector3 destinationPoint;

    public EtatMarche(GameObject villageois, Vector3 destination) : base(villageois)
    {
        destinationPoint = destination;
    }

    public override void Enter()
    {
        Animateur.SetBool("Run", true);
        AgentAI.SetDestination(destinationPoint);
    }

    public override void Handle()
    {
        if (!AgentAI.pathPending && AgentAI.remainingDistance <= AgentAI.stoppingDistance)
        {
            DeplacementVillageois deplacement = Villageois.GetComponent<DeplacementVillageois>();
            deplacement.ChangerEtat(deplacement.Inactif);
        }
    }

    public override void Exit()
    {
        Animateur.SetBool("Run", false);
    }
}