using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void Game()
    {

        SceneManager.LoadScene("CoopChrisGameJam1", LoadSceneMode.Single);

    }

    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }

    public void About()
    {

        SceneManager.LoadScene("About", LoadSceneMode.Single);

    }

}
