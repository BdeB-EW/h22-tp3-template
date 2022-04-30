using UnityEngine;

public class RamenerRessource : EtatVillageois
{
    private Ressource ressourceRetour;
    private GameObject depot;

    public RamenerRessource(GameObject villageois, Ressource ressource) : base(villageois)
    {
        ressourceRetour = ressource;
    }

    public override void Enter()
    {
        depot = GameObject.Find("HotelDeVille");
        Animateur.SetBool("Run", true);
        AgentAI.SetDestination(depot.transform.position + Vector3.forward * 3);
    }

    public override void Handle()
    {
        if ((!AgentAI.pathPending && AgentAI.remainingDistance <= AgentAI.stoppingDistance))
        {
            Villageois.Livrer();

            // S'il y a encore une ressource, on y retourne
            if (ressourceRetour != null)
            {
                Villageois.ChangerEtat(new EtatTravail(Villageois.gameObject, ressourceRetour.gameObject));
            }
            else

            // Sinon, va attendre un peu plus loin
            {
                Villageois.ChangerEtat(new EtatMarche(Villageois.gameObject, Villageois.transform.position += Vector3.forward  * 5));
            }
        }
    }

    public override void Exit()
    {
        Animateur.SetBool("Run", false);
    }
}