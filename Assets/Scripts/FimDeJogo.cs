using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDeJogo : MonoBehaviour
{
    public string nomeSair;
    public string nomeNovamente;

    public void Sair()
    {
        Debug.Log("ApertouBotaoSair");
        SceneManager.LoadScene(nomeSair);
    }


    public void JogarNovamente()
    {
        Debug.Log("ApertouBotaoJogarNovamente");
        SceneManager.LoadScene(nomeNovamente);
    }

}
