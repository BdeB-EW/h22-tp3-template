using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Utilitaires
{
    /// <summary>
    /// Permet de trouver la point cliqué dans le monde du jeu si
    /// on touche le collider passé en paramètre.
    /// </summary>
    /// <param name="collider"></param>
    /// <returns></returns>
    public static Vector3? TrouverPoint(Collider collider)
    {
        Vector3 positionSouris = Input.mousePosition;
        Vector3? pointClique = null;

        // Trouver le lien avec la caméra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet touché est le plan.
            if (hit.collider == collider)
            {
                // Le vecteur est initialise ici car le clic est sur le plan
                Vector3 position = hit.point;
                pointClique = new Vector3(position.x, position.y, position.z);
            }
        }
        return pointClique;
    }

    /// <summary>
    /// Retourne le collider cliqué
    /// </summary>
    /// <returns>Le collider qui est cliqué</returns>
    public static Collider TrouverColliderClique()
    {
        Collider colliderObjet = null;
        Vector3 positionSouris = Input.mousePosition;

        // Trouver le lien avec la caméra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            colliderObjet = hit.collider;
        }
        return colliderObjet;
    }
}
