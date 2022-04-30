using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text[] txtCoutVillageois;
    [SerializeField] private TMP_Text[] txtCoutFerme;
    [SerializeField] private TMP_Text[] txtCoutMaison;

    int[] coutVillageoisS = new int[]{ 0, 0, 50, 10};
    int[] coutFermeS = new int[] { 10, 5, 0, 20};
    int[] coutMaisonS = new int[] { 50, 10, 0, 50};

    int[] coutVillageois0 = new int[] { 0, 0, 0, 0};
    int[] coutFerme0 = new int[] { 0, 0, 0, 0};
    int[] coutMaison0 = new int[] { 0, 0, 0, 0};

    int[] coutVillageois = new int[] { 0, 0, 0, 0 };
    int[] coutFerme = new int[] { 0, 0, 0, 0 };
    int[] coutMaison = new int[] { 0, 0, 0, 0 };



    // Start is called before the first frame update
    void Start()
    {
        coutVillageois = coutVillageoisS;
        coutFerme = coutFermeS;
        coutMaison = coutMaisonS;
        MettreAJour();
    }

    public void Quitter()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif

    }

    public void Jouer()
    {
        CoutActions couts = CoutActions.Instance;
        couts.CoutVillageois = coutVillageois;
        couts.CoutFerme = coutFerme;
        couts.CoutMaison = coutMaison;

        RessourceManager.Instance.Initialiser();

        SceneManager.LoadScene(1);

    }

    public void MettreAZero()
    {
        coutVillageois = coutVillageois0;
        coutFerme = coutFerme0;
        coutMaison = coutMaison0;
    }

    public void Defaut()
    {
        coutVillageois = coutVillageoisS;
        coutFerme = coutFermeS;
        coutMaison = coutMaisonS;
    }

    public void OnGUI()
    {
        MettreAJour();
    }

    private void MettreAJour()
    {
        for (int i = 0; i < txtCoutVillageois.Length; i++)
        {
            txtCoutVillageois[i].text = coutVillageois[i].ToString();
        }

        for (int i = 0; i < txtCoutFerme.Length; i++)
        {
            txtCoutFerme[i].text = coutFerme[i].ToString();
        }

        for (int i = 0; i < txtCoutMaison.Length; i++)
        {
            txtCoutMaison[i].text = coutMaison[i].ToString();
        }
    }
}
