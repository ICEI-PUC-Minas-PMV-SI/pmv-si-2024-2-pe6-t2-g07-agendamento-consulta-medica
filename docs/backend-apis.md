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

1. A aplicação deve permitir aos usuários administradores se cadastrarem, editarem ou excluírem seu usuário, realizarem log-in no sistema.
2. Os usuários médicos devem conseguir criar e deletar consultas.
3. Os usuários pacientes devem conseguir agendar e cancelar o agendamento de uma consulta.
4. A API deve autenticar os usuários antes de permitir o uso do sistema.

## Requisitos Não Funcionais

1. O sistema deve usar JWT para autenticação e autorização.
2. As respostas das APIs devem ter um tempo de resposta inferior a 2 segundos.
3. O sistema deve estar disponível 99% do tempo.
4. O sistema deve suportar o aumento de usuários e agendamentos sem perda de desempenho.
5. As APIs devem ser compatíveis com aplicações web e mobile.

## Tecnologias Utilizadas

- C#/ASP .NET Core: Framework utilizado durante todo o desenvolvimento da API que utiliza a linguagem C#;
- Visual Studio: IDE utilizada junto ao ASP .NET Core;
Entity Framework: Framework utilizado durante o desenvolvimento da aplicação para auxiliar na integração da API ao banco de dados;
- Postman: Utilizado para testes de requisição para a API;
- GitHub: Plataforma utilizada para versionamento;
- Banco de Dados PostgreSQL: Armazenamento de dados;
- JsonWebToken: Autenticação de usuários com acesso;
- Swagger: Desenvolvimento da API.

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

Abaixo a visualização dos dados de todos os usuários no PostgreSQL:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/7584b290b9bbaf40e41ca5e8460e51d25310c3bf/docs/img/Visualiza%C3%A7%C3%A3o%20dos%20dados%20no%20Postgre%20-%20Buscar%20todos%20os%20usu%C3%A1rios.PNG)


- Buscar usuários específicos

Esta rota mostra a busca de um usuário específico (getByld) no sistema:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/66afc0a4a23b7c7364764c0896e2d5d4ae393926/docs/img/Buscar%20usu%C3%A1rios%20espec%C3%ADfico%20login%20administrador.PNG)

- Editar usuário

Esta rota mostra a edição de usuário pelo administrador:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/e89b6fa1e9775e508423febe64c16c004fcec773/docs/img/Editar%20usu%C3%A1rio%20login%20administrador.PNG)

- Excluir usuário (autorizado)

Esta rota mostra a exclusão de usuário pelo administrador:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/d63119dcca9b5e0bde92753df89cb0ed1c65b177/docs/img/Exclus%C3%A3o%20usu%C3%A1rio%20login%20administrador.PNG)

- Excluir usuário (sem autorização)

Esta rota mostra a tentativa de deletar um usuário sem ter essa permissão:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/df4e71db6c06f4e65090eca85a0c09514aebcdee/docs/img/Fazer%20uma%20opera%C3%A7%C3%A3o%20de%20exclus%C3%A3o%20de%20usu%C3%A1rio%20sem%20estar%20autorizado.PNG)

- Criar consulta - login médico

Esta rota mostra a criação de uma consulta pelo médico logado com a inserção da data e hora da consulta:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/33eb92ab172cb3e80b55bdf8df22c6b7d8b080d6/docs/img/Criar%20consulta%20login%20m%C3%A9dico%20Aline.PNG)

- Buscar consultas - login médico (consulta disponível)

Esta rota mostra um médico logado verificando se há consulta disponível:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/a1061e978835e994ee9a5a0cbdf06b42c56638a7/docs/img/Buscar%20consultas%20login%20medico%20Aline%20-%20consulta%20dispon%C3%ADvel.PNG)

- Buscar consultas - login paciente

Esta rota visa buscar as consultas agendadas pelo usuário:

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/a1061e978835e994ee9a5a0cbdf06b42c56638a7/docs/img/Buscar%20consultas%20login%20paciente%20Ana.PNG)

- Visualização de dados no PostfreSQL - Buscar todas as consultas

![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/7584b290b9bbaf40e41ca5e8460e51d25310c3bf/docs/img/Visualiza%C3%A7%C3%A3o%20dos%20dados%20no%20Postgre%20-%20Buscar%20todas%20as%20consultas.PNG)


## Considerações de Segurança

A utilização da autenticação JWT (JSON Web Token) Bearer em uma aplicação distribuída traz diversas considerações de segurança que são cruciais para proteger os dados e a integridade do sistema. Aqui estão os principais aspectos a serem considerados:

- Autenticação Segura: utilização de HTTPS para a proteger a transmissão do token JWT, evitando que ele seja interceptado por outros durante a comunicação entre cliente e servidor; ter como requisito a utilização de senhas fortes por parte dos usuários para proteger a geração do token.
- Autorização: verificação de usuários com suas permissões para disponibilizar os recursos específicos.
- Prevenção de SQL Injection ao realizar comunicação com o banco de dados somente no backend


## Implantação

1. Pré-requisitos
Ferramentas necessárias:
    - Docker e Docker Compose.
    - Node.js (v14 ou superior).
    - PostgreSQL (utilizado como banco de dados).

2. Configuração de Variáveis de Ambiente
Crie um arquivo .env na raiz do projeto com as seguintes variáveis:
    - PORT: Porta de execução do backend (ex: 3000).
    - DB_HOST: localhost ou nome do container Docker.
    - DB_USER: Usuário do PostgreSQL (ex: postgres).
    - DB_PASS: Senha do PostgreSQL.
    - DB_NAME: Nome do banco de dados (ex: agendamento_db).

3. Configuração e Execução do Banco de Dados
Configure e execute o PostgreSQL usando Docker:
    - docker run --name banco_agendamento -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=senha -e POSTGRES_DB=agendamento_db -p 5432:5432 -d postgres

4. Execução do Backend
No diretório do backend:
    - npm install
    - npm run dev

5. Execução do Frontend
No diretório do frontend:
    - npm install
    - npm start

6. Execução Completa usando Docker Compose
No diretório raiz do projeto, utilize:
    - docker-compose up --build

7. Verificação
Acesse o sistema na URL http://localhost:3000 para garantir que o sistema foi implantado corretamente com o banco PostgreSQL.

## Testes

[Descreva a estratégia de teste, incluindo os tipos de teste a serem realizados (unitários, integração, carga, etc.) e as ferramentas a serem utilizadas.]

1. Crie casos de teste para cobrir todos os requisitos funcionais e não funcionais da aplicação.
2. Implemente testes unitários para testar unidades individuais de código, como funções e classes.
3. Realize testes de integração para verificar a interação correta entre os componentes da aplicação.
4. Execute testes de carga para avaliar o desempenho da aplicação sob carga significativa.
5. Utilize ferramentas de teste adequadas, como frameworks de teste e ferramentas de automação de teste, para agilizar o processo de teste.

# Referências

Documentação do Swagger
https://swagger.io/docs/

Microfundamento: Apis e Web Services - Canvas, PUC Minas Virtual 2024

Inclua todas as referências (livros, artigos, sites, etc) utilizados no desenvolvimento do trabalho.
