namespace CalculadoraTests;
using Calculadora;

public class CalculadoraTests
{
    private readonly Calculadora _calculadora;

    public CalculadoraTests()
    {
        _calculadora = new Calculadora();
    }

    [Fact]
    public void Somar_DoisNumerosInteiros_RetornaNumeroInteiro()
    {
        // Arrange
        int a = 5;
        int b = 5;

        // Act
        int resultado = _calculadora.Somar(a, b);

        // Assert
        Assert.Equal(10, resultado);
    }

    [Fact]
    public void Subtrair_DoisNumerosInteiros_RetornaNumeroInteiro()
    {
        // Arrange
        int a = 5;
        int b = 5;

        // Act
        int resultado = _calculadora.Subtrair(a, b);

        // Assert
        Assert.Equal(0, resultado);
    }

    [Fact]
    public void Multiplicar_DoisNumerosInteiros_RetornaNumeroInteiro()
    {
        // Arrange
        int a = 5;
        int b = 5;

        // Act
        int resultado = _calculadora.Multiplicar(a, b);

        // Assert
        Assert.Equal(25, resultado);
    }

    [Fact]
    public void Dividir_DoisNumerosInteiros_RetornaNumeroInteiro()
    {
        // Arrange
        int a = 5;
        int b = 5;

        // Act
        int resultado = _calculadora.Dividir(a, b);

        // Assert
        Assert.Equal(1, resultado);
    }

    [Fact]
    public void Dividir_NumeroInteiroPorZero_RetornaDivideByZeroException()
    {
        // Arrange
        int a = 5;
        int b = 0;

        // Assert
        Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(a, b));
    }

    [Fact]
    public void AdicionarHistorico_UmaOperacaoDaClasse_HistoricoNaoPodeSerVazio()
    {
        // Arrange
        Calculadora calculadora = new Calculadora();
        int a = 5;
        int b = 5;

        // Act
        calculadora.Somar(a, b);

        // Assert
        Assert.NotEmpty(calculadora.Historico());
    }

    [Fact]
    public void AdicionarHistorico_QuatroOperacaoDaClasse_HistoricoDeveConterApenas3Operacoes()
    {
        // Arrange
        Calculadora calculadora = new Calculadora();
        int a = 5;
        int b = 5;

        // Act
        calculadora.Somar(a, b);
        calculadora.Subtrair(a, b);
        calculadora.Multiplicar(a, b);
        calculadora.Dividir(a, b);

        // Assert
        Assert.Equal(3, calculadora.Historico().Count);
        Assert.Collection(calculadora.Historico(),
            item => Assert.DoesNotContain(nameof(calculadora.Somar), item),
            item => Assert.DoesNotContain(nameof(calculadora.Somar), item),
            item => Assert.DoesNotContain(nameof(calculadora.Somar), item));
        Assert.Collection(calculadora.Historico(),
            item => Assert.Contains(nameof(calculadora.Subtrair), item),
            item => Assert.Contains(nameof(calculadora.Multiplicar), item),
            item => Assert.Contains(nameof(calculadora.Dividir), item));
    }
}