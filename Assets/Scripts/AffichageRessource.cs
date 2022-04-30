using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AffichageRessource : MonoBehaviour
{
    [SerializeField] private TMP_Text valeurOr;
    [SerializeField] private TMP_Text valeurBois;
    [SerializeField] private TMP_Text valeurPierre;
    [SerializeField] private TMP_Text FoodAmountText;

    private void OnGUI()
    {
        valeurOr.text = ((int) RessourceManager.Instance.ReserveOr).ToString();
        valeurBois.text = ((int) RessourceManager.Instance.ReserveBois).ToString();
        valeurPierre.text = ((int) RessourceManager.Instance.ReservePierre).ToString();
        FoodAmountText.text = ((int) RessourceManager.Instance.ReserveNourriture).ToString();
    }
}
