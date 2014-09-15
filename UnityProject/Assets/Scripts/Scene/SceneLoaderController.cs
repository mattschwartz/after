using UnityEngine;
using System.Collections;
using After.Scene;

// This class allows us to carry data over from the previous scene
public class SceneLoaderController : MonoBehaviour
{
    #region Private Members

    private LevelLoadParameters Parameters;

    #endregion

    void Awake()
    {
        Parameters = SceneManager.SceneParameters;
    }

    public void SaveScene()
    {
        Parameters = new LevelLoadParameters();
    }
}
