using System;
using System.Collections.Generic;

namespace TaskRaft
{
    class Program
    {
       

        static void Main(string[] args)
        {
            int fillRaft(ref List<int> lAnimals, int sizeOfRaft)
            {
                int sumOfAnimalsInBoat = 0;
                while (sumOfAnimalsInBoat < sizeOfRaft)
                {
                    if (lAnimals.Count <= 0)
                    {
                        break;
                    }
                    int i = 0;
                    for (i = 0; i < lAnimals.Count; i++)
                    {
                        if (lAnimals[i] < sizeOfRaft-sumOfAnimalsInBoat)
                        {
                            break;
                        }
                    }
                    if(i>=lAnimals.Count)
                    {
                        return sumOfAnimalsInBoat;
                    }
                    if(sumOfAnimalsInBoat + lAnimals[i] <= sizeOfRaft)
                    {
                        sumOfAnimalsInBoat += lAnimals[i];
                        lAnimals.RemoveAt(i);
                    }
                    else
                    {
                        return sumOfAnimalsInBoat;
                    }
                }

                return sumOfAnimalsInBoat;
            }

            string[] sInLine = Console.ReadLine().Split(" ");
            int n = int.Parse(sInLine[0]);
            int k = int.Parse(sInLine[1]);
            if(n<1 || n>1000)
            {
                return;
            }
            if (k < 1 || k > 1000)
            {
                return;
            }
            List<int> lAnimalsW = new List<int>();
            sInLine = Console.ReadLine().Split(" ");
            if(sInLine.Length!=n)
            {
                return;
            }
            foreach (string s in sInLine)
            {
                if (int.TryParse(s, out _))
                {
                    if(int.Parse(s)>=1 || int.Parse(s)<=100000)
                    {
                        lAnimalsW.Add(int.Parse(s));
                    }
                }
            }

            lAnimalsW.Sort();
            lAnimalsW.Reverse();

            int iSumOfAnimalW = 0;
            for (int i = 0; i < lAnimalsW.Count; i++)
            {
                iSumOfAnimalW += lAnimalsW[i];
            }
            double dEqualSpace = iSumOfAnimalW / k;
            int iMinimalPossibleSize = (int)Math.Floor(dEqualSpace);
            int iNumOfAttempts;
            int iRaftSize = iMinimalPossibleSize;
            do
            {
                iNumOfAttempts = 0;
                List<int> tempList = lAnimalsW;
                while (tempList.Count > 0)
                {
                    fillRaft(ref tempList, iRaftSize);
                    iNumOfAttempts++;
                }
                if(iNumOfAttempts > k)
                {
                    iRaftSize++;
                }
            } while (iNumOfAttempts > k);
            Console.WriteLine(iRaftSize);
        }
    }
}
