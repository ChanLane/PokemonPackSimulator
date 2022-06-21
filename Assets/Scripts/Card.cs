using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
   
    // Handles all movement associated with a card
    // moving to the card locations
    // fliping over 
    // cards will be instantiated and then immediatedly assigned CardData.

    private AudioSource audioSource;
    [SerializeField] private AudioClip cardPlacementSfx;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToCardLocation(Transform location, float movementSpeed)
    {
        transform.DOMove(location.position, movementSpeed).onComplete +=
            () => audioSource.PlayOneShot(cardPlacementSfx);
    }
}
