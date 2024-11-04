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
![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/main/docs/img/pagina%20login.png?raw=true)

_Página dashboard do Paciente_
![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/main/docs/img/pagina%20paciente.png?raw=true)

_Página dashboard do Médico_
![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/main/docs/img/pagina%20medico.png?raw=true)

_Página dashboard do Administrador_
![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/main/docs/img/pagina%20admin.png?raw=true)

_Página de busca/marcação de Consultas_
![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/main/docs/img/pagina%20consultas.png?raw=true)

_Página de gerenciamento da agenda do Médico_
![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/main/docs/img/pagina%20agenda%20medico.png?raw=true)

_Página de gerenciamento de Usuários_
![arq](https://github.com/ICEI-PUC-Minas-PMV-SI/pmv-si-2024-2-pe6-t2-g07-agendamento-consulta-medica/blob/main/docs/img/pagina%20gerenciar%20usuarios.png?raw=true)

### Design Visual

Estilo leve, com cores predominantes em tons de verde para transmitir tranquilidade e profissionalismo. Ícones e botões seguem a paleta para facilitar a identificação das funções.

### Layout Responsivo

O layout utiliza Bootstrap 5 para adaptação automática em desktops, tablets e smartphones. Componentes como calendários e tabelas se ajustam a diferentes tamanhos de tela.

### Interações do Usuário

Animações de transição entre páginas, e uso de modais para confirmação e alerta. Transições suaves melhoram a experiência ao gerenciar consultas.

## Fluxo de Dados

O fluxo de dados do Consulta Fácil ocorre entre o cliente (navegador), a API e o banco de dados:
- Requisição do Cliente: O usuário realiza uma ação (ex.: agendar consulta).
- Processamento no Back-end: A API recebe a solicitação, valida, e consulta ou atualiza o banco.
- Resposta ao Cliente: O back-end envia dados de confirmação ou resposta de erro ao front-end.

## Requisitos Funcionais

| Id | Descrição do Requisito  |Prioridade |
|----|-------------------------|----|
| RF01 | Acessar o sistema pelo login | ALTA |
| RF02 | Permitir a alteração da senha pelos usuários | ALTA |
| RF03 | Agendamento, alteração e cancelamento de consultas | ALTA | 
| RF04 | Gerenciamento de agendas pelos médicos e administradores | ALTA | 
| RF05 | Gerenciamento de usuários pelos administradores | ALTA | 
| RF06 | Envio de notificações de consultas | MÉDIA |
| RF07 | Acesso a relatórios para administradores | MÉDIA |

## Requisitos Não Funcionais

| Id | Descrição do Requisito  |Prioridade |
|----|-------------------------|----|
| RNF01 | Permitir a integração do front-end com o back-end da aplicação | ALTA |
| RNF02 | Interface intuitiva para fácil usabilidade | ALTA |
| RNF03 | Segurança dos dados com criptografia de senhas e tokens JWT | ALTA |
| RNF04 | Responsividade para dispositivos móveis | MÉDIA | 
| RNF05 | Deve processar requisições do usuário em no máximo 3s |  BAIXA |
| RNF06 | O sistema deve comportar ao menos 300 usuários acessando simultaneamente |  BAIXA |

## Considerações de Segurança

- Autenticação: JWT para sessões seguras de usuários.
- Autorização: Diferentes níveis de acesso (pacientes, médicos, administradores).
- Armazenamento Seguro: Criptografia para dados sensíveis e senhas.

## Implantação

Nesta etapa, o ambiente de produção foi configurado e implementado com os seguintes componentes e processos:

1.Requisitos de _hardware_ e _software_:

Requisitos de hardware:
- Servidor com pelo menos 2 CPU Cores, 4 GB de RAM e 20 GB de armazenamento para um ambiente de produção básico.
  
Requisitos de software:
- ASP.NET Core Runtime para execução da API em C#.
- Node.js para rodar scripts do front-end e gerenciar dependências.
- PostgreSQL como sistema de gerenciamento de banco de dados.

2.Plataforma de hospedagem:

- Foi escolhida a plataforma de nuvem Microsoft Azure, pela facilidade de integração com o PostgreSQL e pela escalabilidade, além de suporte nativo para aplicações ASP.NET Core e instâncias de banco de dados gerenciadas.

3.Configuração do ambiente de produção:

- No Azure App Service, foram configuradas as variáveis de ambiente, como strings de conexão ao banco de dados e chaves de API.
- Dependências do projeto foram instaladas utilizando o gerenciador de pacotes do Node.js para o front-end e o gerenciador de pacotes do .NET para a API.
- Configurações de segurança e autenticação foram aplicadas para proteger dados sensíveis.

4.Hospedagem e Deploy da aplicação Web:

- A API foi hospedada no Azure App Service, com configuração de integração contínua (CI/CD) a partir de um repositório Git, facilitando atualizações e manutenção.
- A comunicação entre o front-end e a API hospedada no Azure foi configurada com segurança, utilizando autenticação e protocolos de acesso autorizados.

5.Testes e verificação de funcionamento:

- Testes manuais foram conduzidos no ambiente de produção para validar o funcionamento das principais funcionalidades.
- A API foi testada com o Postman para verificar a operação correta dos endpoints e da comunicação com o banco de dados PostgreSQL no ambiente Azure.

## Testes

Os testes da aplicação Consulta Fácil foram realizados de forma manual para garantir que os requisitos funcionais e não funcionais fossem atendidos. A API foi testada utilizando o Postman, o que permitiu validar as rotas e funcionalidades essenciais, como cadastro de usuários, agendamento e cancelamento de consultas, garantindo a comunicação correta entre a aplicação e o banco de dados.

# Referências

1. Node.js. _Node.js Documentation_. Disponível em: https://nodejs.org/en/docs
2. Express. _Express Documentation_. Disponível em: https://expressjs.com
3. Bootstrap. _Bootstrap 5 Documentation_. Disponível em: https://getbootstrap.com/docs/5.0
4. PostgreSQL Global Development Group. _PostgreSQL Documentation_. Disponível em: https://www.postgresql.org/docs
5. Microsoft. _Azure App Service Documentation_. Disponível em: https://learn.microsoft.com/azure/app-service
6. Microfundamento de API e Web Services.
