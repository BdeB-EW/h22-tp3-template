using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsHotelVille : GenerateurAction
{
    

    [SerializeField] private GameObject modeleVillageois;
    [SerializeField] private Transform spawnPoint;

    private GameObject gameManager;
    private Action[] actionsHotelVille;

    public Vector3 SpawnPoint
    {
        get { return spawnPoint.position; }
    }

    private void Start()
    {
        Actions actions = GameObject.Find("GameManager").GetComponent<Actions>();
        actionsHotelVille = new Action[1];
        actionsHotelVille[0] = actions.NouveauVillageois;
    }

    public override Action[] GetActions()
    {
        return actionsHotelVille;
    }

    public void GenererVillageois()
    {
        GameObject[] maisons = GameObject.FindGameObjectsWithTag("Maison");
        GameObject[] villageois = GameObject.FindGameObjectsWithTag("Worker");

        int nbMax = maisons.Length * 4;
        if (villageois.Length < nbMax)
        {
            GameObject.Instantiate(modeleVillageois, spawnPoint);
        }
    }

    public override void Action0()
    {
        GenererVillageois();
        actionsHotelVille[0].RetirerRessources();
    }

    public override void Action1()
    {
    }

    public override void Action2()
    {
    }

}
