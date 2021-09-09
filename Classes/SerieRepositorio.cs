using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	//É aqui que o CRUD ocorre de fato
	//Classe responsável por guardar os objetos Serie na listaSerie
	//Implementação da assinatura da interface IRepositório
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();

		//Modifica um objeto Serie dentro da listaSerie
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		//Apenas marcar o item como excluído, mas não apagar
		//Para os ids não serem alterados com a retirada do obj Serie
		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		//Inserção de lista padrão
		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		//Cahamar listaSerie
		public List<Serie> Lista()
		{
			return listaSerie;
		}

		//Como a contagem se inicia do 0
		//O próximo id sempre será o último número da contagem
		public int ProximoId()
		{
			return listaSerie.Count;
		}

		//Retornar o objeto através do id
		public Serie RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}