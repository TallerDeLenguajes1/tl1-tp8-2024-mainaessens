namespace EspacioCalculadora
{
    public class Calculadora
    {
        double dato;
        public double Resultado{get=>dato;}

        List<Operacion>historial;

        public List<Operacion> Historial{get=>historial;set => historial = value;}
        public void Sumar(double termino)
        {
           double anterior = dato;
           dato += termino;
           TipoOperacion operacion = TipoOperacion.Suma;
           Operacion op = new Operacion(anterior, dato, operacion);
            if(Historial == null)
            {
                Historial = new List<Operacion>();

            }
            Historial.Add(op);

        }
        public void Restar(double termino)
        {
            double anterior = dato;
            dato -= termino;
            TipoOperacion operacion = TipoOperacion.Resta;
            Operacion op = new Operacion(anterior, dato, operacion);
            if(Historial == null)
            {
                Historial = new List<Operacion>();

            }
            Historial.Add(op);
        }
        public void Multiplicar(double termino)
        {
            double anterior = dato;
            dato *= termino;
            TipoOperacion operacion = TipoOperacion.Multiplicacion;
            Operacion op = new Operacion(anterior, dato, operacion);
            if(Historial == null)
            {
                Historial = new List<Operacion>();

            }
            Historial.Add(op);
        }
        public void Dividir(double termino)
        {
            if(termino != 0)
            {
                double anterior = dato;
                dato /= termino;
                TipoOperacion operacion = TipoOperacion.Division;
                Operacion op = new Operacion(anterior, dato, operacion);
                if(Historial == null)
                {
                    Historial = new List<Operacion>();

                }
            Historial.Add(op);
            }else
            {
                Console.WriteLine("Error! Division en 0");
            }
        }
        public void Limpiar()
        {
            double anterior = dato;
            dato = 0;
            TipoOperacion operacion = TipoOperacion.Limpiar;
            Operacion op = new Operacion(anterior, dato, operacion);
            if(Historial == null)
            {
                Historial = new List<Operacion>();

            }
            Historial.Add(op);
        }

        public enum TipoOperacion
        {
            Suma,
            Resta,
            Multiplicacion,
            Division,
            Limpiar
        }

        public class Operacion
        {
            private double resultadoAnterior;
            private double nuevoValor;

            private TipoOperacion operacion;

            public double Resultado{get=>resultadoAnterior; set => resultadoAnterior = value;}
            public double NuevoValor{get=>nuevoValor; set=> nuevoValor = value;}
            public TipoOperacion OperacionRealizada { get => operacion; set => operacion = value; }

            public Operacion(double anterior, double resultadoNuevo, TipoOperacion operacion)
            {
                Resultado = anterior;
                NuevoValor = resultadoNuevo;
                OperacionRealizada = operacion;
            }

        }
    }
    
}