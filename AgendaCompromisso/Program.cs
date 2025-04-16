using ConsoleApp.Modelos;

class Program
{
    static void Main()
    {
        try
        {
            var compromisso = new Compromisso();
            compromisso.Data = "15/10/2023"; // Data válida
            compromisso.Hora = new TimeSpan(14, 30, 0); // Hora válida
            Console.WriteLine("Compromisso criado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}