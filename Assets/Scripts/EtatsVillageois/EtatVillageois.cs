using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui represente l'�tat d'un villageois
/// 
/// Auteur: Eric Wenaas
/// </summary>
public abstract class EtatVillageois
{
    /// <summary>
    /// Le villageois qui est vis� par l'�tat
    /// </summary>
    protected DeplacementVillageois Villageois
    {
        get;
        set;
    }

    protected NavMeshAgent AgentAI
    {
        set;
        get;
    }

    protected Animator Animateur
    {
        set;
        get;
    }

    protected DeplacementVillageois MachineEtat
    {
        set;
        get;
    }

    /// <summary>
    /// Permet de construire un EtatVillageois. 
    /// </summary>
    /// <param name="joueur">La r�f�rence sur le villageois</param>
    public EtatVillageois(GameObject joueur)
    {
        Villageois = joueur.GetComponent<DeplacementVillageois>();
        AgentAI = joueur.GetComponent<NavMeshAgent>();
        Animateur = joueur.GetComponent<Animator>();
        MachineEtat = joueur.GetComponent<DeplacementVillageois>();
    }

    public abstract void Enter();
    public abstract void Handle();
    public abstract void Exit();
}
