using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Menu_Script : MonoBehaviour
{

    [SerializeField] private Transform MenuPrincipal;
    [SerializeField] private Transform MenuCredits;
    [SerializeField] private Transform MenuCommentJouer;

    bool SurMenuPrincipal;

    private void Start()
    {
        SurMenuPrincipal = true;
    }

    public void QuitterLeJeu()
    {
        Application.Quit();
    }

    public void JouerAuJeu()
    {
        SceneManager.LoadScene("Scene_Main");
    }

    public void RetourMenuPrincipal()
    {
        SceneManager.LoadScene("Menu_Principal");
    }

    public void RegleDuJeu()
    {
        SurMenuPrincipal = !SurMenuPrincipal;
        MenuPrincipal.DOLocalMoveX(SurMenuPrincipal == true ? 0f : -1101f, 0.5f);
        MenuCommentJouer.DOLocalMoveX(SurMenuPrincipal == false ? 0f : 1101f, 0.5f);
    }

    public void Credits()
    {
        SurMenuPrincipal = !SurMenuPrincipal;
        MenuPrincipal.DOLocalMoveX(SurMenuPrincipal == true ? 0f : -1101f, 0.5f);
        MenuCredits.DOLocalMoveX(SurMenuPrincipal == false ? 0f : 1101f, 0.5f);
    }
}
