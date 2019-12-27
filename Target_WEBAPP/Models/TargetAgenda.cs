using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Target_WEBAPP.Models
{
    public class TargetAgenda
    {
        public long ID { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DataFinal { get; set; }

        [Display(Name = "Tipo do Agendamento")]
        public TipoAgendamento tipoAgendamento { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }
    }
    public enum TipoAgendamento
    {
        Novo,
        Retorno
    }

    public class RootObject
    {
        public List<TargetAgenda> agendas { get; set; }
    }
}