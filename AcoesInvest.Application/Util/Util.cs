using System.Text.RegularExpressions;

namespace AcoesInvest.Application.Util;

public class Util
{
    public static bool ValidarEmail(string email)
    {

        if ((email == null) || (email.Length < 4))
            return false;

        var partes = email.Split('@');
        if (partes.Length < 2) return false;

        var pre = partes[0];

        if (pre.Length == 0) return false;

        var validadorPre = new Regex("^[a-zA-Z0-9_.-/+]+$");

        if (!validadorPre.IsMatch(pre))
            return false;

        var partesDoDominio = partes[1].Split(".");
        if (partesDoDominio.Length < 2) return false;

        var validadorDominio = new Regex("^[a-zA-Z0-9-]+$");
        for (int i = 0; i < partesDoDominio.Length; i++)
        {
            var parteDoDominio = partesDoDominio[i];
            if (partesDoDominio.Length == 0) return false;

            if (!validadorDominio.IsMatch(parteDoDominio))
                return false;
        }

        return true;

    }

    public static bool ValidarSenha(string senha, out string erro)
    {
        erro = string.Empty;

        if (string.IsNullOrWhiteSpace(senha))
        {
            erro = "A senha não pode ser vazia.";
            return false;
        }

        if (senha.Length < 8)
        {
            erro = "A senha deve conter no mínimo 8 caracteres.";
            return false;
        }

        if (!senha.Any(char.IsUpper))
        {
            erro = "A senha deve conter pelo menos uma letra maiúscula.";
            return false;
        }

        if (!senha.Any(char.IsLower))
        {
            erro = "A senha deve conter pelo menos uma letra minúscula.";
            return false;
        }

        if (!senha.Any(char.IsDigit))
        {
            erro = "A senha deve conter pelo menos um número.";
            return false;
        }

        return true;
    }


}

