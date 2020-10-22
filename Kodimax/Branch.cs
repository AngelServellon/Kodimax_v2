using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Branch()
        {

        }
        public Branch(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        //Agregar sucursal
        public void AddBranch(List<Branch> branches, int count2)
        {
            Branch branch = new Branch();
            branch.Id = count2;
            Console.Clear();
            Console.WriteLine("     KODIMAX - Agregar sucursal\n");
            Console.Write("Nombre: ");
            branch.Name = Console.ReadLine();
            Console.Write("Precio: ");
            branch.Price = decimal.Parse(Console.ReadLine());
            branches.Add(branch);
            Console.WriteLine("\nSucursal agregada exitosamente");
        }
        //Verificar Id de sucursal
        private int VerifyBranchId(List<Branch> branches)
        {
            int id, index = 0, pass = 0;
            do
            {
                Console.Write("\nIngrese el Id de la sucursal: ");
                id = int.Parse(Console.ReadLine());
                for (int i = 0; i < branches.Count; i++)
                {
                    if (id == branches[i].Id)
                    {
                        index = i;
                        pass = 1;
                        break;
                    }
                    else
                    {
                        pass = 0;
                    }
                }
                if (pass == 0) Console.WriteLine("\nEl id es incorrecto, ingeselo de nuevo");
            } while (pass == 0);
            return index;
        }
        public void ModifyBranch(List<Branch> branches)
        {
            int index, opt;
            Console.Clear();
            Console.WriteLine("     KODIMAX - Modificar sucursal");
            index = VerifyBranchId(branches);//Obtener index de la sucursal
            Console.WriteLine("\nSucursal: {0}", branches[index].Name);
            Console.WriteLine("\nDesea cambiar el nombre de la sucursal (digite el numero)?");
            Console.WriteLine("1.Si\n2.No\n");
            opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                Console.Write("\nNombre: ");
                branches[index].Name = Console.ReadLine();
            }
            Console.WriteLine("\nDesea cambiar el precio de la sucursal (digite el numero)?");
            Console.WriteLine("1.Si\n2.No\n");
            opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                Console.Write("\nPrecio: ");
                branches[index].Price = decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine("\nSucursal modificada exitosamente.");
        }
    }
}
