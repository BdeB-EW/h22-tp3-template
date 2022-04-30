using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// Classe qui affichage les information sur la sélection du joueur.
/// Comprend le nom et montre les actions possibles.
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class AffichageSelection : MonoBehaviour
{
    [SerializeField] private TMP_Text textSelection;
    [SerializeField] private GameObject[] zonesAction;
    [SerializeField] private Button[] boutonAction;
    [SerializeField] private TMP_Text[] textCoutOr;
    [SerializeField] private TMP_Text[] textCoutBois;
    [SerializeField] private TMP_Text[] textCoutRoche;
    [SerializeField] private TMP_Text[] textCoutNourriture;

    private GenerateurAction objetSelectionne;
    // Start is called before the first frame update
    void Start()
    {
        objetSelectionne = null;
        ViderInformations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        // PATCH
        if (objetSelectionne != null && ! objetSelectionne.Selectionne)
        {
            objetSelectionne = null;
        }

        if (objetSelectionne != null)
        {
            MettreAJour(objetSelectionne);
        }
        else
        {
            ViderInformations();
        }
    }

    private void MettreAJour(GenerateurAction generateur)
    {
        textSelection.text = generateur.Nom;
        Action[] actions = generateur.GetActions();

        for (int i=0; i<actions.Length; i++)
        {
            Action action = actions[i];
            
            zonesAction[i].SetActive(true);
            boutonAction[i].enabled = RessourceManager.Instance.ActionPossible(action);
            boutonAction[i].GetComponent<Image>().sprite = action.ImageIcon;

            boutonAction[i].onClick.RemoveAllListeners();
            
            switch (i)
            {
                case 0:
                    boutonAction[i].onClick.AddListener(generateur.Action0);
                    break;
                case 1:
                    boutonAction[i].onClick.AddListener(generateur.Action1);
                    break;
                case 2:
                    boutonAction[i].onClick.AddListener(generateur.Action2);
                    break;
            }

            textCoutOr[i].text = action.CoutOr.ToString();
            textCoutBois[i].text = action.CoutBois.ToString();
            textCoutNourriture[i].text = action.CoutFood.ToString();
            textCoutRoche[i].text = actions[i].CoutPierre.ToString();
        }

        for (int i=actions.Length; i<zonesAction.Length; i++)
        {
            zonesAction[i].SetActive(false);
        }
    }

    private void ViderInformations()
    {
        textSelection.text = "";

        foreach (GameObject obj in zonesAction)
        {
            obj.SetActive(false);
        }
    }

    public void ChangerSelection(GenerateurAction generateur)
    {
         objetSelectionne = generateur;
    }
}
