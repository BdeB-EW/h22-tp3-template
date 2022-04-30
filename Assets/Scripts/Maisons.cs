using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maisons : MonoBehaviour
{
    // Il faudrait contrôler le cas où l'ordre de construire une maison est annulé
    // Je ne le fais pas pour le TP.


    private int prochaineMaison;

    public GameObject ProchaineMaison
    {
        get { return maisons[prochaineMaison++]; }
    }

    [SerializeField] private GameObject[] maisons;


    // Start is called before the first frame update
    void Start()
    {
        maisons[0].SetActive(true);
        for (int i = 1; i < maisons.Length; i++)
        {
            maisons[i].SetActive(false);
        }

        prochaineMaison = 1;
    }


    /// <summary>
    /// Construit la maison à la position.
    /// </summary>
    /// <param name="position"></param>
    public void ConstruireMaison(Vector3 position)
    {
        GameObject candidat = null;
        for (int i = 0; i < maisons.Length; i++)
        {
            if (maisons[i].transform.position == position)
            {
                candidat = maisons[i];
            }
        }

        if (candidat != null)
        {
            candidat.SetActive(true);
        }
    }
}
