using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementVillageois : MonoBehaviour
{
    private Collider colliderPlan;

    

    // Il y a une duplication de concept ici avec le générateur d'actions.
    public bool Selectionne
    {
        set
        {
            GetComponent<GenerateurAction>().Selectionne = value;
        }

        get
        {
            return GetComponent<GenerateurAction>().Selectionne;
        }
    }

    private EtatVillageois etat;
    private EtatInactif inactif;

    [SerializeField]
    private GameObject indicateurSelection;

    public Vector3 PointDepart
    {
        get;
        private set;
    }

    public int Bois
    {
        set;
        get;
    }

    public int Pierre
    {
        set;
        get;
    }

    public int Nourriture
    {
        set;
        get;
    }

    public EtatVillageois Inactif
    {
        get { return inactif; }
    }

    void Awake()
    {
        inactif = new EtatInactif(gameObject);
    }

    void Start()
    {
        Selectionne = false;
        colliderPlan = GameObject.Find("Sol").GetComponent<Collider>();
        etat = inactif;
        indicateurSelection.SetActive(false);
        PointDepart = transform.position;
    }

    void Update()
    {

        // On deplace le villageois au bon endroit. Ce qui va peut-�tre changer son �tat.
        // Et faire un action.
        if (Input.GetMouseButtonDown(0) && Selectionne)
        {
            Vector3? pointDestination;
            pointDestination = Utilitaires.TrouverPoint(colliderPlan);
            if (pointDestination != null)
            {
                ChangerEtat(new EtatMarche(gameObject, pointDestination.Value));
                Selectionne = false;
            }
        }

        if (Input.GetMouseButtonDown(1) && Selectionne)
        {
            Collider c = Utilitaires.TrouverColliderClique();
            Ressource res = c.gameObject.GetComponent<Ressource>();
            if (res != null)
            {
                ChangerEtat(new EtatTravail(gameObject, res.gameObject));
                Selectionne = false;
            }
        }
        indicateurSelection.SetActive(Selectionne);
        etat.Handle();
    }

    public void ChangerEtat(EtatVillageois nouveau)
    {
        etat.Exit();
        etat = nouveau;
        etat.Enter();
    }

    private void OnMouseDown()
    {
        Selectionne = true;
    }

    /// <summary>
    /// On enlève toute les ressources du villageois et on les met dans le pool de ressources.
    /// </summary>
    public void Livrer()
    {
        RessourceManager.Instance.ReserveBois += Bois;
        RessourceManager.Instance.ReservePierre += Pierre;
        RessourceManager.Instance.ReserveNourriture += Nourriture;
        Bois = 0;
        Pierre = 0;
        Nourriture = 0;
    }
}
