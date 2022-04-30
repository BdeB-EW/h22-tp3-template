using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fermes : MonoBehaviour
{
    [SerializeField] private GameObject[] fermes;
    private int prochaineFerme;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<fermes.Length; i++)
        {
            fermes[i].SetActive(false);
        }
        prochaineFerme = 0;
    }

    public GameObject ProchaineFerme
    {
        get { return TrouverFerme(); }
    }


    private GameObject TrouverFerme()
    {
        GameObject ferme = null;
        for (int i=0; i<fermes.Length; i++)
        {
            if (! fermes[i].activeSelf)
            {
                ferme = fermes[i];
                break;
            }
        }
        return ferme;
    }

    /// <summary>
    /// Construit la ferme à la position.
    /// </summary>
    /// <param name="position"></param>
    public void ConstruireFerme(Vector3 position)
    {
        GameObject candidat = null;
        for (int i = 0; i < fermes.Length; i++)
        {
            if (fermes[i].transform.position == position)
            {
                candidat = fermes[i];
            }
        }

        if (candidat != null)
        {
            candidat.SetActive(true);
        }
    }
}
