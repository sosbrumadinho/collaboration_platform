using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace APIBrumadinho.Models.Escavador
{
    public partial class ArticleResult
    {
        [JsonProperty("tipo_resultado")]
        public string TipoResultado { get; set; }

        [JsonProperty("usuario_nome")]
        public string UsuarioNome { get; set; }

        [JsonProperty("usuario_imagem")]
        public Uri UsuarioImagem { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("usuario_link")]
        public Uri UsuarioLink { get; set; }

        [JsonProperty("conteudo_preview")]
        public string ConteudoPreview { get; set; }

        [JsonProperty("conteudo")]
        public string Conteudo { get; set; }
    }
}
