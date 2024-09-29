# APIs e Web Services

Para o desenvolvimento do sistema de agendamento de consultas médicas (web e mobile) foi criada a API que será apresentada nos próximos tópicos, juntamente com a arquitetura que são cruciais para garantir eficiência, escalabilidade e segurança da solução a ser desenvolvida.


## Objetivos da API

O objetivo da API é fornecer às aplicações web e móvel o acesso ao cadastro de usuários, autenticação de usuário, realizar agendamento, notificação de agendamento e consulta ao histórico de agendamentos. A API não será disponibilizada para consulta externa.


## Arquitetura

A API visa fornecer informações sobre os agendamentos tendo como ponto principal consultar os agendamentos realizados pelos usuários. As aplicações web e aplicações móveis farão as solicitações para uma API usando protocolo HTTPS. A arquitetura é monolítica, consistindo em uma única aplicação que organiza suas funcionalidades em camadas, onde a interface do usuário e a lógica de acesso a dados estão integradas em um único programa. A estrutura escolhida foi a modular, o que não apenas facilita a organização do código, mas também possibilita a escalabilidade futura, caso seja necessário expandir suas funcionalidades. O sistema de gerenciamento de banco de dados relacional escolhido foi o PostgreSQL que é conhecido por sua robustez, flexibilidade e conformidade com padrões SQL. A autenticação escolhida foi a JWT (JSON Web Token) Bearer, que é um método de autenticação que utiliza tokens JSON para permitir que usuários ou sistemas se identifiquem de maneira segura.


## Modelagem da Aplicação

A modelagem da aplicação segue o padrão de API REST, onde cada recurso corresponde a uma entidade do sistema. Os principais entidades incluem:
- Usuário: Representado por pacientes, médicos e administradores.
- Consulta: Representa os dados de uma consulta médica, incluindo data, hora, paciente e médico.
- Notificações: Gera lembretes das consultas para os usuários.

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/8004c54f34a4b2363cf38b6d5dfa3e2dcbfc734a/docs/img/Diagrama%20de%20Classe%20-%20Consulta%20F%C3%A1cil.png)

## Fluxo de Dados

O fluxo de dados na aplicação segue o padrão cliente-servidor, conforme o diagrama a seguir:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/763279f5990374584b32c9d5c1b20200afbf066e/docs/img/Diagrama%20de%20fluxo%20de%20dados%20-%20Consulta%20F%C3%A1cil.png)

## Requisitos Funcionais

[Liste os principais requisitos funcionais da aplicação.]

## Requisitos Não Funcionais

[Liste os principais requisitos não funcionais da aplicação, como desempenho, segurança, escalabilidade, etc.]

## Tecnologias Utilizadas

- C#/ASP .NET Core: Framework utilizado durante todo o desenvolvimento da API que utiliza a linguagem C#;
- Visual Studio: IDE utlizada junto ao ASP .NET Core;
Entity Framework: Framework utilizado durante o desenvolvimento da aplicação para auxiliar na integração da API ao banco de dados;
- Postman: Utilizado para testes de requisição para a API.
- GitHub: Plataforma utilizada para versionamento de versões.

## API Endpoints

A figura abaixo mostra o localhost na ferramenta SWAGGER:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/9f22fc97edd9c10d673d55c09decf7d674df7a38/docs/img/Swagger.PNG)

- Cadastro de usuários

Esta rota demonstra a criação de um usuário após a inserção de um nome, CPF, E-mail, senha, telefone, data de nascimento, sexo e perfil :

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/85c0270fa59a4a344490fbf65757de238060b5fd/docs/img/Criar%20usu%C3%A1rio%20login%20administrador.PNG)

- Autenticação de administrador

Esta rota mostra a autenticação de administrador com a inserção de usuário e senha:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/07a6c7da4401ef566d711cb8d28193a0bf4116df/docs/img/Autenticar%20administrador%20token.PNG)

- Buscar todos os usuários

Esta rota mostra a busca de todos os usuários (getAll) por meio do login de administrador:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/8277f278a18bef0d52aef511d1a9b559b4155ee9/docs/img/Buscar%20usu%C3%A1rios%20login%20administrador.PNG)

- Buscar usuários específicos

Esta rota mostra a busca de um usuário específico (getByld) no sistema:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/66afc0a4a23b7c7364764c0896e2d5d4ae393926/docs/img/Buscar%20usu%C3%A1rios%20espec%C3%ADfico%20login%20administrador.PNG)



### Endpoint 1
- Método: GET
- URL: /endpoint1
- Parâmetros:
  - param1: [descrição]
- Resposta:
  - Sucesso (200 OK)
    ```
    {
      "message": "Success",
      "data": {
        ...
      }
    }
    ```
  - Erro (4XX, 5XX)
    ```
    {
      "message": "Error",
      "error": {
        ...
      }
    }
    ```


## Considerações de Segurança

[Discuta as considerações de segurança relevantes para a aplicação distribuída, como autenticação, autorização, proteção contra ataques, etc.]

## Implantação

[Instruções para implantar a aplicação distribuída em um ambiente de produção.]

1. Defina os requisitos de hardware e software necessários para implantar a aplicação em um ambiente de produção.
2. Escolha uma plataforma de hospedagem adequada, como um provedor de nuvem ou um servidor dedicado.
3. Configure o ambiente de implantação, incluindo a instalação de dependências e configuração de variáveis de ambiente.
4. Faça o deploy da aplicação no ambiente escolhido, seguindo as instruções específicas da plataforma de hospedagem.
5. Realize testes para garantir que a aplicação esteja funcionando corretamente no ambiente de produção.

## Testes

[Descreva a estratégia de teste, incluindo os tipos de teste a serem realizados (unitários, integração, carga, etc.) e as ferramentas a serem utilizadas.]

1. Crie casos de teste para cobrir todos os requisitos funcionais e não funcionais da aplicação.
2. Implemente testes unitários para testar unidades individuais de código, como funções e classes.
3. Realize testes de integração para verificar a interação correta entre os componentes da aplicação.
4. Execute testes de carga para avaliar o desempenho da aplicação sob carga significativa.
5. Utilize ferramentas de teste adequadas, como frameworks de teste e ferramentas de automação de teste, para agilizar o processo de teste.

# Referências

Inclua todas as referências (livros, artigos, sites, etc) utilizados no desenvolvimento do trabalho.
