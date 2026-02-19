using UnityEngine;
using UnityEngine.SceneManagement;

public static class Bootstraper 
{
    const string BOOTSTRAPERSCENENAME = "BootstraperScene";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    internal static void InitSystems()
    {
        if (SceneManager.GetSceneByName(BOOTSTRAPERSCENENAME).isLoaded != true && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(BOOTSTRAPERSCENENAME))
        {
            SceneManager.LoadScene(BOOTSTRAPERSCENENAME, LoadSceneMode.Additive);
        }     
    }
}
