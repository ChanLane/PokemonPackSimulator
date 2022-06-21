using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoosterPackFactory : MonoBehaviour
{
    [SerializeField] private List<GameObject> commonCardSpawnLocations = new List<GameObject>();
    [SerializeField] private List<GameObject> uncommonCardSpawnLocations = new List<GameObject>();
    [SerializeField] private List<GameObject> energyCardSpawnLocations = new List<GameObject>();
    [SerializeField] private List<GameObject> rareCardSpawnLocations = new List<GameObject>();
  
    [SerializeField] private BoosterPackData currentBoosterPackData;

    [SerializeField] private List<GameObject> currentPull;

    [SerializeField] private GameObject BaseCardPrefab;

    [SerializeField] private Transform BoosterSpawnLocation;


    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private AudioClip placeCardClip;

    private bool cardsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GameObject.FindWithTag("AudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cardsSpawned == false)
        {
            cardsSpawned = true;
            StartCoroutine(SpawnCardsRoutine());
        }
    }
    
    private IEnumerator SpawnCardsRoutine()
    {
        var durationIndex = 1.1f;
        GetCommonLocations();
        GetEnergySpawnLocations();
        GetUncommonLocations();
        GetRareLocations();


        foreach (var rare in rareCardSpawnLocations)
        {
            var go = Instantiate(BaseCardPrefab, BoosterSpawnLocation.position, Quaternion.identity, rare.transform);
            go.transform.DOMove(rare.transform.position, durationIndex).onComplete +=
                () => soundEffect.PlayOneShot(placeCardClip, 1);

            var images = go.transform.GetComponentsInChildren<Image>();
            images.ElementAt(1).sprite =  currentBoosterPackData.RareCards.ElementAt(Random.Range(0, currentBoosterPackData.RareCards.Count));


            var HolorareCheck = Random.Range(0, 3);

            if (HolorareCheck == 1)
            {
                
                images.ElementAt(1).sprite =
                    currentBoosterPackData.HoloRareCards.ElementAt(Random.Range(0,
                        currentBoosterPackData.HoloRareCards.Count));

                var card = go.GetComponentInChildren<CardSpin>();

                card.RareCard = true;
                
                
                if (currentBoosterPackData.SecretRareCards.Count > 0)
                {
                    var secretIndexDelta = Random.Range(54, 108);
                    var SecretRareCheck = Random.Range(0, secretIndexDelta);

                   if (SecretRareCheck == 0)
                   {
                       images.ElementAt(1).sprite =
                           currentBoosterPackData.SecretRareCards.ElementAt(Random.Range(0,
                               currentBoosterPackData.SecretRareCards.Count));
                       
                       var secretCard = go.GetComponentInChildren<CardSpin>();

                       card.RareCard = false;
                       secretCard.SecretRareCard = true;
                       
                   }
                }

            }
            
           
            
            durationIndex -= .1f;
            yield return new WaitForSeconds(.2f);
        }
        
        foreach (var uncommonSpawn in uncommonCardSpawnLocations)
        {
            var go = Instantiate(BaseCardPrefab, BoosterSpawnLocation.position, Quaternion.identity, uncommonSpawn.transform);
            go.transform.DOMove(uncommonSpawn.transform.position, durationIndex).onComplete +=
                () => soundEffect.PlayOneShot(placeCardClip, 1);

            var images = go.transform.GetComponentsInChildren<Image>();
            images.ElementAt(1).sprite =  currentBoosterPackData.UnCommonCards.ElementAt(Random.Range(0, currentBoosterPackData.UnCommonCards.Count));
            
            durationIndex -= .1f;
            yield return new WaitForSeconds(.2f);
        }
        
        
        foreach (var energySpawn in energyCardSpawnLocations)
        {
            var go = Instantiate(BaseCardPrefab, BoosterSpawnLocation.position, Quaternion.identity, energySpawn.transform);
            go.transform.DOMove(energySpawn.transform.position, durationIndex).onComplete +=
                () => soundEffect.PlayOneShot(placeCardClip, 1);

            var images = go.transform.GetComponentsInChildren<Image>();
            images.ElementAt(1).sprite =  currentBoosterPackData.EnergyCards.ElementAt(Random.Range(0, currentBoosterPackData.EnergyCards.Count));
            
            durationIndex -= .1f;
            yield return new WaitForSeconds(.2f);
        }
        
        foreach (var commonSpawn in commonCardSpawnLocations)
        {
            var go = Instantiate(BaseCardPrefab, BoosterSpawnLocation.position, Quaternion.identity, commonSpawn.transform);
            go.transform.DOMove(commonSpawn.transform.position, durationIndex).onComplete +=
                () => soundEffect.PlayOneShot(placeCardClip, 1);

            var Images = go.transform.GetComponentsInChildren<Image>();
            Images.ElementAt(1).sprite =
                currentBoosterPackData.CommonCards.ElementAt(Random.Range(0, currentBoosterPackData.CommonCards.Count));

            durationIndex -= .1f;
            yield return new WaitForSeconds(.2f);

        }
      

    }



    private void GetCommonLocations()
    {
        commonCardSpawnLocations = GameObject.FindGameObjectsWithTag("CommonSpot").ToList();
        commonCardSpawnLocations.Reverse(); 
    }

    private void GetUncommonLocations()
    {
        uncommonCardSpawnLocations = GameObject.FindGameObjectsWithTag("UncommonSpot").ToList();
        uncommonCardSpawnLocations.Reverse();
    }

    private void GetEnergySpawnLocations()
    {
        energyCardSpawnLocations = GameObject.FindGameObjectsWithTag("EnergySpot").ToList();
        energyCardSpawnLocations.Reverse();
    }

    private void GetRareLocations()
    {
        rareCardSpawnLocations = GameObject.FindGameObjectsWithTag("RareSpot").ToList();
        rareCardSpawnLocations.Reverse();
    }
}
