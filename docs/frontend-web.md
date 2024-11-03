# Front-end Web

O Consulta Fácil é uma solução web desenvolvida para otimizar o processo de agendamento de consultas médicas em uma clínica pública. O sistema visa reduzir a espera e simplificar o gerenciamento das agendas de médicos e pacientes, proporcionando uma interface acessível para reservas e acompanhamento de consultas.

## Tecnologias Utilizadas

- HTML5 e CSS3 com Bootstrap 5: Para criação das interfaces responsivas.
-	JavaScript: Para a interatividade da página e manipulação assíncrona de dados.
-	Node.js e Express: Para o front-end da aplicação.
-	PostgreSQL: Banco de dados NoSQL para gerenciamento eficiente dos dados de consultas e usuários.
-	JWT (JSON Web Tokens): Para autenticação e segurança da aplicação.

## Arquitetura

O Consulta Fácil é projetado com uma arquitetura de três camadas:
-	Front-end (Cliente): Interface do usuário desenvolvida com HTML, CSS e JavaScript.
-	API RESTful (Back-end): Backend desenvolvido em C# utilizando o framework ASP.NET Core, que recebe as solicitações do cliente, manipula e consulta dados no banco, e retorna respostas ao usuário.
-	Banco de Dados: PostgreSQL armazena dados estruturados sobre usuários, pacientes, médicos, administradores e consultas, facilitando a escalabilidade e organização.
Essa divisão permite uma separação clara de responsabilidades e facilita a manutenção e escalabilidade.

## Modelagem da Aplicação

A modelagem do Consulta Fácil é baseada nas principais entidades da aplicação:
-	Usuário: Atributos como id, nome, CPF, e-mail, senha, telefone, data de nascimento, sexo e perfil.
-	Paciente: Todos os atributos associados ao usuário com especificação de perfil como Paciente.
-	Médico: Todos os atributos associados ao usuário com especificação de perfil como Médico, além da adição dos atributos especialidade e CRM.
-	Administrador: Atributo de perfil como Administrador para concessão de permissões avançadas para gerenciar dados médicos e consultas.
-	Consulta: Atributos como id, data da consulta, hora da consulta, médico, paciente e tipo.

## Projeto da Interface Web

A interface do Consulta Fácil é projetada para ser simples e acessível, incluindo:

### Wireframes

#### Página Inicial
_Página de Login_

_Página dashboard do Paciente_

_Página dashboard do Médico_

_Página dashboard do Administrador_

_Página de busca/marcação de Consultas_

_Página de gerenciamento da agenda do Médico_

_Página de gerenciamento de Usuários_

### Design Visual
[Descreva o estilo visual da interface, incluindo paleta de cores, tipografia, ícones e outros elementos gráficos.]

### Layout Responsivo

O layout utiliza Bootstrap 5 para adaptação automática em desktops, tablets e smartphones. Componentes como calendários e tabelas se ajustam a diferentes tamanhos de tela.

### Interações do Usuário
[Descreva as interações do usuário na interface, como animações, transições entre páginas e outras interações.]

## Fluxo de Dados

O fluxo de dados do Consulta Fácil ocorre entre o cliente (navegador), a API e o banco de dados:
- Requisição do Cliente: O usuário realiza uma ação (ex.: agendar consulta).
- Processamento no Back-end: A API recebe a solicitação, valida, e consulta ou atualiza o banco.
- Resposta ao Cliente: O back-end envia dados de confirmação ou resposta de erro ao front-end.

## Requisitos Funcionais

| Descrição do Requisito  |Prioridade |
|-------------------------|----|
| Acessar o sistema pelo login | ALTA |
| Permitir a alteração da senha pelos usuários | ALTA |
| Agendamento, alteração e cancelamento de consultas | ALTA | 
| Gerenciamento de agendas pelos médicos e administradores | ALTA | 
| Gerenciamento de usuários pelos administradores | ALTA | 
| Envio de notificações de consultas | MÉDIA |
| Acesso a relatórios para administradores | MÉDIA |

## Requisitos Não Funcionais

| Descrição do Requisito  |Prioridade |
|-------------------------|----|
| Permitir a integração do front-end com o back-end da aplicação | ALTA |
| Interface intuitiva para fácil usabilidade | ALTA |
| Segurança dos dados com criptografia de senhas e tokens JWT | ALTA |
| Responsividade para dispositivos móveis | MÉDIA | 
| Deve processar requisições do usuário em no máximo 3s |  BAIXA |
| O sistema deve comportar ao menos 300 usuários acessando simultaneamente |  BAIXA |

## Considerações de Segurança

- Autenticação: JWT para sessões seguras de usuários.
- Autorização: Diferentes níveis de acesso (pacientes, médicos, administradores).
- Armazenamento Seguro: Criptografia para dados sensíveis e senhas.

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
