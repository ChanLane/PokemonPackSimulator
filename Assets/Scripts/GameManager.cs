using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Image title;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        title = GameObject.FindGameObjectWithTag("Title").GetComponent<Image>();
        StartCoroutine(TitleScreenRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator TitleScreenRoutine()
    {
        yield return new WaitForSeconds(1);
        var go = title.GetComponent<UIShiny>();
        go.Play();
        yield return new WaitForSeconds(2);

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);



    }
}
