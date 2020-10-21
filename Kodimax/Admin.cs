using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kodimax
{

    public class Admin : Employee
    {
		private int count = 10;
        public Admin(string user, string password){
        	User= user;
        	Password= password;
        }
        //Registrar un empleado
        public void RegisterEmployee(List<Employee> empleados){
	        string day, month, year;
	        int again= 1;
	        Employee emp= new Employee();
	        
	        Console.Clear();
	        Console.WriteLine("       KODIMAX - Registrar empleado\n");
	        emp.Id= count++;
	        Console.Write("Nombres: ");
	        emp.Names= Console.ReadLine();
	        Console.Write("Apellidos: ");
	        emp.Surnames= Console.ReadLine();
	        Console.Write("Email: ");
	        emp.Email= Console.ReadLine();
	        Console.Write("Telefono: ");
	        emp.Tel= Console.ReadLine();
	        //Verificar que el sexo sea ingresado correctamente
	        do{
	        	Console.Write("Sexo('M' o 'F'): ");
	        	emp.Sex= char.Parse(Console.ReadLine());
	        	if(emp.Sex== 'M' || emp.Sex== 'F' || emp.Sex== 'm' || emp.Sex== 'f'){ 
	        		again= 0;
	        	}else{ 
	        		Console.WriteLine("\nSolo puede ingresar las letras 'M' o 'F'\n");
	        		again= 1;
	        	}
	        }while(again ==1);
	        Console.WriteLine("\nFecha de nacimiento \n");
	        Console.Write("Dia: ");
	        day= Console.ReadLine();
	        Console.Write("Mes: ");
	        month= Console.ReadLine();
	        Console.Write("Año: ", 164);
	        year= Console.ReadLine();
	        emp.BirthDate= day+"/"+month+"/"+year;
	        Console.WriteLine("\nFecha de nacimiento: {0}\n", emp.BirthDate);
	        
	        Console.Write("Usuario: ");
	        emp.User= Console.ReadLine();
	        Console.Write("Contraseña: ");
	        emp.Password= Console.ReadLine();
	        Console.WriteLine("\nEmpledo ingresado exitosamente");
	        empleados.Add(emp);
        }
        //Eliminar un empleado
        public void DeleteEmployee(List<Employee> empls){
        	int index=0, pass=0;
    		string user;
    		Console.Clear();
    		Console.WriteLine("     KODIMAX - Eliminar empleado");
    		do{
		   		Console.Write("\nIngrese el usiario del empleado que eliminara: ");
		    	user= Console.ReadLine();
		   		for(int i= 0; i<empls.Count; i++){
		    		if(user ==empls[i].User){
		    			index= i;
		    			pass = 1;
		    			break;
		    		}else{
		    			pass=0;
		    		}
		    	}
		    	if(pass== 0) Console.WriteLine("\nEl usuario no existe, ingeselo de nuevo");
	    	}while(pass== 0);
	    	Console.WriteLine("\nLa empleado {0} fue eliminado", empls[index].Names);
	    	empls.RemoveAt(index);
	    	
        }
        //Eliminar un cliente
        public void DeleteClient(List<People> clientes){
        	int index=0, pass=0;
    		string user;
    		Console.Clear();
    		Console.WriteLine("     KODIMAX - Eliminar cliente");
    		do{
		   		Console.Write("\nIngrese el usiario del cliente que eliminara: ");
		    	user= Console.ReadLine();
		   		for(int i= 0; i<clientes.Count; i++){
		    		if(user ==clientes[i].User){
		    			index= i;
		    			pass = 1;
		    			break;
		    		}else{
		    			pass=0;
		    		}
		    	}
		    	if(pass== 0) Console.WriteLine("\nEl usuario no existe, ingeselo de nuevo");
	    	}while(pass== 0);
	    	Console.WriteLine("\nEl cliente {0} fue eliminado", clientes[index].Names);
	    	clientes.RemoveAt(index);
        }
    }
}