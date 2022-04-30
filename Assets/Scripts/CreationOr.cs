using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationOr : MonoBehaviour
{
    private RessourceManager manager;

    [SerializeField] private float tauxAugmentationOr;

    // Start is called before the first frame update
    void Start()
    {
        manager = RessourceManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // On ajoute simplement de l'or
        float ajoutOr = tauxAugmentationOr * Time.deltaTime;
        manager.ReserveOr += ajoutOr;
    }
}
