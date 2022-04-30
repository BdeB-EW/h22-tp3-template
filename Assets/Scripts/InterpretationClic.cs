using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretationClic : MonoBehaviour
{
    /// <summary>
    /// Objet qui affiche la selection. Pourrait se faire avec un observateur.
    /// C'est la prochaine etape.
    /// </summary>
    private AffichageSelection objetAfficheSelection;
    
    private GenerateurAction objetSelectionne;

    void Start()
    {
        objetAfficheSelection = GameObject.Find("==== HUD ====").
            GetComponent<AffichageSelection>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider c = Utilitaires.TrouverColliderClique();
            if (c != null)
            {
                if (objetSelectionne != null)
                {
                    objetSelectionne.Selectionne = false;
                }

                objetSelectionne = c.gameObject.GetComponent<GenerateurAction>();
                objetAfficheSelection.ChangerSelection(objetSelectionne);
                if (objetSelectionne != null)
                {
                    objetSelectionne.Selectionne = true;
                }
            }
        }
    }
}
