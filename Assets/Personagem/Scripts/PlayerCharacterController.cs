using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (CharacterController))]
public class PlayerCharacterController : MonoBehaviour
{
    public GameObject PersonagemAnimacao;
    public Animator animator;


    public string nomeObjeto;

    [Header ("Movimentação do Avatar")]

    [Tooltip ("componente responsável pela movimentação do avatar")]
    public CharacterController controller;

    [Tooltip ("velocidade que o avatar irá se mover")]
    public float velAndar = 4f;

    [Tooltip ("valor da gravidade")]
    public float gravidade = -9.81f;

    [Tooltip ("Define qual altura o avatar poderá pular")]
    public float alturaPulo = 0.8f;

    [Tooltip ("Distância do pé do avatar para o chão que permitirá pular")]
    public float distanciaChao = 0.4f;

    [Tooltip ("Camada que representa o chão. Camada que irá permitir o jogador pular se estiver em contato")]
    public LayerMask camadaChao;

    [Tooltip ("Objeto que será utilizado para verificar a distancia do 'pé' do jogador até o chão")]
    public Transform groundCheck;

    [Tooltip("Modificar o nome do input horizontal")]
    public string InputHorizontal;

    [Tooltip("Modificar o nome do input vertical")]
    public string InputVertical;

    [Tooltip("Modificar o nome do input Pulo")]
    public string Pulo;

    //Determina o quanto o personagem irá se mover
    private Vector3 velocidade;

    public SFase sFase;

    public bool RecebeSFase;

    public int numTag;

    public string Tag;


    public string corAtual;

    private void Start ()
    {
        controller = GetComponent<CharacterController> ();
    }

    private void Update ()
    {
        nomeObjeto = gameObject.name;        

        if(sFase.faseAtual == SFase.FasesJogo.GamePlay)
        {
            Movimento ();
        }
    }

    private void Movimento ()
    {
        if (velocidade.y < 0 && NoChao ())
        {
            velocidade.y = -2f;
        }

        float esquivar = Input.GetAxis (InputHorizontal);
        float andar = Input.GetAxis (InputVertical);
        Vector3 movimento = transform.right * esquivar + transform.forward * andar;
        controller.Move (movimento * velAndar * Time.deltaTime);

        if(Input.GetButtonDown(Pulo) && NoChao())
        {
            AdiconaVelocidadeVertical(alturaPulo);
            // Animação pulo
        }

        velocidade.y += gravidade * Time.deltaTime;
        controller.Move (velocidade * Time.deltaTime);
    }

    public void AdiconaVelocidadeVertical(float altura)
    {
        velocidade.y = Mathf.Sqrt(altura * -2f * gravidade);
    }

    public bool NoChao ()
    {
        return Physics.CheckSphere (groundCheck.position, distanciaChao, camadaChao);
    }
}
