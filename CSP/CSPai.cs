using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP
{
    class CSPai
    {

        public int[] LCV(Animals a) 
        {
            int[] count=new int [a.domain.Count()];
            //int i=0;
            foreach (var b in a.neighbourAllow) 
            {
                for(int i=0;i<a.domain.Count();i++)
                    if (a.domain[i] == b.domain[i]&&a.domain[i]==1) 
                    {
                        count[i]++;
                    }
            }
            return count;
        }
        public void MRV() 
        {

        }
        public void FC() 
        {

        }

       // public 
        
        public void CreatingSit() 
        {
           // return AnimalsFirstSit();
            Inputs a = new Inputs();
            List<Cages> cagesList = new List<Cages>();
            for (int i = 0; i < a.nCages; i++) 
            {
                cagesList.Add(new Cages());
                cagesList.ElementAt(i).size = a.cagesSize[i];
                
            }
            for (int i = 0; i < cagesList.Count(); i++)
            {
                for (int j = 0; j < a.cagesBouring.GetLength(0); j++)
                {
                    for (int z = 0; z < 2; z++) 
                    {
                        if (a.cagesBouring[j, z] == i + 1) 
                        {
                            if (z == 0) cagesList.ElementAt(i).adjacent.Add(cagesList.ElementAt((a.cagesBouring[j, 1]) - 1));
                            else cagesList.ElementAt(i).adjacent.Add(cagesList.ElementAt((a.cagesBouring[j, 0]) - 1));
                        }
                    }
                }

            }

        }

        private static List<Animals> AnimalsFirstSit()
        {
            Inputs a = new Inputs();

            List<Animals> animalsList = new List<Animals>();

            for (int i = 0; i < a.nAnimals; i++)
            {
                animalsList.Add(new Animals());
                animalsList.ElementAt(i).size = a.animalsSize[i];
                animalsList.ElementAt(i).domain = new int[a.nCages];
                for (int j = 0; j < a.nCages; j++)
                {
                    if (animalsList.ElementAt(i).size > a.cagesSize[j])
                        animalsList.ElementAt(i).domain[j] = 0;
                    else
                        animalsList.ElementAt(i).domain[j] = 1;
                }
            }
            for (int i = 0; i < animalsList.Count(); i++)
            {
                for (int j = 0; j < a.nAnimals; j++)
                {
                    if (a.animalNeigh[i, j] == 1 && i != j)
                        animalsList.ElementAt(i).neighbourAllow.Add(animalsList.ElementAt(j));
                }

            }
            return animalsList;
        }

    }
}
