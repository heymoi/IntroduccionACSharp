using System;


namespace TiendaInformatica
{
    class Program
    {

        static void Main(string[] args)
        {
            DateTime fechaAhora = DateTime.Now;
            // Console.WriteLine(hoy.Month);

            string producto = "", cupon = "";
            double precio = 0, totalNeto = 0, totalPagar = 0, descuento = 0;
            System.Int32 cantidad = 0, tipoProducto = 0, porcDesc = 0;

            Menu();


            Console.WriteLine("Tipo de producto a comprar: ");
            tipoProducto = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Producto: ");
            producto = Console.ReadLine();

            Console.WriteLine("Precio: $");
            precio = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Cantidad: ");
            cantidad = Convert.ToInt32(Console.ReadLine());

            totalNeto = cantidad * precio;


            porcDesc = VerificarDescuentoPorTipoProducto(tipoProducto);

            descuento = totalNeto * porcDesc / 100;

            Console.WriteLine("Ingrese el cupon de descuento");
            cupon = Console.ReadLine();

            descuento = descuento + ValidarCuponDescuento(cupon, totalNeto);

            if (fechaAhora.Month == 8)
            {
                totalPagar = totalNeto - descuento;
            }

            Facturacion(totalNeto, descuento, totalPagar);


        }

        static void Menu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1-Computadoras");
            Console.WriteLine("2-Laptop");
            Console.WriteLine("3-Telefonos");
        }

        static void Facturacion(double totalNeto, double descuento, double totalPagar)
        {
            Console.WriteLine("Total a Neto ${0}", totalNeto);
            Console.WriteLine("Descuento ${0}", descuento);
            Console.WriteLine("Total a Pagar $" + totalPagar);
            Console.ReadLine();
        }

        static double ValidarCuponDescuento(string cupon, double totalNeto)
        {
            double descuento = 0;
            if (cupon == "ITCA2020")
            {
                descuento = totalNeto * 0.1;
            }
            return descuento;
        }

        static int VerificarDescuentoPorTipoProducto(int tipoProducto)
        {
            int porcDesc = 0;
            switch (tipoProducto)
            {
                case 1:
                    porcDesc = 20;
                    break;
                case 2:
                    porcDesc = 15;
                    break;
                case 3:
                    porcDesc = 10;
                    break;
                default:
                    porcDesc = 0;
                    break;
            }
            return porcDesc;
        }

    }
}



