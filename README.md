#### Arquitetura

A arquitetura proposta se baseia no conceito CQRS. Fazendo que seja separado o que é uma "abstração" de uma "implementação".

1. **Abstrações** - É o contrato do que será implementado, sendo modelado através de interfaces e objetos de transferência.
2. **Implementações** - Desenvolvimento propriedade dito de um contrato previamente estabelecido.

A definição do contrato, antes do desenvolvimento, faz com que podemos trabalhar nas escritas dos testes automatizados e implementações de forma paralela.

Pensando na distribuição desses módulos de uma solução teríamos:

* **src** - Diretório raiz que armazena todos os códigos de abstrações e implementações.
  * **src/School.Api** - Módulo de apresentação, recebe a requisição e delega o processamento para um "comando" ou "consulta".
  * **src/School.Application** - Contém os contratos dos casos de uso, que podem ser entendidos por interfaces e objetos de transferência.
  * **src/School.UseCases** - A implementações dos casos de uso, sejam de comandos ou consultas.
  * **src/School.Domain** - Responsável por conter os modelos de domínio (regras de negócios), relacionando-os e com enfase aos seus comportamentos.
  * **src/School.Repositories** - Implementações dos repositórios.
  * **src/School.Infra.IoC** - O conceito da inversão de controle, através da injeção de dependências, seria configurado no módulo de IoC.

* **tests** - Diretório inicial de todos os testes automatizados.
  * **tests/School.Tests.Unit** - Testes unitários, com cada namespace separado para um módulo: **School.Tests.Unit.UseCases**, **School.Tests.Unit.Api** , **School.Tests.Unit.Repositores** e **School.Tests.Unit.Domain**.
  * **tests/School.Tests.Integration** - Testes integrados, onde as dependências estariam acopladas. Seguindo a estrutura de diretórios similar ao item anterior.
  * **tests/School.Tests.Api** - Construções dos testes de API's, subindo a aplicação através do TestHost.
  * **tests/School.Tests.EndToEnd** - São requisições e testes feitos no Postman.

#### Setup

Instalar as seguintes ferramentas:
* [Git](https://git-scm.com/download/win)
* [Visual Studio 2019 (v16.4+)](https://visualstudio.microsoft.com)
* [SDK do .NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

Através da instalação do Visual Studio 2019 é possível instalar o Git e o SDK.

Acessar o diretório raiz onde o projeto foi clonado.
Executar o script responsável por rodar todos os comandos das etapas necessárias para publicação do software. 
```
.\build.ps1
```

Esse script irá executar os comandos de limpeza, restauração de dependências, construção, execução de testes e criação do pacote em projetos de componente, e caso esteja faltando alguma configuração no ambiente o processo irá indicar em qualquer uma dessas etapas.

#### Padrões e práticas

Para desenhar essa solução, foram consideradas as seguintes práticas e padrôes.

- SOLID - Não é um padrão de projeto propriamente dito, mas o desenvolvimento foi pautado por buscar manter um código dentro desse conjunto de boas pátricas.
- DDD - A regra de negócio foi modelada usando os conceitos do desenvolvimento voltado a domínio.
- Repositório - Reponsável por armazenar as agregações. 
- Hexagonal - Separação das portas (abstrações) e adaptadores (implementações).
- OpenAPI Specification - Documentado os recursos através do Swagger.
- Testes Automatizados - Criado estutura para comportar os testes unitários, integração e os de API's. Fazendo com que se consiga atingir a condução de desenvolvimento próxima ao TDD.
- Observability - Incluído uma configuração do "Application Insights no Azure", para uma possível ferramenta para dar auxlílio e permita que a aplicação seja observada por completo.