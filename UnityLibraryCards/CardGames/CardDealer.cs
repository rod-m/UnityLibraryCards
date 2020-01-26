using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System;
using Random = System.Random;

namespace UnityLibraryCards
{
    public class CardDealer : MonoBehaviour
    {

        [Header("Placement")]
        // where the cards are placed
        public Transform table;
        // card prefab
        public GameObject cardPrefab;
        // for choosing a random card
        Random randomCard = new Random();
        // uses the DeckOfCards scriptable object
        public DeckofCards master_deck;
        // each player has a list of cards at runtime
        public DeckofCards[] playerCards; // uses a scriptable object but doesnt need to, for example only
        [Range(0.02f,1.0f)]
        public float spacer = 0.5f; // adjust how far the cards are placed apart
        private int turn = 0; // what player is playing
        public int round = 0; // after all players have played this increments
        public Card[] currentPlayer; // quik view of current player hand for debugging
        [Header("How Many Players")]
        [Range(1,8)]
        public int numPlayers = 2;

        private Vector3 pos;

        // Start creates all the player decks
        void Start()
        {
            playerCards = new DeckofCards[numPlayers];

            for (int i = 0; i < numPlayers; i++)
            {
                playerCards[i] = ScriptableObject.CreateInstance<DeckofCards>();
                playerCards[i].playDeck = new List<Card>();
            }

            pos = new Vector3(table.position.x, table.position.y, table.position.z);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                // a card is dealt by random
                int r = randomCard.Next(master_deck.playDeck.Count);
              
                Card card = master_deck.playDeck[r];
                //  add selected card to current player
                playerCards[turn].playDeck.Add(card);
                // remove card from master deck
                master_deck.playDeck.RemoveAt(r);
                
                // for degub display to show what cards a player has
                List<Card> deck = playerCards[turn].playDeck;
                currentPlayer = deck.ToArray();
               // place each card player apart vertically
                pos.y = table.position.y + turn;
                // make a new card from prefab
                GameObject c = Instantiate(cardPrefab, pos, Quaternion.identity);
                c.SendMessage("SetCardNum", r);
                // add the card to the table gameobject
                c.transform.parent = table;
                // next players turn
                turn++;
                if (turn >= numPlayers)
                {
                    // all players dealt
                    round++;
                    turn = 0;
                    pos.x += spacer;
                     Debug.Log(String.Format("round {0}", round));
                }

            }
        }
    }

}


    