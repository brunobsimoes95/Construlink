using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Construlink.Models;
using Construlink.Pages;
using Construlink.Models;

namespace Construlink.Data
{
    //############ DbContext Factory ############//
    public interface IDbContextFactoryService
    {

        DbContext GetDbContext(string nomeBase);
    }


    public class DbContextFactoryService : IDbContextFactoryService
    {
        public DbContext GetDbContext(string nomeBase)
        {
            return nomeBase switch
            {
                "BaseControle" => new BaseControleContext(),
                
                "Construlink" => new ConstrulinkContext(),
                _ => throw new ArgumentException("Nome da Base Inválido"),
            };
        }
    }

    public class Geolocation
    {
        public bool IsSuccess { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Message { get; set; }
    }
    //pastas e ficheiros
    public class FileSystemEntry
    {
        public string FatherPath { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsFile { get; set; }
    }

    //alertas
    public class AlertaDados
    {
        public string tipo { get; set; }
        public string alerta { get; set; }
        public object objeto { get; set; }
    }
    
    //Calendário - Datas
    public class DataCalendario
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        //public bool overlap { get; set; }
        //public string display { get; set; }
        public string color { get; set; }
        public string url { get; set; }
    }
    public class DataCalendarioHorario
    {
        public int dia { get; set; }
        public TimeOnly tini { get; set; }
        public TimeOnly tfim { get; set; }
    }

    //Timeline - Datas e Equipamentos
    public class DataTimeline
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        //public bool overlap { get; set; }
        //public string display { get; set; }
        public string color { get; set; }
        public string url { get; set; }
        public int resource { get; set; }
    }

    public class EquipTimeline
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }

    public class EntidadeMorada
    {
        public string? Empresa { get; set; }
        public string? Morada { get; set; }
        public string? Localidade { get; set; }
        public string? CodigoPostal { get; set; }
        public int? Pais { get; set; }
        public int? Distrito { get; set; }
        public int? Concelho { get; set; }
    }

    public class EntidadeDocumentos
    {
        public int? Id { get; set; }
        public int? Tipo { get; set; }
        public DateTime? Data { get; set; }
        public string? Documento { get; set; }
        public string? Entidade { get; set; }
        public decimal? Total { get; set; }
        public CrmDocumento? Objecto { get; set; }
    }
}
