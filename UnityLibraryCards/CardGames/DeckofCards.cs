using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityLibraryCards;

public static class EnumUtil
{
    public static IEnumerable<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}

[CreateAssetMenu(menuName = "DeckofCards", fileName = "DeckofCards.asset")]
public class DeckofCards : ScriptableObject, ISerializationCallbackReceiver
{
    public List<Card> deck;
    [NonSerialized] public List<Card> playDeck;

    public void OnAfterDeserialize()
    {
        playDeck = deck;
    }

    public void OnBeforeSerialize()
    {
       
        deck = new List<Card>();
        int count = 0;
        foreach (var s in EnumUtil.GetValues<Suit>())
        {
            foreach (var f in EnumUtil.GetValues<Face>())
            {
                Card card = new Card(s, f);
                deck.Add(card);
                count++;
            }
        }
    }
}