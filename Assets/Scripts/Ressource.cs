using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : MonoBehaviour
{
    [SerializeField] private string type;
    [SerializeField] private int quantiteDisponible;

    public int QuantiteDisponible
    {
        get { return quantiteDisponible; }
        set { quantiteDisponible = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Permet de r�duire la quantit� de l'objet. L'objet est d�truit si
    /// on tombe � z�ro
    /// </summary>
    /// <param name="quantite">La quantit� � retirer</param>
    public void ReduireQuantite(int quantite)
    {
        quantiteDisponible = quantiteDisponible - quantite;

        if (quantiteDisponible <= 0)
        {
            if (type != "Nourriture")
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(this);   // Pour la nourriture, on garde le champ actif
                gameObject.SetActive(false);
            }
        }
    }
}
