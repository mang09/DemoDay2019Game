using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusicGenerator : MonoBehaviour
{
	public int TheNumber;
	public AudioSource ryuStage;
	public AudioSource narutoStage;
	public AudioSource megamanStage;
    // Start is called before the first frame update
    public void RandomGenerate() 
    {
        TheNumber = Random.Range (1,10);
        if (TheNumber <= 3)
        {
        	ryuStage.Play();
        }
        if (TheNumber >=8)
        {
        	megamanStage.Play();
        }
        else
        {
        	narutoStage.Play();
        }
    }
}
