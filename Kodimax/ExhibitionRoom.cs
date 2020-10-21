using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kodimax
{

    public class ExhibitionRoom 
    {
        public string nStan= "Estandar", nPrem= "Premium", nVip= "VIP";//nombres de las salas
    	public int saStan= 64, saPrem= 40, saVip= 30;//espacios disponibles de las salas
    	
    	//Modificar sala de exhibicion
    	public void ModifyExibitRooms(){
    		int opt, change;
    		
    		Console.Clear();
	        Console.WriteLine("    KODIMAX - Modificar sala de exhibicion\n");
	        Console.WriteLine("Elija la sala que modificara (digite el numero) ");
	        Console.WriteLine("\n1.{0} - Asientos disponibles: {1}", nStan, saStan);
	        Console.WriteLine("2.{0} - Asientos disponibles: {1}", nPrem, saPrem);
	        Console.WriteLine("3.{0} - Asientos disponibles: {1}\n", nVip, saVip);
	        opt= int.Parse(Console.ReadLine());
	        Console.WriteLine("\nDesea cambiar el nombre de la sala (digite el numero)? ");
	        Console.WriteLine("1.Si\n2.No\n");
	        change= int.Parse(Console.ReadLine());
	        if(change== 1){
	        	if(opt== 1){
	        		Console.Write("\nNombre: ");
	        		nStan= Console.ReadLine();
	        	}else if(opt== 2){
	        		Console.Write("\nNombre: ");
	        		nPrem= Console.ReadLine();
	        	}else if(opt== 3){
	        		Console.Write("\nNombre: ");
	        		nVip= Console.ReadLine();
	        	}
	        }
	        Console.WriteLine("\nDesea cambiar la cantidad de asientos de la \nsala (digite el numero)? ");
	        Console.WriteLine("1.Si\n2.No\n");
	        change= int.Parse(Console.ReadLine());
	        if(change== 1){
	        	if(opt== 1){
	        		Console.Write("\nAsientosos disponibles: ");
	        		saStan= int.Parse(Console.ReadLine());
	        	}else if(opt== 2){
	        		Console.Write("\nAsientos disponibles: ");
	        		saPrem= int.Parse(Console.ReadLine());
	        	}else if(opt== 3){
	        		Console.Write("\nAsientos disponobles: ");
	        		saVip= int.Parse(Console.ReadLine());
	        	}
	        }
	        if(opt== 1) Console.WriteLine("\nSala: {0} - Asientos disponibles: {1}", nStan, saStan);
	        else if(opt== 2) Console.WriteLine("\nSala: {0} - Asientos disponibles: {1}", nPrem, saPrem);
	        else if(opt== 3) Console.WriteLine("\nSala: {0} - Asientos disponibles: {1}", nVip, saVip);
    	}
    }
}