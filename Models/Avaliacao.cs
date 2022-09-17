
namespace pifinal.Models;

public class Avaliacao
{
    public string data { get; set; }

    public Disciplina? disciplina { get; set; }

    public int avaliacao { get; set; }
    
    public string observacao { get; set; } 

    public int disciplina_id { get; set; } 

}