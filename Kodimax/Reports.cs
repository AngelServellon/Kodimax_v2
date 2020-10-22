using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Reports
    {
        private string clientsJson;
        private string employeesJson;
        private string moviesJson;
        private string candiesJson;
        private string salesJson;

        //Generar reporte de usuarios
        public void UsersReport(List<People> clients, List<Employee> employees)
        {
            clientsJson = JsonConvert.SerializeObject(clients.ToArray());
            employeesJson = JsonConvert.SerializeObject(employees.ToArray());
            System.IO.File.WriteAllText(@"C:\json\Clients.json", clientsJson);
            System.IO.File.WriteAllText(@"C:\json\Employees.json", employeesJson);
            Console.Clear();
            Console.WriteLine(" KODIMAX - Generar reportes de usuarios\n");
            Console.WriteLine("Reporte de usuarios generado exitosamente\n");
        }
        //Generar reporte de peliculas
        public void MoviesReport(List<Movie> movies)
        {
            moviesJson = JsonConvert.SerializeObject(movies.ToArray());
            System.IO.File.WriteAllText(@"C:\json\Movies.json", moviesJson);
            Console.Clear();
            Console.WriteLine(" KODIMAX - Generar reportes de peliculas\n");
            Console.WriteLine("Reporte de peliculas generado exitosamente\n");
        }
        //Generar reporte de peliculas
        public void CandiesReport(List<Candy> candies)
        {
            candiesJson = JsonConvert.SerializeObject(candies.ToArray());
            System.IO.File.WriteAllText(@"C:\json\Candies.json", candiesJson);
            Console.Clear();
            Console.WriteLine(" KODIMAX - Generar reportes de golosinas\n");
            Console.WriteLine("Reporte de golosinas generado exitosamente\n");
        }
        //Generar reporte de ventas
        public void SalesReport(List<Sales> sales)
        {
            salesJson = JsonConvert.SerializeObject(sales.ToArray());
            System.IO.File.WriteAllText(@"C:\json\Sales.json", salesJson);
            Console.Clear();
            Console.WriteLine(" KODIMAX - Generar reporte de ventas por sucursal\n");
            Console.WriteLine("Reporte de ventas generado exitosamente");
        }
    }
}
