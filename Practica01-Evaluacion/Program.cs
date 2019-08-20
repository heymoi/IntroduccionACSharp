// TODO: Agregue el espacio de nombre System

namespace Examen1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Declare la variable opcion de tipo entero
            int opcion = 0;
            double area = 0;
             //variable para almacenar el area de las figuras
	    double radio = 0;

            //TODO: Declare las variables requeridas para encontrar el area de un rectangulo

            //TODO: Declare las variables requeridas para encontrar el area de un cuadrado

            string caso = "";
            Console.WriteLine("======Bienvenido a Calculadora de Areas Geometricas======");
            Console.WriteLine();
            Console.WriteLine();
            //TODO: Imprima el menu 1. Área de un circulo, 2. Área de un rectangulo y 3. Área de un cuadrado

            //TODO: Asigne el valor ingresado por el usuario a la variable opcion.
            
            switch (opcion) {
                case 1:
                {
                    caso = "Circulo";
                    Console.Clear();
                    Console.WriteLine("Ingrese el valor del radio");
                    radio = Double.Parse(Console.ReadLine());
                    //TODO: Aplique la formula area = Pi Por Radio Cuadrado.
                    //Para PI existe una propiedad en la clase Math
                    //Para la raiz cuadrada existe un metodo en la clase Math
                    break;
                }
                //TODO: Agregue el caso para el area de un rectangulo


                //TODO: Agregue el caso para el area de un cuadrado


                //TODO: Agregue el caso para cualquier otro numero.  Use System.Environment.Exit(0); para terminar la aplicacion
            }
            Console.WriteLine("El area del " + caso + " = " + area);
	    //TODO: Agregue una linea para haga una pausa y deje mostrar el resultado.
        }
    }
}
