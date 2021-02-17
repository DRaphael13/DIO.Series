using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.classes
{
    public class SeriesRepositorio : IRepositorio<Series>
    {
        private List<Series> ListaSeries = new List<Series>();
        private Series objeto;

        public void Atualizar(int id, Series objeto)
        {
            ListaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaSeries[id].Excluir();
        }

        public void Insere(Series entidade)
        {
            ListaSeries.Add(objeto);
        }

        public List<Series> Lista()
        {
            return ListaSeries;
        }

        public int ProximoId()
        {
            return ListaSeries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }
}