using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kodimax
{

    public class People 
    {
		public string Names;
        public string Surnames;
        public string Email;
        public string Tel;
        public char Sex;
        public string BirthDate;
        public string User;
        public string Password;
		
		public People(){
        
        }
        public People(string names, string surnames, string email, string tel, char sex, string birthdate, string user, string password){
	        Names= names;
	        Surnames= surnames;
	        Email= email;
	        Tel= tel;
	        Sex= sex;
	        BirthDate= birthdate;
	        User= user;
	        Password= password;
        } 
        //Registrar un usuario
        public void Register(List<People> clientes, List<Employee> empls, int count){
	        string day, month, year, code;
	        int again= 1;
	        People per= new People();
	        
	        Console.Clear();
	        Console.WriteLine("      KODIMAX - Registrarse\n");
	        Console.Write("Nombres: ");
	        per.Names= Console.ReadLine();
	        Console.Write("Apellidos: ");
	        per.Surnames= Console.ReadLine();
	        Console.Write("Email: ");
	        per.Email= Console.ReadLine();
	        Console.Write("Telefono: ");
	        per.Tel= Console.ReadLine();
	        //Verificar que el sexo sea ingresado correctamente
	        do{
	        	Console.Write("Sexo('M' o 'F'): ");
	        	per.Sex= char.Parse(Console.ReadLine());
	        	if(per.Sex== 'M' || per.Sex== 'F' || per.Sex== 'm' || per.Sex== 'f'){ 
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
	        per.BirthDate= day+"/"+month+"/"+year;
	        Console.WriteLine("\nFecha de nacimiento: {0}\n", per.BirthDate);
	        
	        Console.Write("Usuario: ");
	        per.User= Console.ReadLine();
	        Console.Write("Contraseña: ");
	        per.Password= Console.ReadLine();
	        
	        Console.Write("\nSi es empleado ingrese el codigo para \nregistrarse como tal: ");
		    code = Console.ReadLine();
		    //Decidir si lo registrara como cliente o empleado 
		    if(code == "emp-max"){
		    	Employee empl= new Employee();
		    	empl.Id= count;
		    	empl.Names=per.Names;
		        empl.Surnames= per.Surnames;
		        empl.Email= per.Email;
		        empl.Tel= per.Tel;
		        empl.Sex= per.Sex;
		        empl.BirthDate= per.BirthDate;
		        empl.User= per.User;
		        empl.Password= per.Password;
			   	
			   	empls.Add(empl);
			   	Console.WriteLine("\nNuevo empleado registrado exitosamente");
		    }else{
		    	clientes.Add(per);
		    	Console.WriteLine("\nNuevo cliente registrado exitosamente");
		    }
		    Console.ReadLine();
        } 
    }
}