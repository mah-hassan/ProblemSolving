int[] hand = [1,2,3,6,2,3,4,7,8];

int groupSize = 3;

var isNStraightHand = new Solution().IsNStraightHand(hand, groupSize);

Console.WriteLine(isNStraightHand); 
public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if((hand.Length % groupSize) != 0)
            return false;
        
        Dictionary<int, int> cardsFrequency = new();
        foreach(var card in hand)
        {
            if(cardsFrequency.ContainsKey(card))
                cardsFrequency[card]++;
            else
                cardsFrequency[card] = 1;
        }

        PriorityQueue<int, int> priorityQueue = new();

        foreach(var card in hand)
            priorityQueue.Enqueue(card, card);

        int currMin = priorityQueue.Peek();
        int next = currMin + 1;
        int currGroupSize = 0;
        for(int i = 0; i < (hand.Length / groupSize); i++)
        {
            if(priorityQueue.Peek() == currMin && cardsFrequency.ContainsKey(currMin))
            {
                currGroupSize++;  
                next = currMin + 1;
                ResetCardsFrequency(cardsFrequency, currMin);          
            }
            else if(priorityQueue.Peek() == currMin && !cardsFrequency.ContainsKey(currMin))
            {               
                priorityQueue.Dequeue();
              
                if(priorityQueue.Count > 0)
                {
                    currMin = priorityQueue.Peek();
                    while(!cardsFrequency.ContainsKey(currMin)){
                        priorityQueue.Dequeue();
                        if(priorityQueue.Count == 0)
                            return false;
                        currMin = priorityQueue.Peek();
                    }
                    currGroupSize++;
                    ResetCardsFrequency(cardsFrequency, currMin);
                    next = currMin + 1;
                }
                else
                    return false;
                            
            }
            while(currGroupSize != groupSize)
            {
                if(!cardsFrequency.ContainsKey(next))
                    return false;

                currGroupSize++;

                ResetCardsFrequency(cardsFrequency, next);
                
                next++;
            }
            currGroupSize = 0;
        }

        return true;
    }
    private void ResetCardsFrequency(Dictionary<int, int> cardsFrequency, int key)
    {
        cardsFrequency[key]--;
        if(cardsFrequency[key] == 0)
            cardsFrequency.Remove(key);
    }
    // Second solution using sorting
    public bool IsNStraightHandWithSorting(int[] hand, int groupSize) {
        if (hand.Length % groupSize != 0)
            return false;
     
        Array.Sort(hand); // O(Nlog(N))

        
        Dictionary<int, int> cardsFrequency = new();
        foreach (var card in hand) {
            if (cardsFrequency.ContainsKey(card))
                cardsFrequency[card]++;
            else
                cardsFrequency[card] = 1;
        }

        
        foreach (var card in hand) {
            if (!cardsFrequency.ContainsKey(card)) {
                continue;
            }

            for (int i = 0; i < groupSize; i++) {
                int currentCard = card + i;
                
                if (!cardsFrequency.ContainsKey(currentCard)) {
                    return false;
                }

                ResetCardsFrequency(cardsFrequency, currentCard);
            }
        }

        return true;
    }
}