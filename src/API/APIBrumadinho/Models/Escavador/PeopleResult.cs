using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace APIBrumadinho.Models
{
    public class PeopleResult
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("lattes_id")]
        public string LattesId { get; set; }

        [JsonProperty("juridico_id")]
        public object JuridicoId { get; set; }

        [JsonProperty("usuario_id")]
        public object UsuarioId { get; set; }

        [JsonProperty("created_at")]
        public object CreatedAt { get; set; }

        [JsonProperty("ultimos_processos")]
        public IEnumerable<object> UltimosProcessos { get; set; }

        [JsonProperty("quantidade_processos")]
        public long QuantidadeProcessos { get; set; }

        [JsonProperty("estados_com_mais_processos")]
        public IEnumerable<object> EstadosComMaisProcessos { get; set; }

        [JsonProperty("link_api")]
        public Uri LinkApi { get; set; }

        [JsonProperty("oabs")]
        public IEnumerable<object> Oabs { get; set; }

        [JsonProperty("curriculo_lattes")]
        public CurriculoLattes CurriculoLattes { get; set; }

        [JsonProperty("comissoes_julgadoras")]
        public IEnumerable<object> ComissoesJulgadoras { get; set; }

        [JsonProperty("orientadores")]
        public IEnumerable<object> Orientadores { get; set; }
    }

    public class CurriculoLattes
    {
        [JsonProperty("lattes_id")]
        public string LattesId { get; set; }

        [JsonProperty("pessoa_id")]
        public long PessoaId { get; set; }

        [JsonProperty("titulo_bolsista")]
        public object TituloBolsista { get; set; }

        [JsonProperty("resumo")]
        public string Resumo { get; set; }

        [JsonProperty("linhas_de_pesquisa")]
        public object LinhasDePesquisa { get; set; }

        [JsonProperty("ultima_atualizacao")]
        public DateTimeOffset UltimaAtualizacao { get; set; }

        [JsonProperty("areas_de_atuacao")]
        public object AreasDeAtuacao { get; set; }

        [JsonProperty("nome_em_citacoes")]
        public string NomeEmCitacoes { get; set; }

        [JsonProperty("outras_informacoes_relevantes")]
        public object OutrasInformacoesRelevantes { get; set; }

        [JsonProperty("formacoes")]
        public IEnumerable<Formacoe> Formacoes { get; set; }

        [JsonProperty("pos_doutorados")]
        public IEnumerable<object> PosDoutorados { get; set; }

        [JsonProperty("formacoes_complementares")]
        public IEnumerable<object> FormacoesComplementares { get; set; }

        [JsonProperty("idiomas")]
        public IEnumerable<Idioma> Idiomas { get; set; }

        [JsonProperty("organizacoes_eventos")]
        public IEnumerable<object> OrganizacoesEventos { get; set; }

        [JsonProperty("participacoes_eventos")]
        public IEnumerable<object> ParticipacoesEventos { get; set; }

        [JsonProperty("participacoes_bancas")]
        public IEnumerable<object> ParticipacoesBancas { get; set; }

        [JsonProperty("orientacoes")]
        public IEnumerable<object> Orientacoes { get; set; }

        [JsonProperty("producoes_bibliograficas")]
        public IEnumerable<object> ProducoesBibliograficas { get; set; }

        [JsonProperty("outras_producoes")]
        public IEnumerable<object> OutrasProducoes { get; set; }

        [JsonProperty("projetos")]
        public IEnumerable<Projeto> Projetos { get; set; }

        [JsonProperty("projetos_desenvolvimento")]
        public IEnumerable<object> ProjetosDesenvolvimento { get; set; }

        [JsonProperty("premios")]
        public IEnumerable<object> Premios { get; set; }

        [JsonProperty("endereco_profissional")]
        public EnderecoProfissional EnderecoProfissional { get; set; }

        [JsonProperty("atuacoes_profissionais")]
        public IEnumerable<AtuacoesProfissionai> AtuacoesProfissionais { get; set; }
    }

    public class AtuacoesProfissionai
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ano_inicio")]
        public long AnoInicio { get; set; }

        [JsonProperty("ano_fim")]
        public object AnoFim { get; set; }

        [JsonProperty("titulo")]
        public object Titulo { get; set; }

        [JsonProperty("outras_informacoes")]
        public string OutrasInformacoes { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("instituicao_id")]
        public long InstituicaoId { get; set; }

        [JsonProperty("nome_instituicao")]
        public object NomeInstituicao { get; set; }

        [JsonProperty("lattes_id")]
        public string LattesId { get; set; }

        [JsonProperty("usuario_id")]
        public object UsuarioId { get; set; }

        [JsonProperty("link_instituicao")]
        public Uri LinkInstituicao { get; set; }

        [JsonProperty("nome_instituicao_relacionada")]
        public string NomeInstituicaoRelacionada { get; set; }
    }

    public class EnderecoProfissional
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("lattes_id")]
        public string LattesId { get; set; }
    }

    public class Formacoe
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ano_inicio")]
        public long AnoInicio { get; set; }

        [JsonProperty("ano_fim")]
        public string AnoFim { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("orientador")]
        public object Orientador { get; set; }

        [JsonProperty("orientador_id")]
        public object OrientadorId { get; set; }

        [JsonProperty("outros_dados")]
        public string OutrosDados { get; set; }

        [JsonProperty("instituicao_id")]
        public long InstituicaoId { get; set; }

        [JsonProperty("nome_instituicao")]
        public object NomeInstituicao { get; set; }

        [JsonProperty("lattes_id")]
        public string LattesId { get; set; }

        [JsonProperty("usuario_id")]
        public object UsuarioId { get; set; }

        [JsonProperty("link_instituicao")]
        public Uri LinkInstituicao { get; set; }

        [JsonProperty("nome_instituicao_relacionada")]
        public string NomeInstituicaoRelacionada { get; set; }
    }

    public class Idioma
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("bandeira")]
        public string Bandeira { get; set; }

        [JsonProperty("pivot")]
        public Pivot Pivot { get; set; }
    }

    public class Pivot
    {
        [JsonProperty("lattes_id")]
        public string LattesId { get; set; }

        [JsonProperty("idioma_id")]
        public long IdiomaId { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }
    }

    public class Projeto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("ano_inicio")]
        public long AnoInicio { get; set; }

        [JsonProperty("ano_fim")]
        public object AnoFim { get; set; }

        [JsonProperty("lattes_id")]
        public string LattesId { get; set; }
    }
}
