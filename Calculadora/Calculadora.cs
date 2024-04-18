using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Calculadora
    {

        Queue<string> _historico = new Queue<string>();

        public void AdicionarHistorico(string operacao)
        {
            while (_historico.Count > 2)
            {
                _historico.Dequeue();
            }

            _historico.Enqueue(operacao);
        }

        public int Somar(int a, int b)
        {
            int resultado = a + b;

            AdicionarHistorico($"Somar = {resultado}");

            return resultado;
        }
        public int Subtrair(int a, int b)
        {
            int resultado = a - b;

            AdicionarHistorico($"Subtrair = {resultado}");

            return resultado;
        }
        public int Multiplicar(int a, int b)
        {
            int resultado = a * b;

            AdicionarHistorico($"Multiplicar = {resultado}");

            return resultado;
        }
        public int Dividir(int a, int b)
        {
            int resultado = a / b;

            AdicionarHistorico($"Dividir = {resultado}");

            return resultado;
        }
        public Queue<string> Historico() => _historico;
    }
}