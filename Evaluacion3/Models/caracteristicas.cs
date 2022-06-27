using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluacion3.Models
{
    public class caracteristicas
    { 
  public int Id { get; set; }

    [DisplayName("Nombre")]
    public string? Descripcion { get; set; }

    [DisplayName("Descripcion Larga")]
    public string? DescripcionLarga { get; set; }
    public string? Motor { get; set; }
    public string? Traccion { get; set; }
    public string? Cambios { get; set; }
    public string? Combustible { get; set; }
    public string color { get; set; }
    public string año { get; set; }

        [DisplayName("iMAGEN VEHICULO")]
        public string? Inaño { get; set; }
        public string? ImagenUrl { get; set; }


        [NotMapped]
    public IFormFile? ImagenFile { get; set; }

    //Foreign Keys
    public int marcaId { get; set; }
    public marca? marca { get; set; }

    public int TipoId { get; set; }
    public Tipo? Tipo { get; set; }
    public int ClaseId { get; set; }
    public Clase? Clase { get; set; }

        public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

}
}