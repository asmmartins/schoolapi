#### Arquitetura

A arquitetura proposta se baseia no conceito hexagonal. Fazendo que seja separado o que � uma "abstra��o" de uma "implementa��o".

1. **Abstra��es** - � o contrato do que ser� implementado, sendo modelado atrav�s de interfaces e objetos de transfer�ncia.
2. **Implementa��es** - Desenvolvimento propriedade dito de um contrato previamente estabelecido.

A defini��o do contrato, antes do desenvolvimento, faz com que podemos trabalhar nas escritas dos testes automatizados e implementa��es de forma paralela.

Pensando na distribui��o desses m�dulos de uma solu��o ter�amos:

* **src** - Diret�rio raiz que armazena todos os c�digos de abstra��es e implementa��es.
  * **src/School.Api** - M�dulo de apresenta��o, recebe a requisi��o e delega o processamento para um "comando" ou "consulta".
  * **src/School.Application** - Cont�m os contratos dos casos de uso, que podem ser entendidos por interfaces e objetos de transfer�ncia.
  * **src/School.UseCases** - A implementa��es dos casos de uso, sejam de comandos ou consultas.
  * **src/School.Domain** - Respons�vel por conter os modelos de dom�nio (regras de neg�cios), relacionando-os e com enfase aos seus comportamentos.
  * **src/School.Repositories** - Implementa��es dos reposit�rios.
  * **src/School.Infra.IoC** - O conceito da invers�o de controle, atrav�s da inje��o de depend�ncias, seria configurado no m�dulo de IoC.

* **tests** - Diret�rio inicial de todos os testes automatizados.
  * **tests/School.Tests.Unit** - Testes unit�rios, com cada namespace separado para um m�dulo: **School.Tests.Unit.UseCases**, **School.Tests.Unit.Api** , **School.Tests.Unit.Repositores** e **School.Tests.Unit.Domain**.
  * **tests/School.Tests.Integration** - Testes integrados, onde as depend�ncias estariam acopladas. Seguindo a estrutura de diret�rios similar ao item anterior.
  * **tests/School.Tests.Api** - Constru��es dos testes de API's, subindo a aplica��o atrav�s do TestHost.
  * **tests/School.Tests.EndToEnd** - S�o requisi��es e testes feitos no Postman.

#### Setup

Instalar as seguintes ferramentas:
* [Git](https://git-scm.com/download/win)
* [Visual Studio 2019 (v16.4+)](https://visualstudio.microsoft.com)
* [SDK do .NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

Atrav�s da instala��o do Visual Studio 2019 � poss�vel instalar o Git e o SDK.

Acessar o diret�rio raiz onde o projeto foi clonado.
Executar o script respons�vel por rodar todos os comandos das etapas necess�rias para publica��o do software. 
```
.\build.ps1
```

Esse script ir� executar os comandos de limpeza, restaura��o de depend�ncias, constru��o, execu��o de testes e cria��o do pacote em projetos de componente, e caso esteja faltando alguma configura��o no ambiente o processo ir� indicar em qualquer uma dessas etapas.

#### Padr�es e pr�ticas

Para desenhar essa solu��o, foram consideradas as seguintes pr�ticas e padr�es.

- SOLID - N�o � um padr�o de projeto propriamente dito, mas o desenvolvimento foi pautado por buscar manter um c�digo dentro desse conjunto de boas p�tricas.
- DDD - A regra de neg�cio foi modelada usando os conceitos do desenvolvimento voltado a dom�nio.
- Reposit�rio - Repons�vel por armazenar as agrega��es. 
- Hexagonal - Separa��o das portas (abstra��es) e adaptadores (implementa��es).
- OpenAPI Specification - Documentado os recursos atrav�s do Swagger.
- Testes Automatizados - Criado estutura para comportar os testes unit�rios, integra��o e os de API's. Fazendo com que se consiga atingir a condu��o de desenvolvimento pr�xima ao TDD.
- Observability - Inclu�do uma configura��o do "Application Insights no Azure", para uma poss�vel ferramenta para dar auxl�lio e permita que a aplica��o seja observada por completo.