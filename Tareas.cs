namespace GestionDeTareas
{
    class GestorDeTareas
    {
       public List<Tareas> crearNTareas(int n)
       {
            List<Tareas> listaTareas = new List<Tareas>();
            var semilla = Environment.TickCount;
            var random = new Random(semilla); 
            for (int i = 0; i < n; i++)
            {

                int duracion = random.Next(10,101); 
                Console.WriteLine($"\nIngrese la descripcion de la tarea {i+1}");
                string descripcion = Console.ReadLine();
                Tareas tarea = new Tareas(i,descripcion,duracion);
                listaTareas.Add(tarea);
            }
            return listaTareas;
       }
       public void TranferirTareaRealizadaporId(List<Tareas> Pendientes, List<Tareas> Realizados, int id)
       {
           int i = 0;
           while (i < Pendientes.Count && Pendientes[i].TareaID != id)
           {
               i++;
           }
           Tareas TareaATransferir = Pendientes[i];
           TareaATransferir.MarcarRealizado();
           Realizados.Add(TareaATransferir);
           Pendientes.Remove(TareaATransferir);
       }

       public Tareas BuscarTareaPorDescripcion(List<Tareas> Pendientes, string descripcion)
       {
          Tareas TareaBuscada = null;
          foreach (Tareas tarea in Pendientes)
          {
            if(tarea.Descripcion == descripcion)
            {
                TareaBuscada = tarea;
            }
          }
          return TareaBuscada;
       }
    }

    partial class Tareas
    {
        private int tareaID;
        private string descripcion;
        private int duracion;

        EstadoTarea estado;
        public int TareaID{ get => tareaID; set => tareaID = value; }
        public string Descripcion{ get => descripcion; set => descripcion = value; }
        public int Duracion{ get => duracion; set => duracion = value; }

        public EstadoTarea EstadoTarea{ get => estado; set => estado = value; }
        public Tareas(int id, string description, int duracion)
        {
            TareaID = id;
            Descripcion = description;
            Duracion = duracion;
        }
        
        public void MarcarRealizado()
        {
            EstadoTarea = EstadoTarea.Realizado;
        }
    
   }
}