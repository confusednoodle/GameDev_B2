using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] AudioSource menuMusic;
    [SerializeField] AudioSource clickSound;
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;

    void Start()
    {
        menuMusic.Play();
    }

	public void TaskOnClickOne()
	{
        clickSound.Play();
        StartCoroutine(WaitForLevel1());
    }

    public void TaskOnClickTwo()
    {
        clickSound.Play();
        StartCoroutine(WaitForLevel2());    
    }

    public void TaskOnClickThree()
    {
        clickSound.Play();
        StartCoroutine(WaitForLevel3());
    }

    private IEnumerator WaitForLevel1()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator WaitForLevel2()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level2");
    }

    private IEnumerator WaitForLevel3()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level3");
    }

}
