using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace APIBrumadinho.Models.Escavador
{
    public class InstituteResult
    {
        [JsonProperty("tipo_resultado")]
        public string TipoResultado { get; set; }

        [JsonProperty("sigla")]
        public string Sigla { get; set; }

        [JsonProperty("tipos_juridico")]
        public TiposJuridico[] TiposJuridico { get; set; }

        [JsonProperty("quantidade_processos")]
        public long QuantidadeProcessos { get; set; }

        [JsonProperty("tem_processo")]
        public long TemProcesso { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("resumo")]
        public string Resumo { get; set; }

        [JsonProperty("quantidade_pessoas")]
        public long QuantidadePessoas { get; set; }

        [JsonProperty("url_id")]
        public long UrlId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("pais")]
        public string Pais { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("link_api")]
        public Uri LinkApi { get; set; }
    }

    public class TiposJuridico
    {
        [JsonProperty("quantidade_processos")]
        public long QuantidadeProcessos { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
