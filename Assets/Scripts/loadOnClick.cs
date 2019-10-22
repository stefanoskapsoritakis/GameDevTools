using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadOnClick : MonoBehaviour
{
    public GameObject loadingImage;
    // Start is called before the first frame update
    public void LoadScene(int level)
    {
        
        SceneManager.LoadScene(level);
    }
}
