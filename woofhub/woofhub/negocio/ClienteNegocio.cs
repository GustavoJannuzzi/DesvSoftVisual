using System;

namespace WoofHub.Negocio
{
    public class ClienteNegocio
    {
        public static bool IsCPF(string CPF)
        {
            // Considera-se erro CPF's formados por uma sequência de números iguais
            if (CPF == "00000000000" || CPF == "11111111111" || CPF == "22222222222"
                || CPF == "33333333333" || CPF == "44444444444" || CPF == "55555555555"
                || CPF == "66666666666" || CPF == "77777777777" || CPF == "88888888888"
                || CPF == "99999999999" || CPF.Length != 11)
                return false;

            char dig10, dig11;
            int sm, i, r, num, peso;

            // "try" - protege o código para eventuais erros de conversão de tipo (int)
            try
            {
                // Cálculo do 1o. Digito Verificador
                sm = 0;
                peso = 10;
                for (i = 0; i < 9; i++)
                {
                    // Converte o i-ésimo caractere do CPF em um número:
                    // Por exemplo, transforma o caractere '0' no inteiro 0
                    // (48 é a posição de '0' na tabela ASCII)
                    num = (int)(CPF[i] - 48);
                    sm = sm + (num * peso);
                    peso = peso - 1;
                }

                r = 11 - (sm % 11);
                if (r == 10 || r == 11)
                    dig10 = '0';
                else
                    dig10 = (char)(r + 48); // Converte no respectivo caractere numérico

                // Cálculo do 2o. Digito Verificador
                sm = 0;
                peso = 11;
                for (i = 0; i < 10; i++)
                {
                    num = (int)(CPF[i] - 48);
                    sm = sm + (num * peso);
                    peso = peso - 1;
                }

                r = 11 - (sm % 11);
                if (r == 10 || r == 11)
                    dig11 = '0';
                else
                    dig11 = (char)(r + 48);

                // Verifica se os dígitos calculados conferem com os dígitos informados.
                return (dig10 == CPF[9] && dig11 == CPF[10]);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
