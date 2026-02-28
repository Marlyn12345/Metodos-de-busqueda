using System;
using System.Linq;

namespace Metodos_de_busqueda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("    PROGRAMA DE BÚSQUEDA     ");

           
            Console.Write("¿Cuántos números tendrá el arreglo?: ");
            int n = int.Parse(Console.ReadLine());
            int[] numeros = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ingrese el número en la posición [{i}]: ");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            
            Console.Write("\n¿Qué número deseas buscar?: ");
            int objetivo = int.Parse(Console.ReadLine());

            
            Console.WriteLine("\nElija el método:");
            Console.WriteLine("1. Búsqueda Lineal ");
            Console.WriteLine("2. Búsqueda Binaria ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                int resultado = BusquedaLineal(numeros, objetivo);
                MostrarResultado(resultado);
            }
            else if (opcion == "2")
            {
                Array.Sort(numeros); 
                Console.WriteLine("Lista ordenada para búsqueda binaria: " + string.Join(", ", numeros));
                int resultado = BusquedaBinaria(numeros, objetivo);
                MostrarResultado(resultado);
            }
        }

        static void MostrarResultado(int res)
        {
            if (res != -1) Console.WriteLine($"\n¡Éxito! Número encontrado en el índice: {res}");
            else Console.WriteLine("\nEl número no se encuentra en la lista.");
            Console.WriteLine("Presione cualquier tecla para terminar...");
            Console.ReadKey();
        }

        static int BusquedaLineal(int[] arr, int t)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == t) return i;
            return -1;
        }

        static int BusquedaBinaria(int[] arr, int t)
        {
            int izq = 0, der = arr.Length - 1;
            while (izq <= der)
            {
                int med = izq + (der - izq) / 2;
                if (arr[med] == t) return med;
                if (arr[med] < t) izq = med + 1;
                else der = med - 1;
            }
            return -1;
        }
    }
}