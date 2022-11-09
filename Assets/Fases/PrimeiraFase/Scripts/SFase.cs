using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using TMPro;

public class SFase : MonoBehaviour
{
    public enum FasesJogo
    {
        EsperaInicial,
        GerarNovasImagens,
        GamePlay,
        VerificaVencedor
    }


    // 0 azul - 1 rosa
    public Sprite Player1ImageSubstitui;
    public Sprite Player2ImageSubstitui;

    // 0 vitoria - 1 derrotar 
    public Image ImagemVitoria;
    public Image ImagemDerrota;


    public GameObject Menu;
    public GameObject Cam_GameOver;

    public FasesJogo faseAtual;
    //  Cor 0= Marrom; Cor 1= Roxo; Cor 2= Cinza; Cor 3= Laranja; Cor 4= Amarelo; Cor 5= Vermelho; Cor 6= Preto; Cor 7= Rosa; Cor 8= Verde;      

    public Cores corAtiva;

    public Sprite[] Image; // Variável pública para você colocar o sprite que irá substituir o original

    private Image renderSprite; //Variável privada do tipo SpriteRenderer, que o objeto 2D possui.

    private float tempo; // Tempo cronometro

    public bool resetaTempo; // Estado se reseta o tempo

    public GameObject ActiveMovi;

    public int indice; // Variável que recebe o Random

    public TextMeshProUGUI tempoTXT;
    private bool tempoGamePlayFinalizado;
    public float tempoGamePlay;
    public PlayerCharacterController player1, player2;



    void Start()
    {
        Cam_GameOver.SetActive(false);
        faseAtual = FasesJogo.EsperaInicial;
        tempoGamePlayFinalizado = false;
        tempoGamePlay = 20f;
        renderSprite = GetComponent<Image>(); //Atribui a variável renderSprite o componente de SpriteRenderer presente no objeto 2D, na inicialização da cena.
        
    }

    void Update ()
    {
        Debug.Log ("FaseAtual " + faseAtual);
        //Debug.Log ("Tempo " + tempo);
        ControleFasesJogo ();
        Debug.Log(tempoGamePlay);
    }

    public enum Cores
    {
        Marrom,
        Roxo,
        Cinza,
        Laranja,
        Amarelo,
        Vermelho,
        Preto,
        Rosa,
        Verde
    }

    private void ControleFasesJogo()
    {
        switch (faseAtual)
        {
            case FasesJogo.EsperaInicial:
                ContagemRegressiva ();
                break;

            case FasesJogo.GerarNovasImagens:
                GeraNovaImagem ();
                break;

            case FasesJogo.GamePlay:
                ContagemRegressivaGamePlay ();
                break;

            case FasesJogo.VerificaVencedor:
                if (!tempoGamePlayFinalizado)
                {
                    Menu.gameObject.SetActive(false);
                    VerificaVencedor ();
                }
                break;
        }
    }

    private void GeraNovaImagem()
    {
        indice = Random.Range (0, 8);
        renderSprite.sprite = Image[indice];
        switch (indice)
        {
            case 0:
                corAtiva = Cores.Marrom;
                break;

            case 1:
                corAtiva = Cores.Roxo;
                break;

            case 2:
                corAtiva = Cores.Cinza;
                break;

            case 3:
                corAtiva = Cores.Laranja;
                break;

            case 4:
                corAtiva = Cores.Amarelo;
                break;

            case 5:
                corAtiva = Cores.Vermelho;
                break;

            case 6:
                corAtiva = Cores.Preto;
                break;

            case 7:
                corAtiva = Cores.Rosa;
                break;

            case 8:
                corAtiva = Cores.Verde;
                break;

        }

        tempo -= Time.deltaTime;

        //Verifica se o tempo acabou
        if (tempo <= 0)
        {
            tempo = tempoGamePlay;
            
            faseAtual = FasesJogo.GamePlay;
        }
    }

    public void ResetaTime()
    {
        tempo = 0;
    }

    public void ContagemRegressiva()
    {
        tempoTXT.text = "O jogo começará em: " + Mathf.RoundToInt (tempo).ToString ();
        if (!tempoTXT.gameObject.activeInHierarchy)
        {
            tempoTXT.gameObject.SetActive (true);
        }        
        tempo -= Time.deltaTime;

        //verifica se o tempo acabou
        if (tempo <= 0)
        {
            
            faseAtual = FasesJogo.GerarNovasImagens;
            tempoTXT.gameObject.SetActive(false);
            tempo = 2f;
            
        }
    }

    public void ContagemRegressivaGamePlay ()
    {
        tempo -= Time.deltaTime;

        //verifica se o tempo acabou
        if (tempo <= 0)
        {
            faseAtual = FasesJogo.VerificaVencedor;
        }
    }

    public void VerificaVencedor()
    {
        tempoGamePlayFinalizado = true;

        Debug.Log ("Verificando vencedor!");

        if ((player1.corAtual == corAtiva.ToString () && player2.corAtual != corAtiva.ToString ()) || GameOver.Player2 == true)
        {
            //Player 1 venceu

            ActiveMovi.SetActive(false);

            Cam_GameOver.SetActive(true);

            Debug.Log ("Player 1 venceu");

            ImagemVitoria.GetComponent<Image>().sprite = Player1ImageSubstitui;
            ImagemDerrota.GetComponent<Image>().sprite = Player2ImageSubstitui;

        }
        else if ((player1.corAtual != corAtiva.ToString () && player2.corAtual == corAtiva.ToString ()) || GameOver.Player1 == true)
        {
            //Player 2 venceu

            ActiveMovi.SetActive(false);

            Cam_GameOver.SetActive(true);

            ImagemVitoria.GetComponent<Image>().sprite = Player2ImageSubstitui;
            ImagemDerrota.GetComponent<Image>().sprite = Player1ImageSubstitui;

            Debug.Log("Player 2 venceu");

        }
        else
        {
            //empate


            Debug.Log ("Empate");
            tempoGamePlay = tempoGamePlay - 5f;
            ContagemRegressiva();

        }

    }

}