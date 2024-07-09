// See https://aka.ms/new-console-template for more information

using EspacioCalculadora;
using GestionDeTareas;

Console.WriteLine("-----------Ejercicio 1-----------");

GestorDeTareas GestorTareas = new GestorDeTareas();
List<Tareas> ListaTareasPendientes = new List<Tareas>();
List<Tareas> ListaTareasRealizadas = new List<Tareas>();
string op;
int operacion;
do{
    do
    {
        Console.WriteLine("\nIndique que tarea desea realizar: \n1.Agregar Tareas\n2.Mostrar Lista de tareas pendientes\n3.Mostrar Lista de tareas realizadas\n4.Tranferir tarea de pendientes a realizado\n5.Buscar tarea por palabra clave\n6.Finalizar");
        op = Console.ReadLine();
        
    } while (!int.TryParse(op, out operacion));

    switch (operacion)
    {
    case 1:
            Console.WriteLine("\nIndique la cantidad de tareas que desea ingresar");
            int cantidad;
            string ingresa;
            do
            {
                ingresa = Console.ReadLine();
                if(!int.TryParse(ingresa, out cantidad))
                {
                    Console.WriteLine("\nNo ha ingresado una cantidad valida");
                }
            } while (!int.TryParse(ingresa, out cantidad));
            ListaTareasPendientes = GestorTareas.crearNTareas(cantidad);
           break;
    case 2:
            int j = 0;
            Console.WriteLine("\nTareas pendientes");
            foreach (Tareas tarea in ListaTareasPendientes)
            {
                j++;
                Console.WriteLine($"\nTarea {j}");
                Console.WriteLine($"\nID: {tarea.TareaID}");
                Console.WriteLine($"\nDescripcion: {tarea.Descripcion}");
                Console.WriteLine($"\nDuracion: {tarea.Duracion}");
            }
            break;
    case 3:
            int k = 0;
            foreach (Tareas tarea in ListaTareasRealizadas)
            {
                k++;
                Console.WriteLine($"\nTarea {k}");
                Console.WriteLine($"\nID: {tarea.TareaID}");
                Console.WriteLine($"\nDescripcion: {tarea.Descripcion}");
                Console.WriteLine($"\nDuracion: {tarea.Duracion}");
            }
            break;
    case 4:
            string id;
            int Id;
            do
            {
                
                Console.WriteLine("\nIngrese el id de la tarea que desea marcar como realizado y transferirlo a la lista correspondiente: ");
                id = Console.ReadLine();
            } while (!int.TryParse(id, out Id));

            GestorTareas.TranferirTareaRealizadaporId(ListaTareasPendientes,ListaTareasRealizadas,Id);
            break;
    case 5:
            Console.WriteLine("\nIngrese la descripcion de la tarea que desea buscar");
            string descripcion = Console.ReadLine();
            Tareas TareaBuscada = GestorTareas.BuscarTareaPorDescripcion(ListaTareasPendientes,descripcion);
            if(TareaBuscada != null)
            {
                Console.WriteLine("\nLa tarea buscada es: ");
                Console.WriteLine($"\nID: {TareaBuscada.TareaID}");
                Console.WriteLine($"\nDescripcion: {TareaBuscada.Descripcion}");
                Console.WriteLine($"\nDuracion: {TareaBuscada.Duracion}");
            }else
            {
                Console.WriteLine("\nLa descripcion ingresada no se corresponde con ninguna tarea");
            }
            break;
    }
}while(operacion!=6);



Console.WriteLine("-----------Ejercicio 2-----------");

Calculadora miCalculadora = new Calculadora();

int control;


do
{
    Console.WriteLine("\n--------Calculadora--------\n");
    Console.WriteLine("\n1.SUMA");
    Console.WriteLine("\n2.RESTA");
    Console.WriteLine("\n3.MULTIPLICACION");
    Console.WriteLine("\n4.DIVISION");
    Console.WriteLine("\n5.LIMPIAR");
    Console.WriteLine("\n6.MOSTRAR HISTORIAL");
    Console.WriteLine("\nElija la operacion que desea realizar: ");
    string eleccion = Console.ReadLine(); 
    int operacion2;
    double numero = 0;
    if(int.TryParse(eleccion, out operacion2))
    {
        if (operacion2 != 5 && operacion2 != 6)
        {
            string n;
            do{
                Console.WriteLine("\nIngrese el numero: ");
                n = Console.ReadLine(); 
            }while (!double.TryParse(n, out numero));
            
        }
        switch (operacion2)
        {
            case 1:
                    miCalculadora.Sumar(numero);
                    Console.WriteLine("\nLa suma de los numeros es " + miCalculadora.Resultado);
                    break;
            case 2:
                    miCalculadora.Restar(numero);
                    Console.WriteLine("\nLa diferencia de los numeros es " + miCalculadora.Resultado);
                    break;

            case 3:
                    miCalculadora.Multiplicar(numero);
                    Console.WriteLine("\nEl producto de los numeros es " + miCalculadora.Resultado);
                    break;
            case 4:
                    miCalculadora.Dividir(numero);
                    Console.WriteLine("\nEl cociente de los numeros es " + miCalculadora.Resultado);
                    break;
            case 5:
                    miCalculadora.Limpiar();
                    Console.WriteLine("\nEl dato vacio es: ", miCalculadora.Resultado);
                    break;
            case 6:
                    int k = 1;
                    foreach (Calculadora.Operacion ope in miCalculadora.Historial)
                    {
                        Console.WriteLine($"\nOperacion {k}");
                        Console.WriteLine($"\nDato de entrada: {ope.Resultado}");
                        Console.WriteLine($"\nOperacion: {ope.OperacionRealizada}");
                        Console.WriteLine($"\nResultado: {ope.NuevoValor}");
                        k++;
                    }
                    break;

        }
    }
    Console.WriteLine("\nIngrese 1 si desea continuar operando. Caso contrario ingrese 0");
    string controla = Console.ReadLine();
    if(!int.TryParse(controla, out control))
    {
      control = 1;
    }
    
} while (control != 0);