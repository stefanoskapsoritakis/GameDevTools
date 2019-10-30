using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject uiObject;
    public Text score;
    public int level;
    // Start is called before the first frame update
    private void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var p = collider.gameObject.GetComponent<CharacterController>();

        
         if(score.text == "1")
         {

            uiObject.SetActive(true);
            StartCoroutine(WaitForSec());
         }
    


        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(level);
            Destroy(uiObject);
            Destroy(gameObject);
        }
    }
}
