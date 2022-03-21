﻿namespace ClubeDaLeitura
{
    public class Amigo
    {
        public string Nome;
        public string NomeResponsavel;
        public string Telefone;
        public string Endereco;
        public bool EstaComRevista;
        public Revista Revista;
        public Multa Multa;

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
            Endereco = endereco;
            EstaComRevista = false;
        }

        public override string ToString()
        {
            return $"\nNome: {Nome}" +
                $"\nNome do responsável: {NomeResponsavel}" +
                $"\nTelefone: {Telefone}" +
                $"\nEndereço: {Endereco}";
        }
    }
}