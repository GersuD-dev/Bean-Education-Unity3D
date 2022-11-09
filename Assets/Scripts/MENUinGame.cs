using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MENUinGame : MonoBehaviour
{
    public GameObject ObjetoJogo, CamMenu, CanvasLetra;
    public Button BotaoSair;

    [Space(20)]
    public Slider BarraVolume;
    public Toggle CaixaModoJanela;
    public Button BotaoVoltar, BotaoSalvarPref;

    [Space(20)]
    public string nomeCenaJogo = "CENA1";
    private string nomeDaCena;
    private float VOLUME;
    private int  modoJanelaAtivo;
    public bool telaCheiaAtivada;

    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        Opcoes(false);
        
        //
        nomeDaCena = SceneManager.GetActiveScene().name;
        Cursor.visible = true;
        Time.timeScale = 1;
        //

        BarraVolume.minValue = 0;
        BarraVolume.maxValue = 1;

        //=============== SAVES===========//
        if (PlayerPrefs.HasKey("VOLUME"))
        {
            VOLUME = PlayerPrefs.GetFloat("VOLUME");
            BarraVolume.value = VOLUME;
            AudioListener.volume = VOLUME;
        }
        else
        {
            PlayerPrefs.SetFloat("VOLUME", 1);
            BarraVolume.value = 1;
        }
        //=============MODO JANELA===========//
        if (PlayerPrefs.HasKey("modoJanela"))
        {
            modoJanelaAtivo = PlayerPrefs.GetInt("modoJanela");
            if (modoJanelaAtivo == 1)
            {
                Screen.fullScreen = false;
                CaixaModoJanela.isOn = true;
            }
            else
            {
                Screen.fullScreen = true;
                CaixaModoJanela.isOn = false;
            }
        }
        else
        {
            modoJanelaAtivo = 0;
            PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
            CaixaModoJanela.isOn = false;
            Screen.fullScreen = true;
        }
        //========RESOLUCOES========//
        if (modoJanelaAtivo == 1)
        {
            telaCheiaAtivada = false;
        }
        else
        {
            telaCheiaAtivada = true;
        }
        
        // =========SETAR BOTOES==========//
        BotaoSair.onClick = new Button.ButtonClickedEvent();
        BotaoVoltar.onClick = new Button.ButtonClickedEvent();
        BotaoSalvarPref.onClick = new Button.ButtonClickedEvent();

        BotaoSair.onClick.AddListener(() => Sair());

        // Desativa o opções para voltar ao jogo
        BotaoVoltar.onClick.AddListener(() => Opcoes(false));
        BotaoSalvarPref.onClick.AddListener(() => SalvarPreferencias());
    }
    
    private void Opcoes(bool ativarOP)
    {
        if(ativarOP)
        {
            CamMenu.gameObject.SetActive(true);
            ObjetoJogo.gameObject.SetActive(false);

            CanvasLetra.gameObject.SetActive(false);

        }
        else
        {
            CamMenu.gameObject.SetActive(false);
            ObjetoJogo.gameObject.SetActive(true);

            CanvasLetra.gameObject.SetActive(true);

        }

        BotaoSair.gameObject.SetActive(ativarOP);

        BarraVolume.gameObject.SetActive(ativarOP);
        //CaixaModoJanela.gameObject.SetActive(ativarOP);
        BotaoVoltar.gameObject.SetActive(ativarOP);
        BotaoSalvarPref.gameObject.SetActive(ativarOP);
    }
    //=========VOIDS DE SALVAMENTO==========//
    private void SalvarPreferencias()
    {
        if (CaixaModoJanela.isOn == true)
        {
            modoJanelaAtivo = 1;
            telaCheiaAtivada = false;
        }
        else
        {
            modoJanelaAtivo = 0;
            telaCheiaAtivada = true;
        }
        PlayerPrefs.SetFloat("VOLUME", BarraVolume.value);
        PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
        AplicarPreferencias();
    }
    private void AplicarPreferencias()
    {
        VOLUME = PlayerPrefs.GetFloat("VOLUME");
        AudioListener.volume = VOLUME;
    }
    //===========VOIDS NORMAIS=========//
    void Update()
    {

        Debug.Log(BarraVolume.value);

        if (SceneManager.GetActiveScene().name != nomeDaCena)
        {
            AudioListener.volume = VOLUME;
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Opcoes(true);
        }
    }

    private void Sair()
    {
        SceneManager.LoadScene(nomeCenaJogo);
    }
}