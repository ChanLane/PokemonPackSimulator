using System.Collections.Generic;
using Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Cards
{
   
    [CreateAssetMenu(fileName = "CardData", menuName = ("New Card"))]
    public class CardData : ScriptableObject
    { 
    
      
        [PreviewField]
        [SerializeField] private Sprite cardArt;
        [SerializeField] private CardType cardType;
        
        [SerializeField] private string cardName;
        [SerializeField] private string artIllustrator;
        [SerializeField] private int yearReleased;
        
     
        [ShowIf("cardType", CardType.Pokemon)]
        [TabGroup("Pokemon Options")]
        [SerializeField] private EnergyType energyType;
       
        [ShowIf("cardType", CardType.Pokemon)]
        [TabGroup("Pokemon Options")]
        [SerializeField] private PokemonStage stage;
       
        [ShowIf("cardType", CardType.Pokemon)]
        [TabGroup("Pokemon Options")]
        [SerializeField] private int healthPoints;
      
        [ShowIf("cardType", CardType.Pokemon)]
        [TabGroup("Pokemon Options")]
        [SerializeField] private EnergyType weakness;
       
        [ShowIf("cardType", CardType.Pokemon)]
        [TabGroup("Pokemon Options")]
        [SerializeField] private EnergyType resistance;
       
        [ShowIf("cardType", CardType.Pokemon)]
        [TabGroup("Pokemon Options")]
        [SerializeField] private int retreatCost;
       
        [ShowIf("cardType", CardType.Pokemon)]
        [TabGroup("Pokemon Options")]
        [SerializeField] private AudioClip pokemonCry;
        
        
        
     
        [SerializeField] private SecondaryCardType secType;
        
        [SerializeField] private int pokemonLevel;
        [SerializeField] private string moveText;
        
        
        [SerializeField] private Edition edition;
        [SerializeField] private BoosterSet set;
        [SerializeField] private Series series;
        [SerializeField] private int setNumber;
        [SerializeField] private Rarity rarity;
        [SerializeField] private bool flavorText;
        [SerializeField] private bool ruleBox;
        [SerializeField] private bool ability;
        [SerializeField] private bool pokeBody;
        [SerializeField] private bool pokePower;
        [SerializeField] private bool level;
        [SerializeField] private bool pokemonPower;
        [SerializeField] private bool ancientTrait;
        [SerializeField] private bool heldItem;
        

    }
}
