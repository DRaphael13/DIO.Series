using System;
using DIO.Series.classes;

namespace DIO.Series
{
    public class Series : EntidadeBase
    {
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descrição {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descrição = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public Series(int id, Genero genero, string titulo, int ano, int descricao)
        {
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo" + this.Titulo + Environment.NewLine;
            retorno += "Descrição" + this.Descrição + Environment.NewLine;
            retorno += "Ano de início: " + this.Ano;
            return retorno;
        }
        public string retornoTitulo()
        {
            return this.Titulo;
        }
        public int retornoId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}