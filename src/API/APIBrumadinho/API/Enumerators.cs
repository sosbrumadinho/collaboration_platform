namespace APIBrumadinho.API
{
    public class Enumerators
    {
        public enum EscavadorEntity
        {
            // Tipo da entidade a ser pesquisada. os valores podem ser:
            // t: Para pesquisar todos os tipos de entidades
            // p: Para pesquisar apenas as pessoas
            // i: Para pesquisar apenas as instituições
            // pa: Para pesquisar apenas as patentes
            // d: Para pesquisar apenas os Diários Oficiais
            // en: Para pesquisar as pessoas e instituições que são partes em processos
            // a: Para pesquisar apenas os artigos

            Todos = 0,
            Pessoas = 1,
            Intituicoes = 2,
            Patentes = 3,
            DiarioOficial = 4,
            Processos = 5,
            Artigos = 6
        }
    }
}
