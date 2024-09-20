# APIs e Web Services

Para o desenvolvimento do sistema de agendamento de consultas médicas (web e mobile) foi criada a API que será apresentada nos próximos tópicos, juntamente com a arquitetura que são cruciais para garantir eficiência, escalabilidade e segurança da solução a ser desenvolvida.


## Objetivos da API

Os objetivos da API proposta envolve sua utilização apenas por aplicações internas.

1. Facilitar a Integração: Proporcionar uma comunicação eficiente e consistente entre a aplicação web e mobile do sistema de agendamento.
A API deve disponibilizar endpoints claros para operações de CRUD (Criar, Ler, Atualizar, Excluir), abrangendo recursos como usuários, agendamentos e notificações. A consistência nas respostas e nos formatos de dados será essencial para garantir a integração suave entre os sistemas.
2. Implementar um sistema de autenticação robusto, como o OAuth 2.0, além de criptografar dados sensíveis de forma a garantir a segurança, assegurando a proteção dos dados dos usuários e a integridade das operações realizadas através da API.
3. Fornecer Dados em Tempo Real, garantindo que os usuários recebam atualizações instantâneas sobre consultas e horários disponíveis.
4. Escalabilidade e Desempenho: Garantir que a API seja capaz de lidar com um grande volume de requisições simultâneas (agendamento e verificar as consultas agendadas), mantendo um desempenho estável, conforme número de profissionais e centros de saúde utilizem a ferramenta.


## Arquitetura

- GestaoAgendamentos.Web (Interface Web):
    =Responsável por fornecer a interface do usuário.
    =Consome a API Gateway para realizar operações CRUD de agendamentos, histórico de consultas e receber notificações.
  
- GestaoAgendamentos.API (API Gateway):
    =Ponto de entrada único para todas as requisições da interface web.
    =Roteia as requisições para o microsserviço apropriado.
    =Implementa autenticação e autorização.
  
- GestaoAgendamentos.Produto (Microsserviço):
    =Gerencia as operações relacionadas as consultas (CRUD).
    =Interage com o banco de dados para persistir os dados.
    =Publica eventos no RabbitMQ após operações de atualização no banco de dados.
  
- GestaoAgendamentos.Relatorios (Microsserviço):
    =Responsável por gerar e disponibilizar relatórios de consultas agendadas.
    =Consome mensagens do RabbitMQ para atualizar os relatórios em background.
  
- RabbitMQ (Message Broker):
    =Sistema de mensageria para comunicação assíncrona entre os microsserviços.
    =Utilizado para propagar as atualizações de agendamentos do microsserviço "Produto" para o "Relatórios".
  
- SQL Server (Banco de Dados):
    =Armazena os dados das consultas agendadas e canceladas.






![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/830305ee8f5c5be317d29d6fb642085ecd8659fc/docs/img/Diagrama%20de%20Classe%20-%20Consulta%20F%C3%A1cil.png)

## Modelagem da Aplicação
[Descreva a modelagem da aplicação, incluindo a estrutura de dados, diagramas de classes ou entidades, e outras representações visuais relevantes.]


## Fluxo de Dados

[Diagrama ou descrição do fluxo de dados na aplicação.]

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

[Liste os principais endpoints da API, incluindo as operações disponíveis, os parâmetros esperados e as respostas retornadas.]

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
