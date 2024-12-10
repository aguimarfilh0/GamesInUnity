using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
