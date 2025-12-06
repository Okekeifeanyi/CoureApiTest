public class CountryLookupResponseDto
{
    public string Number { get; set; } = string.Empty;
    public CountryDto Country { get; set; } = new();
}

public class CountryDto
{
    public string CountryCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string CountryIso { get; set; } = string.Empty;
    public List<OperatorDto> CountryDetails { get; set; } = new();
}

public class OperatorDto
{
    public string Operator { get; set; } = string.Empty;
    public string OperatorCode { get; set; } = string.Empty;
}
