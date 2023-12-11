using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TelasMenu : MonoBehaviour
{
    [SerializeField]
    private string NomeMapa;

    [SerializeField]
    private GameObject _panelMenuInicial;

    [SerializeField]
    private GameObject _panelOpcoes;

    [SerializeField]
    private GameObject _panelCreditos;

    [SerializeField]
    private GameObject _panelClasse;

    public void Jogar()
    {
        SceneManager.LoadScene(NomeMapa);
    }

    public void AbrirOpcoes()
    {
        _panelMenuInicial.SetActive(false);
        _panelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        _panelMenuInicial.SetActive(true);
        _panelOpcoes.SetActive(false);
    }

    public void AbrirCreditos()
    {
        _panelMenuInicial.SetActive(false);
        _panelCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        _panelMenuInicial.SetActive(true);
        _panelCreditos.SetActive(false);
    }

    public void AbrirClasse()
    {
        _panelMenuInicial.SetActive(false);
        _panelClasse.SetActive(true);
    }

    public void FecharClasse()
    {
        _panelMenuInicial.SetActive(true);
        _panelClasse.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Jogo fechou");
        Application.Quit();
    }
}
