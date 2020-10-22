using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kodimax
{

    public class Client : Bills
    {
        
        //Ver cartelera
        public void SeeMovies(List<Movie> movies){
    		Console.Clear();
    		Console.WriteLine("        KODIMAX - Cartelera\n");
    		foreach(Movie m in movies){
    			Console.WriteLine("-----------------------------------");
    			Console.WriteLine("\n    {0}\n", m.Name);
    			Console.WriteLine("Id: {0}", m.Id);
    			Console.WriteLine("Duracion: {0}", m.Duration);
    			Console.WriteLine("Tipo de pelicula: {0}\n", m.Type);
    		}
    	}
    	//Ver tienda de golosinas
    	public void SeeCandiesShop(List<Candy> candies){
    		Console.Clear();
    		Console.WriteLine("    KODIMAX - Tienda de golosinas \n");
    		foreach(Candy c in candies){
    			Console.WriteLine("-----------------------------------");
    			Console.WriteLine("\n    {0}\n", c.Name);
    			Console.WriteLine("Id: {0}", c.Id);
    			Console.WriteLine("Tipo de golosina: {0}", c.Type);
    			Console.WriteLine("Precio: ${0:0.00}\n", c.Price);
    		}
    	}
        //Ver lista de sucursales
        public void SeeBranches(List<Branch> branches)
        {
            Console.Clear();
            Console.WriteLine("   KODIMAX - Sucursales \n");
            foreach (Branch b in branches)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("\n    {0}\n", b.Name);
                Console.WriteLine("Id: {0}", b.Id);
                Console.WriteLine("Precio en Autocine: ${0:0.00}\n", b.Price);
            }
        }
    	
    }
}