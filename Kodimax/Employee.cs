using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kodimax
{

    public class Employee : People
    {
    	public int Id;
    	public Employee(){
    		
    	}
    	public Employee(int id, string names, string surnames, string email, string tel, char sex, string birthdate, string user, string password){
	        Id= id;
	        Names= names;
	        Surnames= surnames;
	        Email= email;
	        Tel= tel;
	        Sex= sex;
	        BirthDate= birthdate;
	        User= user;
	        Password= password;
        } 
        //Agregar pelicula
    	public void AddMovie(List<Movie> movies){
    		Movie movie= new Movie();
    		
    		Console.Clear();
    		Console.WriteLine("     KODIMAX - Agregar pelicula\n");
    		Console.Write("Id: ");
    		movie.Id= int.Parse(Console.ReadLine());
    		Console.Write("Nombre: ");
    		movie.Name= Console.ReadLine();
    		Console.Write("Duracion: ");
    		movie.Duration= Console.ReadLine();
    		Console.Write("Tipo de pelicula: ");
    		movie.Type= Console.ReadLine();
    		Console.WriteLine("\nLa pelicula {0} fue agregada exitosamente", movie.Name);
    		movies.Add(movie);//agregar la pelicula a la lista
    	}
    	//Eliminar una pelicula
    	public void DeleteMovie(List<Movie> movies){
    		int id, index=0, pass=0;
    		
    		Console.Clear();
    		Console.WriteLine("     KODIMAX - Agregar pelicula");
    		do{
		   		Console.Write("\nIngrese el Id de la pelicula que eliminara: ");
		    	id= int.Parse(Console.ReadLine());
		   		for(int i= 0; i<movies.Count; i++){
		    		if(id ==movies[i].Id){
		    			index= i;
		    			pass = 1;
		    			break;
		    		}else{
		    			pass=0;
		    		}
		    	}
		    	if(pass== 0) Console.WriteLine("\nEl id es incorrecto, ingeselo de nuevo");
	    	}while(pass== 0);
	    	Console.WriteLine("\nLa pelicula {0} fue eliminada", movies[index].Name);
	    	movies.RemoveAt(index);
    	}
    	//Agregar una golosina
    	public void AddCandy(List<Candy> candies){
    		Candy candy= new Candy();
    		
    		Console.Clear();
    		Console.WriteLine("     KODIMAX - Agregar golosina\n");
    		Console.Write("Id: ");
    		candy.Id= int.Parse(Console.ReadLine());
    		Console.Write("Nombre: ");
    		candy.Name= Console.ReadLine();
    		Console.Write("Tipo de golosina: ");
    		candy.Type= Console.ReadLine();
    		Console.Write("Precio: ");
    		candy.Price= decimal.Parse(Console.ReadLine());
    		
    		Console.WriteLine("\nEl producto {0} fue agregada exitosamente", candy.Name);
    		candies.Add(candy);//agregar la golosina a la lista
    	}
    	//Verificar si el id ingresado existe y devolver el indice de la golosina buscada
    	private int VerifyCandiesId(List<Candy> candies){
    		int id, index=0, pass=0;
			do{
		   		Console.Write("\nIngrese el Id de la golosina: ");
		    	id= int.Parse(Console.ReadLine());
		   		for(int i= 0; i<candies.Count; i++){
		    		if(id ==candies[i].Id){
		    			index= i;
		    			pass = 1;
		    			break;
		    		}else{
		    			pass=0;
		    		}
		    	}
		    	if(pass== 0) Console.WriteLine("\nEl id es incorrecto, ingeselo de nuevo");
	    	}while(pass== 0);
	    	return index;
    	}
    	//Eliminar una golosina
    	public void DeleteCandy(List<Candy> candies){
    		int index;
    		Console.Clear();
    		Console.WriteLine("     KODIMAX - Agregar golosina");
	    	index=  VerifyCandiesId(candies);//Obtener index de la golosina
	    	Console.WriteLine("\nEl producto {0} fue eliminado", candies[index].Name);
	    	candies.RemoveAt(index);
    	}
    	//Modificar una golosina 
    	public void ModifyCandies(List<Candy> candies){
    		int opt, index;
    		Console.Clear();
    		Console.WriteLine("     KODIMAX - Modificar golosina");
    		
	    	index=  VerifyCandiesId(candies);
	    	Console.WriteLine("\nDesea mofificar el tipo de golosina de");
    		Console.WriteLine("{0} (digite el nunero)?", candies[index].Name);
    		Console.WriteLine("1.Si\n2.No\n");
    		opt= int.Parse(Console.ReadLine());
    		if(opt== 1){
    			Console.Write("\nTipo de golosina: ");
    			candies[index].Type= Console.ReadLine();
    		}
    		Console.WriteLine("\nDesea mofificar el precio de {0} (digite el nunero)?", candies[index].Name);
    		Console.WriteLine("1.Si\n2.No\n");
    		opt= int.Parse(Console.ReadLine());
    		if(opt== 1){
    			Console.Write("\nPrecio: ");
    			candies[index].Price= decimal.Parse(Console.ReadLine());
    		}
    		Console.WriteLine("\nCambios realizados exitosamente");
    		
    	}
    }
}