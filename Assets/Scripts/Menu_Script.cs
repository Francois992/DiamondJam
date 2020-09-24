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

    GameMaster gm;

    private void Start()
    {
        SurMenuPrincipal = true;

        gm = FindObjectOfType<GameMaster>();
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

    public void DefaiteRejouer()
    {
        foreach (GameObject player in gameObject.GetComponent<GameManager>().Players)
        {
            player.transform.localPosition = new Vector3(gm.lastPositionCheckpoint.x + (player.GetComponent<Player>().playerId == 0 ? 2 : -2), gm.lastPositionCheckpoint.y, gm.lastPositionCheckpoint.z);
            StartCoroutine(WaitToRespawn());
        }
    }

    IEnumerator WaitToRespawn()
    {
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i < gameObject.GetComponent<GameManager>().Players.Length; i++) gameObject.GetComponent<GameManager>().Players[i].GetComponent<Player>().respawnPlayer = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<GameManager>().menuDefaite.SetActive(false);
    }
}
