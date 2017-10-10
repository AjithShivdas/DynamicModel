using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModel
{
    class DynamicModelling
    {        
        private int _level; // Node level that increments on run time
        private int _nodes; // Nodes  that increments on run time
        // Total number of balls 15
        string[] Balls = new string[] { "B1", "B2", "B3","B4","B5","B6","B7","B8","B9","B10","B11","B12","B13","B14","B15" };
        // To Switch the gates from left right
        int[] gatescont = new int[] {0, 0, 1, 1, 0, 0,0,0,1,0,1,1,0,0,1,0};
        // Number of containers
        List<string> Contianers = new List<string>{ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P" };
        // Fix the branch level
        private int containerLevel;
        private string containerlist;
        public int Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }


        static void Main(string[] args)
        {
            DynamicModelling dynamicModelling = new DynamicModelling();
            dynamicModelling.LevelLoop();
        }

        public void LevelLoop()
        {   
         
            List<string> filledContainers = new List<string>();
            
            if (Balls != null)
            {
                foreach (string ball in Balls)
                {
                    containerLevel = 4;
                    _nodes = 1;                   
                    for (int i = 0; i < containerLevel; i++)
                    {
                        filledContainers.Add(FillContainer(_nodes, i, ball));                 
                    }          

                }              
                
            }

            var resultContainerlist = Contianers.Except(filledContainers).Select(x => new { Value = x  });
            foreach (var emptyContainer in resultContainerlist)
            {
                System.Console.WriteLine("Container" + " " + emptyContainer.Value + " remains Empty");
            }

           
        }       
        public string FillContainer(int nodes,int level, string ball)
        {            
            if (gatescont[nodes] == 0)
            {
                if (nodes < 16)
                {
                    gatescont[nodes] = 1;
                    _level = level + 1;
                    _nodes = nodes * 2;            
                                       
                }
                if (_nodes > 15)
                {            
                    System.Console.WriteLine("Container" + " " + Convert.ToChar(_nodes + 49) + "-" + ball);

                     containerlist = Convert.ToChar(_nodes + 49).ToString();                   

                }
                return containerlist;
            }
            else
            {
                if (nodes < 16)
                {
                    gatescont[nodes] = 0;
                    _nodes = nodes * 2 + 1;
                    _level = _level + 1;               
                }
                if (_nodes > 15)
                {                   
                    System.Console.WriteLine( "Container" + " " +  Convert.ToChar(_nodes + 49) + "-" + ball);                
                     containerlist = Convert.ToChar(_nodes + 49).ToString(); 
                }
               return containerlist;
            }

        }

    }
}



