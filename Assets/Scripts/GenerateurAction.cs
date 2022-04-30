using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurAction : MonoBehaviour
{
    [SerializeField] private string nomObjet;

    public bool Selectionne
    {
        get;
        set;
    }

    protected Action[] actions;
    
    public string Nom
    {
        get { return nomObjet; }
    }

    public virtual Action[] GetActions()
    {
        return null;
    }

    public virtual void ActionI(int num)
    {

    }

    public virtual void Action0()
    {
    }

    public virtual void Action1()
    {
    }
    public virtual void Action2()
    {
    }
}
