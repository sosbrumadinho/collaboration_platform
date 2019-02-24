using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace APIBrumadinho.Models.Escavador
{
    public class PatentResult
    {
        [JsonProperty("numero_pagina")]
        public long NumeroPagina { get; set; }

        [JsonProperty("envolvidos_patente")]
        public EnvolvidosPatente[] EnvolvidosPatente { get; set; }

        [JsonProperty("patente_id")]
        public long PatenteId { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("url_id")]
        public long UrlId { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("texto_preview")]
        public string TextoPreview { get; set; }

        [JsonProperty("texto")]
        public string Texto { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }
    }

    public class EnvolvidosPatente
    {
        [JsonProperty("objeto_type")]
        public string ObjetoType { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("url_id")]
        public long UrlId { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
