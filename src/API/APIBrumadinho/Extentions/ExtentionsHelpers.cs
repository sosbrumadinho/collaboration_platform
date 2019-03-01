using System.Collections.Generic;
using System.Linq;
using APIBrumadinho.API;

namespace System
{
    public static class ExtentionsHelpers
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection is null || collection.Count() == 0)
                throw new Exception("The collection can't be null");

            if (action is null)
                throw new ArgumentNullException($"The {nameof(action)} can't be null!");

            foreach (var item in collection)
                action(item);
        }

        public static string Entity2String(this Enumerators.EscavadorEntity entity)
        {
            switch (entity)
            {
                case Enumerators.EscavadorEntity.Todos:
                    return "t";
                case Enumerators.EscavadorEntity.Pessoas:
                    return "p";
                case Enumerators.EscavadorEntity.Intituicoes:
                    return "i";
                case Enumerators.EscavadorEntity.Patentes:
                    return "pa";
                case Enumerators.EscavadorEntity.DiarioOficial:
                    return "d";
                case Enumerators.EscavadorEntity.Processos:
                    return "en";
                case Enumerators.EscavadorEntity.Artigos:
                    return "a";
                default:
                    return null;
            }
        }

        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        public static bool IsNullOrWhiteSpace(this string s) => string.IsNullOrWhiteSpace(s);
    }
}
