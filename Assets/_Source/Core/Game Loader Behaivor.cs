using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderBehaviour : MonoBehaviour
{
    // TODO: ADD IINITIALIZABLE.
    [field: SerializeField]
    private List<GameObject> coreObjects;
    [field: SerializeField]
    private string afterLoadSceneName;
    void Awake()
    {
        if (coreObjects != null && coreObjects.Count > 0)
        {
            foreach (GameObject _gameObject in coreObjects)
            {
                GameObject newobj = Instantiate(_gameObject);
                DontDestroyOnLoad(newobj);
                try
                {
                    if (newobj.TryGetComponent(out IINITIALIZABLE iNITIALIZABLE))
                    {
                        iNITIALIZABLE.Initialize();
                    }
                    foreach (Transform transform in newobj.transform)
                    {
                        if (transform.gameObject.TryGetComponent(out IINITIALIZABLE _iNITIALIZABLE))
                        {
                            _iNITIALIZABLE.Initialize();
                        }
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogWarning("Failed to initialize " + newobj.name + ". error: " + e.Message);
                }
            }
        }
        if (!SceneManager.GetSceneByName(afterLoadSceneName).isLoaded)
        {
            SceneManager.LoadScene(afterLoadSceneName, LoadSceneMode.Additive);
        }
    }
}
public interface IINITIALIZABLE
{
    public abstract void Initialize();
}