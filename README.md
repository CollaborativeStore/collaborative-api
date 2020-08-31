# Projeto ErrorCenter

![](https://github.com/wizsolucoes/api-wiz-template/workflows/.NET%20Core/badge.svg) 

## Sumário

* [Estrutura](#Estrutura)
* [Dependências](#dependências)
* [Builds e testes](#builds-e-testes)
 
## Estrutura

Padrão das camadas do projeto:

1. **Collaborative.Domain**: domínio da aplicação, responsável de manter as *regras de negócio* para a API;
2. **Collaborative.Infra**: camada mais baixa, para acesso a dados, infraestrutura e serviços externos;
3. **Collaborative.API**: responsável pela camada de *disponibilização* dos endpoints da API;
4. **Collaborative.Integration.Tests**: responsável pela camada de testes de integração dos projetos.
5. **Collaborative.Unit.Tests**: responsável pela camada de testes unitários dos projetos.

Formatação do projeto dentro do repositório:

```
├── src 
  ├── Collaborative.API (projeto)
  ├── Collaborative.Domain (projeto)
  ├── Collaborative.Infra (projeto)
├── test 
  ├── Collaborative.Integration.Tests (projeto)
  ├── Collaborative.Unit.Tests (projeto)
├── Collaborative (solução)
```
 
## Dependências

* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2)
* [Patterns RESTful](http://standards.rest/)
 
## Build e Testes

* Obrigatoriedade de **não diminuir** os testes de cobertura.
 