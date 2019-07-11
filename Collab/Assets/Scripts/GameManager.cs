using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float startingTime;

    public GameObject P1;
    public GameObject P2;
    
    public int P1Life;
    public int P2Life;
    
    public GameObject PlayerOneWin;
    public GameObject PlayerTwoWin;

    public GameObject[] p1bar;
    public GameObject[] p2bar;

    
    public AudioSource hurtSound;

    public string mainMenu;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        startingTime -= Time.deltaTime;
        if(startingTime <= 0)
        {
            if(P1Life > P2Life)
            {
                PlayerOneWin.SetActive(true);
            }
        else
            {
                PlayerTwoWin.SetActive(true);
            }
        }

       if(P1Life <= 0) 
       {
        P1.SetActive(false);
        PlayerTwoWin.SetActive(true);
       }
       if(P2Life <= 0) 
       {
        P2.SetActive(false);
        PlayerOneWin.SetActive(true);
       }
       if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }
    public void HurtP1()
    {
        P1Life -= 1;
        
        for(int i = 0; 1 < p1bar.Length; i++)
        {
            if(P1Life > i)
            {
                p1bar[i].SetActive(true);
            } 
            else 
            {
                p1bar[i].SetActive(false);
            }
            hurtSound.Play();
            
        }

    }
    public void HurtP2()
    {
        P2Life -= 2;
        for(int i = 0; 1 < p2bar.Length; i++)
        {
            if(P2Life > i)
            {
                p2bar[i].SetActive(true);
            } 
            else 
            {
                p2bar[i].SetActive(false);
            }
            hurtSound.Play();
        }

       
    }
}
