namespace DreamBasses.Models;

public class DetailsVM
{
    public Baixo Anterior { get; set; }
    public Baixo Atual { get; set; }
    public Baixo Proximo { get; set; }
    public List<Baixo> Basses{ get; set;}
    
}
