using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "BoosterPackData", menuName = "CreateBoosterPackData")]
public class BoosterPackData : ScriptableObject
{

    [SerializeField]
    private List<Sprite> commonCards = new List<Sprite>(); 
    
    [SerializeField]
    private List<Sprite> energyCards = new List<Sprite>();
    
    [SerializeField]
    private List<Sprite> unCommonCards = new List<Sprite>();

    [SerializeField]
    private List<Sprite> rareCards = new List<Sprite>();

    [SerializeField]
    private List<Sprite> holoRareCards = new List<Sprite>();

    [SerializeField]
    private List<Sprite> secretRareCards = new List<Sprite>();

    [SerializeField]
    public Sprite boosterPackArt;

    [SerializeField] private int CardsInPack;

    public int commonPerPack;
    public int uncommonPerPack;
    public int rarePerPack;


    public List<Sprite> CommonCards
    {
        get => commonCards;
        set => commonCards = value;
    }

    public List<Sprite> UnCommonCards
    {
        get => unCommonCards;
        set => unCommonCards = value;
    }

    public List<Sprite> RareCards
    {
        get => rareCards;
        set => rareCards = value;
    }

    public List<Sprite> HoloRareCards
    {
        get => holoRareCards;
        set => holoRareCards = value;
    }

    public List<Sprite> SecretRareCards
    {
        get => secretRareCards;
        set => secretRareCards = value;
    }

    public List<Sprite> EnergyCards
    {
        get => energyCards;
        set => energyCards = value;
    }
}
