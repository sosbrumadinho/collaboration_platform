# Contribuindo

Muito obrigado pelo seu interesse em contribuir com o projeto! Neste documento vamos falar o que você precisa saber para contribuir com este projeto e os primeiros passos.

## Visão Geral

Este repositório possui vários projetos, que serão separados por sessões. Você pode trabalher em um ou mais projetos. Esteja ciente que cada projeto tem as linguagens e frameworks aceitos para o desenvolvimento, qualquer implementação que não respeite esses quesitos pode ser rejeitada.

Nós utilizamos o idioma inglês para nomear nossas variáveis, propriedades, classes, etc.

# API

## Visão Geral

O projeto da API é feito em C# e é utilizado para conectar o projeto a serviços de terceiros (Linkedin, Escavador, etc). Recomendamos que você utilize o Visual Studio para contribuir com este projeto, mas lembre-se isso é apenas uma recomendação.

## Escrita de código - Boas Práticas

### Enums

- Sempre use `Unknow` como índice 0 para tipos de retorno que podem ser desconhecidos;
- Sempre use `Default` como índice 0 para tipos de opções que podem usar a opção padrão do sistema;
- Sempre use o nome do singular, por exemplo: `enum LogLevel` e não `enum LogLevels`.

### Estilo

- Preferimos que seja utilizado `is` para verificação de nulo, ao invés de `==`
- Utilizamos a versão 7.3 do C#, por favor siga as boas práticas documentadas para essa versão.
- Nós não usamos a palavra chave `private`, pois este é o nível de acessibilidade padrão do C#
- Nós não usamos `_` ou `s_` como prefixo para campos internos;
- Nós usamos `camelCase` para noemar campos internos ou privados.

# FrontEnd

## Visão Geral

O projeto do FrontEnd é feito utilizando javascript e o framework angular.