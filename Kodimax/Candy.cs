using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kodimax 
{

    public class Candy 
    {
        public int Id;
        public string Name;
        public string Type;
        public decimal Price;
        
        public Candy(){
        	
        }
        public Candy(int id, string name, string type, decimal price){
        	Id= id;
        	Name= name;
        	Type= type;
        	Price= price;
        }
    }
}