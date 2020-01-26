using System;

namespace UnityLibraryCards
{
    [Serializable]
    public class Card
    {
        public string name;
        public Face face;
        public Suit suit;
        //public GameObject cardPrefab;

        public Card(Suit _suit, Face _face)
        {
            suit = _suit;
            face = _face;

            SetName();
        }

        public void SetName()
        {
            name = String.Format("{0} of {1}s", face.ToString(), suit.ToString());
        }
    }
}