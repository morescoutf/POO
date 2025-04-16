namespace ConsoleApp.Modelos;

public class Compromisso
{
    private DateTime _data;
    private TimeSpan _hora; // Backing field para a propriedade Hora

    public string Data
    {
        get { return _data.ToString("dd/MM/yyyy"); }
        set
        {
            _validarDataInformada(value);
            _validarDataValidaParaCompromisso();
        }
    }

    // Propriedade Hora com validação
    public TimeSpan Hora
    {
        get { return _hora; }
        set
        {
            if (value.Days != 0 || value.Hours < 0 || value.Hours >= 24 || value.Minutes < 0 || value.Minutes >= 60)
            {
                throw new ArgumentException($"Horário inválido: {value}. A hora deve estar entre 00:00 e 23:59, com minutos de 00 a 59.");
            }
            _hora = value;
        }
    }

    public string Descricao { get; set; }
    public string Local { get; set; }

    private void _validarDataInformada(string data)
    {
        if (!DateTime.TryParseExact(data,
                       "dd/MM/yyyy",
                       System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                       System.Globalization.DateTimeStyles.None,
                       out _data))
        {
            throw new Exception($"Data {data} inválida!");
        }
    }

    private void _validarDataValidaParaCompromisso()
    {
        if (_data <= DateTime.Now)
        {
            throw new Exception($"Data {_data.ToString("dd/MM/yyyy")} é inferior à permitida.");
        }
    }
}