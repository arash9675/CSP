using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP
{
    public class Inputs
    {
        public int nCages;
        public int nAnimals;
        public int nBouring;
        public int[] cagesSize;
        public int[] animalsSize;
        public int[,] animalNeigh;
        public int[,] cagesBouring;
        public Inputs() 
        {
            nCages = 6;
            nAnimals = 6;
            nBouring = 5;
            animalsSize = new int[6]{3 ,1 ,2 ,1 ,2 ,2};
            cagesSize = new int[6] { 1, 2, 4, 2, 3, 3 };
            animalNeigh=new int[6,6]{{1, 0 ,1 ,0 ,1 ,1},{0 ,1 ,0 ,0 ,1 ,0},{1 ,0 ,1 ,1 ,1, 1},{0, 0 ,1 ,1 ,1 ,0},{1 ,1 ,1 ,1 ,1 ,1},{1 ,0 ,1 ,0 ,1 ,1}};
            cagesBouring=new int[5,2]{{1,2},{2,3},{3,4},{4,5},{4,6}};
        }
        public Inputs(int cages, int animals, int bouring, int[] cageSize, int[] animSize, int[,] animNeigh,int[,]cagesBourings) 
        {
            nCages = cages;
            nAnimals = animals;
            nBouring = bouring;
            animalsSize = animSize;
            cagesSize = cageSize;
            animalNeigh = animNeigh;
            cagesBouring = cagesBourings;
 
        }
    }
    public class Animals 
    {
        public int size;
        public int[] domain;
        public List<Animals> neighbourAllow;
        public Animals() 
        {
            neighbourAllow = new List<Animals>();
            //domain = new int[20];
        }
        public int DomainCount() 
        {
            int temp = 0;
            for (int i = 0; i < this.domain.Count(); i++) 
            {
                if (this.domain[i] == 1) temp++;
            }
            return temp;
        }
        public List<Cages> AvailableDomains(List<Cages> cages)
        {
            //Inputs a=new Inputs();
            List<Cages> tempCages = new List<Cages>(cages);
            for (int i = tempCages.Count() - 1; i >= 0; i--)
            {
                if (tempCages.ElementAt(i).size < this.size) tempCages.RemoveAt(i);
            }


            for (int i = tempCages.Count() - 1; i >= 0; i--)
            {
                if (tempCages.ElementAt(i).animalInIt != null) tempCages.RemoveAt(i);
            }

            for (int i = tempCages.Count() - 1; i >= 0; i--)
            {
                bool deleted = false;
                for (int j = tempCages.ElementAt(i).adjacent.Count() - 1; j >= 0; j--) 
                {
                    int flag = 0;
                    if (tempCages.ElementAt(i).adjacent.ElementAt(j).animalInIt != null) 
                    {
                        foreach (var neigh in this.neighbourAllow) 
                        {
                            if (neigh == tempCages.ElementAt(i).adjacent.ElementAt(j).animalInIt) flag = 1;
                        }
                        if (flag == 0) 
                        { tempCages.RemoveAt(i); 
                            deleted = true; } 
                    }
                    if (deleted) break;
                }
                
            }

            return tempCages;
        }


        public int AvailableDomainCount(List<Cages> cages) 
        {
            return AvailableDomains(cages).Count();
        }
    }
    public class Cages 
    {
        public int size;
        public List<Cages> adjacent;
        public Animals animalInIt;
        public Cages() 
        {
            adjacent = new List<Cages>();
            animalInIt = null;
        }
    }
}
