using UnityEngine;
using UnityEngine.AI;

public class EtatTravail : EtatVillageois
{
    private Ressource res;
    private NavMeshPath path;

    float elapsed;

    public EtatTravail(GameObject villageois, GameObject resourceExploite) : base(villageois)
    {
        res = resourceExploite.GetComponent<Ressource>();
        //elapsed = 0.0f;
        //path = new NavMeshPath();
    }

    public override void Enter()
    {
        Animateur.SetBool("Run", true);
        AgentAI.SetDestination(res.gameObject.transform.position);
    }

    public override void Handle()
    {
        //elapsed += Time.deltaTime;
        //if (elapsed >= 1.0f)
        //{
        //    elapsed = 0.0f;
        //}

        //for (int i = 0; i < path.corners.Length - 1; i++)
        //    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

        if (! AgentAI.pathPending && AgentAI.remainingDistance <= AgentAI.stoppingDistance)
        {
            MachineEtat.ChangerEtat(new EtatExtraction(Villageois.gameObject, res));
        }
    }

    public override void Exit()
    {
    }
}