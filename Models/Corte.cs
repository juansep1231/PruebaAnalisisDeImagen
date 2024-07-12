namespace PruebaAnalisisDeImagen.Models
{
    public class Corte
    {
        public int CorteId { get; set; }
        public List<string> Horarios { get; set; }

        // Constructor que acepta una lista de horarios
        public Corte(int corteId, List<string> horarios)
        {
            CorteId = corteId;
            Horarios = horarios;
        }

        // Método para imprimir todos los horarios
        public void ImprimirHorarios()
        {
            Console.WriteLine($"Horarios del corte {CorteId}:");
            foreach (var horario in Horarios)
            {
                Console.WriteLine(horario);
            }
        }

    }
}
