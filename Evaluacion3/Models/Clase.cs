namespace Evaluacion3.Models
{
    public class Clase //Camion, camioneta, auto, moto, etc
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descripcion { get; set; }


        //Prop Navegacion
        public List<caracteristicas>? Caracteristicas { get; set; }
    }
}