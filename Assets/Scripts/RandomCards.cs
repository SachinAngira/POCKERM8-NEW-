using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCards : MonoBehaviour
{
   public int CardMinNumber;
   public int CardMaxNumber;

  
public int[] GetRandomCard(int NumberofCards)
{
    int[] cards = new int[NumberofCards];
    for (int i = 0; i < cards.Length; i++)
			{
			 cards[0] = Random.Range(CardMinNumber,CardMaxNumber);
			}
    return cards;
}
}
