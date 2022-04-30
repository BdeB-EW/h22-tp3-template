using UnityEngine;

public class EtatExtraction : EtatVillageois
{
    private float compteurExtraction;
    private float vitesseExtrationNourriture = 1.0f;
    private float vitesseExtractionBois = 1.0f;
    private float vitesseExtractionPierre = 0.4f;
    private Ressource res;
    private string type;

    public EtatExtraction(GameObject villageois, Ressource ressource) : base(villageois)
    {
        res = ressource;
        type = res.Type;
    }

    public override void Enter()
    {
        if (res != null)
        {
            Animateur.SetBool("Travail", true);
            Villageois.transform.LookAt(res.gameObject.transform.position);
        }
        else
        {
            MachineEtat.ChangerEtat(new EtatInactif(Villageois.gameObject));
        }

    }

    public override void Handle()
    {
        ExtraireRessource();

        if (Villageois.Bois + Villageois.Pierre + Villageois.Nourriture == 5)
        {
            MachineEtat.ChangerEtat(new RamenerRessource(Villageois.gameObject, res));
        }
        if (res.QuantiteDisponible <= 0)
        {
            MachineEtat.ChangerEtat(new RamenerRessource(Villageois.gameObject, res));
        }
    }


    public override void Exit()
    {
        Animateur.SetBool("Travail", false);
    }

    private void ExtraireRessource()
    {
        if (type.Equals("Bois"))
        {
            compteurExtraction += Time.deltaTime * vitesseExtractionBois;
        }
        else if (type.Equals("Pierre"))
        {
            compteurExtraction += Time.deltaTime * vitesseExtractionPierre;
        }
        else if (type.Equals("Nourriture"))
        {
            compteurExtraction += Time.deltaTime * vitesseExtrationNourriture;
        }

        if (res.QuantiteDisponible > 0 && compteurExtraction >= 1.0f)
        {
            compteurExtraction = 0.0f;
            res.ReduireQuantite(1);

            if (type.Equals("Bois"))
            {
                Villageois.Bois++;
            }
            else if (type.Equals("Pierre"))
            {
                Villageois.Pierre++;
            }
            else if (type.Equals("Nourriture"))
            {
                Villageois.Nourriture++;
            }
        }
    }
}
