using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kodimax 
{

    public class Movie 
    {
        public int Id;
        public string Name;
        public string Duration;
        public string Type;
        
        public Movie(){
        	
        }
        public Movie(int id, string name, string duration, string type){
        	Id= id;
        	Name= name;
        	Duration= duration;
        	Type= type;
        }
    }
}