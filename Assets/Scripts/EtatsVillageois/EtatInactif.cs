using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatInactif : EtatVillageois
{
    private Vector3 spawnPoint;
    public EtatInactif(GameObject villageois) : base(villageois)
    {
        GameObject hotelDeVille = GameObject.Find("HotelDeVille");
        spawnPoint = hotelDeVille.GetComponent<ActionsHotelVille>().SpawnPoint;
    }

    public override void Enter()
    {
        AgentAI.SetDestination(spawnPoint);
        Animateur.SetBool("Run", true);
    }

    public override void Exit()
    {
        Animateur.SetBool("Run", false);
    }

    public override void Handle()
    {
        if (!AgentAI.pathPending && AgentAI.remainingDistance <= AgentAI.stoppingDistance)
        {
            Animateur.SetBool("Run", false);
        }
    }
}
