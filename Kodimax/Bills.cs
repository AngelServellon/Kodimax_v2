using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    public class Bills
    {
        private List<CandiesAmount> _candcount = new List<CandiesAmount>();
        private string movieName, exhibRoom;
    	private int tickAmount, available;
    	private decimal ticketPrice, movieTotal, movieDisc, movieFinalTotal;//atributos para TicketBill
    	private decimal candTotal= 0, candDisc, candFinalTotal;//atributos para CandiesBill
    	private decimal pStan= 3.55m, pPrem= 4.75m, pVip= 6.50m;//precio de las salas

        //Pagar
        private void Payment(decimal FinalTotal)
        {
            decimal change, pay;
            int again;
            FinalTotal = decimal.Round(FinalTotal, 2);
            Console.WriteLine("\nTOTAL A PAGAR: ${0}", FinalTotal);
            do
            {
                again = 0;
                Console.Write("\nPAGO: ");
                pay = decimal.Parse(Console.ReadLine());
                change = pay - FinalTotal;//Sacar el cambio

                if (pay == FinalTotal)
                {
                    Console.WriteLine("\nCobro exacto, gracias por comprar en KODIMAX");
                    Console.ReadKey();
                }
                else if (pay < FinalTotal)
                {
                    Console.WriteLine("\nPago insuficiente");
                    again = 1;
                }
                else if (pay > FinalTotal)
                {
                    Console.WriteLine("\nSu cambio es ${0:0.00}, gracias por comprar en KODIMAX", change);
                    Console.ReadKey();
                }
            } while (again == 1);
        }
        private void TicketsBill(List<Employee> empl)
        {
            Random rdn = new Random();
            int amount = empl.Count;
            int random = rdn.Next(0, amount);
            Employee empleado = new Employee();
            empleado = empl[random];

            Console.Clear();
            Console.WriteLine("              KODIMAX\n");
            Console.WriteLine("Empleado/a: {0}      Id: {1}\n", empleado.Names, empleado.Id);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("\nSALA: {0}", exhibRoom.ToUpper());
            Console.WriteLine("\n{0} x ${1:0.00}", tickAmount, ticketPrice);
            Console.WriteLine("{0}               ${1:0.00}", movieName, movieTotal);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Subtotal                    ${0:0.00}", movieTotal);
            Console.WriteLine("Impuesto                    ${0:0.00}", movieDisc);
            Console.WriteLine("\nTOTAL                       ${0:0.00}", movieFinalTotal);

        }
        //Comprar boletos
        public void BuyTickets(List<Movie> movies, List<Employee> empl, ExhibitionRoom er)
        {
            int id, pass = 0, index = 0;
            int opt = 0;
            Console.Clear();
            Console.WriteLine("        KODIMAX - Comprar boletos");
            //Verificar que el codigo sea correcto
            do
            {
                Console.Write("\nIngrese el Id de la pelicula que desea ver: ");
                id = int.Parse(Console.ReadLine());
                for (int i = 0; i < movies.Count; i++)
                {
                    if (id == movies[i].Id)
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
            //Poner los datos de la pelicula
            movieName = movies[index].Name;
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("\n    {0}\n", movies[index].Name);
            Console.WriteLine("Id: {0}", movies[index].Id);
            Console.WriteLine("Duracion: {0}", movies[index].Duration);
            Console.WriteLine("Tipo de pelicula: {0}\n", movies[index].Type);
            Console.WriteLine("---------------------------------------------\n");
            //Pedir los datos		
            Console.WriteLine("Elija la sala de exhibicion (digite el numero)\n");
            Console.WriteLine("1.{0} - $3.55", er.nStan);
            Console.WriteLine("2.{0} - $4.75", er.nPrem);
            Console.WriteLine("3.{0} - $6.50\n", er.nVip);
            opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                exhibRoom = er.nStan;
                ticketPrice = pStan;
                available = er.saStan;
            }
            else if (opt == 2)
            {
                exhibRoom = er.nPrem;
                ticketPrice = pPrem;
                available = er.saPrem;
            }
            else if (opt == 3)
            {
                exhibRoom = er.nVip;
                ticketPrice = pVip;
                available = er.saVip;
            }
            //Compra de boletos
            do
            {
                Console.Write("\nIngrese la cantidad de boletos que comprara: ");
                tickAmount = int.Parse(Console.ReadLine());
                if (tickAmount > available)
                {
                    Console.WriteLine("\nSolo hay {0} espacios disponibles", available);
                    Console.WriteLine("Ingrese una cantidad menor o igual a esa");
                    pass = 0;
                }
                else
                {
                    if (opt == 1) er.saStan -= tickAmount;
                    else if (opt == 2) er.saPrem -= tickAmount;
                    else if (opt == 3) er.saVip -= tickAmount;
                    pass = 1;
                }
            } while (pass == 0);
            //Calcular el total
            if (opt == 1) movieTotal = tickAmount * ticketPrice;
            else if (opt == 2) movieTotal = tickAmount * ticketPrice;
            else if (opt == 3) movieTotal = tickAmount * ticketPrice;

            movieDisc = movieTotal * 0.3533m;
            movieFinalTotal = movieTotal + movieDisc;
            //Pagar
            Payment(movieFinalTotal);
            //Mostrar el ticket
            TicketsBill(empl);
        }
        //Mostrar factuta de golosinas compradas
        private void CandiesBill(List<Employee> empl)
        {
            Random rdn = new Random();
            int amount = empl.Count;
            int random = rdn.Next(0, amount);
            Employee empleado = new Employee();
            empleado = empl[random];

            Console.Clear();
            Console.WriteLine("              KODIMAX\n");
            Console.WriteLine("Empleado/a: {0}      Id: {1}\n", empleado.Names, empleado.Id);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();
            foreach (CandiesAmount ca in _candcount)
            {
                Console.WriteLine("{0} x ${1:0.00}", ca.Amount, ca.Price);
                Console.WriteLine("{0}              ${1:0.00}", ca.Name, ca.Total);
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Subtotal                    ${0:0.00}", candTotal);
            Console.WriteLine("Impuesto                    ${0:0.00}", candDisc);
            Console.WriteLine("\nTOTAL                       ${0:0.00}", candFinalTotal);

        }
        //Comprar golosinas
        public void BuyCandies(List<Candy> candies, List<Employee> empl)
        {
            int id, pass = 0, index = 0, amount;
            int again;

            Console.Clear();
            Console.WriteLine("        KODIMAX - Comprar golosinas");
            do
            {
                //Verificar que el codigo sea correcto
                do
                {
                    Console.Write("\nIngrese el Id de la golosina que desea comprar: ");
                    id = int.Parse(Console.ReadLine());
                    for (int i = 0; i < candies.Count; i++)
                    {
                        if (id == candies[i].Id)
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
                CandiesAmount cands = new CandiesAmount();
                Console.Write("\nIngrese la cantidad a comprar: ");
                amount = int.Parse(Console.ReadLine());
                //Ingresar las compras en la lista
                cands.Name = candies[index].Name;
                cands.Price = candies[index].Price;
                cands.Amount = amount;
                cands.Total = amount * candies[index].Price;//Ir sacando el subtotal
                                                            //Calcular el subtotal	
                candTotal += cands.Total;
                _candcount.Add(cands);

                Console.WriteLine("\nDesea agregar mas golosinas (digite el numero)?\n1.Si\n2.No\n");
                again = int.Parse(Console.ReadLine());
            } while (again == 1);
            candDisc = candTotal * 0.0453m;
            candFinalTotal = candTotal + candDisc;
            //Pagar
            Payment(candFinalTotal);
            //Mostrar el ticket
            CandiesBill(empl);
        }
    }
}
