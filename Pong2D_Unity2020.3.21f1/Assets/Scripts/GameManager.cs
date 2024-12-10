using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pontuacaoDoJogador1;

    public int pontuacaoDoJogador2;

    public Text textoDePontuacao;

    public AudioSource somDoGol;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
        pontuacaoDoJogador1 = 0;
        pontuacaoDoJogador2 = 0;
        textoDePontuacao.text = pontuacaoDoJogador1 + " X " + pontuacaoDoJogador2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            reiniciarPartida();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            sairDoJogo();
        }
    }

    public void aumentarPontuacaoDoJogador1()
    {
        pontuacaoDoJogador1 += 1;
        atualizarTextoDePontuacao();
    }

    public void aumentarPontuacaoDoJogador2()
    {
        pontuacaoDoJogador2 += 1;
        atualizarTextoDePontuacao();
    }

    public void atualizarTextoDePontuacao()
    {
        textoDePontuacao.text = pontuacaoDoJogador1 + " X " + pontuacaoDoJogador2;
        somDoGol.Play();
    }

    private void reiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void sairDoJogo()
    {
        Application.Quit();
        Debug.Log("Jogo Fechado!");
    }
}
