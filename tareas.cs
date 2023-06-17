namespace ListaDeTareas;

public class Tarea
{
    private int TareaID;
    private string? Descripcion;
    private int Duracion;

    public int ID { get => TareaID; set {TareaID = value;} }
    public string Desc { get => Descripcion; set {Descripcion = value;} }
    public int Dura { get => Duracion; set {Duracion = value;} }
}