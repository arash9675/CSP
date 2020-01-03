using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP
{
    public class Inputs
    {
        public  int nCages;
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
    }
    public class Cages 
    {
        public int size;
        public List<Cages> adjacent;
        public Cages() 
        {
            adjacent = new List<Cages>();
        }
    }
}
