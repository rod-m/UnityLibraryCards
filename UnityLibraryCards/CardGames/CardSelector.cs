using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    private Animator anim;
     float cardFrame = 0f;
    public int cardNum = 0;

    private int numSpritesInCardnDeck = 54;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0f;
   
    }

    public void SetCardNum(int _num)
    {
        cardNum = _num;
        cardFrame = cardNum / (float)numSpritesInCardnDeck;
        anim.Play("DeckOfCards",0,cardFrame);
    }
}
