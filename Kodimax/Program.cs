using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kodimax
{

    public class Program
    {

        public static void Main()
        {
            //Codigo para registrar a alguien como empleado: emp-max
            int pass = 0, opt, regis, optmenu;
            int again = 1, exit, modify;
            string user, password;
            char selectRep;
            
            //Instancias de clases
            Admin admin = new Admin("admin-max", "@dminM@x");
            People p = new People();
            Client client = new Client();
            Employee empl = new Employee();
            ExhibitionRoom er = new ExhibitionRoom();
            Reports reps = new Reports();

            //Lista de Clientes
            List<People> clients = new List<People>();
            clients.Add(new People("David", "Mendoza", "davmen@gmail.com", "87654321", 'M', "19/06/01", "david", "9182"));
            clients.Add(new People("Carmen", "Morales", "carmor@gmail.com", "78494999", 'F', "31/09/99", "carmen", "0192"));
            clients.Add(new People("Eduardo", "Guevara", "edugue@gmail.com", "83839396", 'M', "12/03/99", "eduardo", "8374"));
            //Lista de empledos
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(1, "Angel", "Servellon", "angser@gmail.com", "12345678", 'M', "19/06/01", "angel", "1234"));
            employees.Add(new Employee(2, "Kevin", "Gutierrez", "kevgut@gmail.com", "91234567", 'M', "14/01/01", "kevin", "5678"));
            employees.Add(new Employee(3, "Jennifer", "Beltran", "jenbel@gmail.com", "89123456", 'F', "23/10/01", "jenny", "9123"));
            //Lista de peliculas
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie(1, "Mulan", "2h", "Accion/Aventura"));
            movies.Add(new Movie(2, "Aladdin", "2h 8m", "Aventura/Infantil"));
            movies.Add(new Movie(3, "Detective pikachu", "1h 45m", "Infantil/Misterio"));
            movies.Add(new Movie(4, "Shazam", "2h 12m", "Accion/Comedia"));
            movies.Add(new Movie(5, "Joker", "2h 2m", "Crimen/Drama"));
            //Lista de dulces
            List<Candy> candies = new List<Candy>();
            candies.Add(new Candy(1, "Snickers", "Chocolate", 3.25m));
            candies.Add(new Candy(2, "Ositos de goma", "Gomitas", 2.90m));
            candies.Add(new Candy(3, "M&M's", "Chocolate", 3.85m));
            candies.Add(new Candy(4, "Mentas", "Dulce", 1.25m));
            candies.Add(new Candy(5, "Bon o Bon", "Chocolate", 0.75m));
            do
            {
                exit = 0;
                //Login
                do
                {
                    Console.Clear();
                    Console.WriteLine("            KODIMAX\n");
                    Console.WriteLine("Elija el tipo de usuario al que \npertenece(digite el numero): ");
                    Console.WriteLine("\n1.Cliente\n2.Empleado\n3.Administrador\n");
                    Console.WriteLine("Si no desea ingresar digite 4.\n");
                    opt = int.Parse(Console.ReadLine());
                    //No ingresar
                    if (opt == 4) break;
                    Console.Clear();

                    Console.WriteLine("            KODIMAX\n");
                    Console.Write("Usuario: ");
                    user = Console.ReadLine();
                    Console.Write("Contraseña: ");
                    password = Console.ReadLine();
                    switch (opt)
                    {
                        case 1:
                            foreach (People c in clients)
                            {
                                if (user == c.User && password == c.Password)
                                {
                                    pass = 1;
                                    break;
                                }
                                else
                                {
                                    pass = 0;
                                }
                            }
                            break;
                        case 2:
                            foreach (People e in employees)
                            {
                                if (user == e.User && password == e.Password)
                                {
                                    pass = 1;
                                    break;
                                }
                                else
                                {
                                    pass = 0;
                                }
                            }
                            break;
                        case 3:
                            if (user == admin.User && password == admin.Password)
                            {
                                pass = 1;
                                break;
                            }
                            else
                            {
                                pass = 0;
                            }
                            break;
                    }
                    if (pass == 0)
                    {
                        if (opt == 1)
                        {
                            Console.WriteLine("\nEl usuario no esta registrado en Clientes");
                            Console.Write("Desea registrarse(digite el numero) ? \n1.Si\n2.No\n\n");
                            regis = int.Parse(Console.ReadLine());
                            if (regis == 1) p.Register(clients, employees);
                        }
                        if (opt == 2)
                        {
                            Console.WriteLine("\nEl usuario no esta registrado en Empleados");
                            Console.Write("Desea registrarse(digite el numero) ? \n1.Si\n2.No\n\n");
                            regis = int.Parse(Console.ReadLine());
                            if (regis == 1) p.Register(clients, employees);
                        }
                        if (opt == 3)
                        {
                            Console.WriteLine("\nUsted no es el administrador");
                            Console.ReadKey();
                        }
                    }
                } while (pass == 0);
                //No ingresar
                if (opt == 4) break;
                //Entrar al sistema
                do
                {

                    if (pass == 1)
                    {
                        Console.Clear();
                        switch (opt)
                        {
                            case 1://Cliente
                                Console.WriteLine("              KODIMAX - Cliente\n");
                                Console.WriteLine("Bienvenido, elija una de las opciones(digite el numero)\n");
                                Console.WriteLine("1.Ver cartelera\n2.Ver tienda de golosinas");
                                Console.WriteLine("3.Comprar boletos\n4.Comprar golosinas\n5.Cerrar sesion\n");
                                optmenu = int.Parse(Console.ReadLine());
                                switch (optmenu)
                                {
                                    case 1:
                                        client.SeeMovies(movies);
                                        break;
                                    case 2:
                                        client.SeeCandiesShop(candies);
                                        break;
                                    case 3:
                                        client.BuyTickets(movies, employees, er);
                                        break;
                                    case 4:
                                        client.BuyCandies(candies, employees);
                                        break;
                                    case 5:
                                        exit = 1;
                                        break;
                                }
                                break;
                            case 2://Empleado
                                Console.WriteLine("       KODIMAX - Empleado\n");
                                Console.WriteLine("Bienvenido, elija una de las opciones(digite el numero)\n");
                                Console.WriteLine("1.Modificar cartelera\n2.Modificar tienda de golosinas\n3.Cerrar sesion\n");
                                optmenu = int.Parse(Console.ReadLine());
                                switch (optmenu)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("     KODIMAX - Modificar cartelera\n");
                                        Console.WriteLine("Digite el numero: \n\n1.Agregar pelicula\n2.Eliminar pelicula");
                                        Console.WriteLine("3.Modificar sala de exhibicion\n4.Salir\n");
                                        modify = int.Parse(Console.ReadLine());
                                        switch (modify)
                                        {
                                            case 1:
                                                empl.AddMovie(movies);
                                                break;
                                            case 2:
                                                empl.DeleteMovie(movies);
                                                break;
                                            case 3:
                                                er.ModifyExibitRooms();
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine(" KODIMAX - Modificar tienda de golosinas\n");
                                        Console.WriteLine("Digite el numero: \n\n1.Agregar golosina\n2.Eliminar golosina");
                                        Console.WriteLine("3.Modificar precio y/o tipo\n4.Salir\n");
                                        modify = int.Parse(Console.ReadLine());
                                        switch (modify)
                                        {
                                            case 1:
                                                empl.AddCandy(candies);
                                                break;
                                            case 2:
                                                empl.DeleteCandy(candies);
                                                break;
                                            case 3:
                                                empl.ModifyCandies(candies);
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    case 3:
                                        exit = 1;
                                        break;
                                }
                                break;
                            case 3://Administrador
                                Console.WriteLine("     KODIMAX - Administrador\n");
                                Console.WriteLine("Bienvenido, elija una de las opciones(digite el numero)\n");
                                Console.WriteLine("1.Crear o eliminar empleados\n2.Eliminar usuarios");
                                Console.WriteLine("3.Modificar cartelera\n4.Modificar tienda de golosinas");
                                Console.WriteLine("5.Reportes\n6.Cerrar sesion\n");
                                optmenu = int.Parse(Console.ReadLine());
                                switch (optmenu)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("   KODIMAX - Crear o eliminar empleados\n");
                                        Console.WriteLine("Digite el numero: \n\n1.Agregar empleado\n2.Eliminar empleado\n3.Salir\n");
                                        modify = int.Parse(Console.ReadLine());
                                        switch (modify)
                                        {
                                            case 1:
                                                admin.RegisterEmployee(employees);
                                                break;
                                            case 2:
                                                admin.DeleteEmployee(employees);
                                                break;
                                            case 3:
                                                break;
                                        }
                                        break;
                                    case 2:
                                        admin.DeleteClient(clients);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("  KODIMAX - Modificar cartelera\n");
                                        Console.WriteLine("Digite el numero: \n\n1.Agregar pelicula\n2.Eliminar pelicula");
                                        Console.WriteLine("3.Modificar sala de exhibicion\n4.Salir\n");
                                        modify = int.Parse(Console.ReadLine());
                                        switch (modify)
                                        {
                                            case 1:
                                                admin.AddMovie(movies);
                                                break;
                                            case 2:
                                                admin.DeleteMovie(movies);
                                                break;
                                            case 3:
                                                er.ModifyExibitRooms();
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine(" KODIMAX - Modificar tienda de golosinas\n");
                                        Console.WriteLine("Digite el numero: \n\n1.Agregar golosina\n2.Eliminar golosina");
                                        Console.WriteLine("3.Modificar precio y/o tipo\n4.Salir\n");
                                        modify = int.Parse(Console.ReadLine());
                                        switch (modify)
                                        {
                                            case 1:
                                                admin.AddCandy(candies);
                                                break;
                                            case 2:
                                                admin.DeleteCandy(candies);
                                                break;
                                            case 3:
                                                admin.ModifyCandies(candies);
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine("\tKODIMAX - Reportes\n");
                                        Console.WriteLine("Digite la letra: \n\nU - Lista de todos los usuarios");
                                        Console.WriteLine("C - Lista de peliculas\nG - Lista de golosinas\n");
                                        selectRep = char.Parse(Console.ReadLine());
                                        switch (selectRep)
                                        {
                                            case 'u':
                                            case 'U':
                                                reps.UsersReport(clients, employees);
                                                break;
                                            case 'C':
                                            case 'c':
                                                reps.MoviesReport(movies);
                                                break;
                                            case 'G':
                                            case 'g':
                                                reps.CandiesReport(candies);
                                                break;
                                            
                                        }
                                        break;
                                    case 6:
                                        exit = 1;
                                        break;
                                }
                                break;
                        }
                        if (exit == 1) break;
                        Console.Write("\nPresione enter...");
                        Console.ReadKey();
                    }
                } while (again == 1);
            } while (exit == 1);
        }
    }
}