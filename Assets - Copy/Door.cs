using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public int Level2;
    public string scence = "Level2";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(Level2);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<GatherInput>().DisableControls();
            SceneManager.LoadScene(scence);
            Debug.Log("Get in the door");
        }
    }

}
