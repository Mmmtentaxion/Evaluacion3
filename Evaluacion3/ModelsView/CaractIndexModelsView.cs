using Evaluacion3.Models;

namespace Evaluacion3.ModelsView
{
    public class CaractIndexModelsView
    {
        public List<caracteristicas>? caracteristicas;

        public string? PalabraClave { get; set; }
        public int? MarcaId { get; set; }
        public int? TipoId { get; set; }
        public int? CategoriaId { get; set; }
        public int? ClaseId { get; set; }

    }
}