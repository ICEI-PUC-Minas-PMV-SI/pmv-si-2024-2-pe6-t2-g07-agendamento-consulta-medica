# Introdução

Com o avanço das tecnologias da informação e comunicação, as soluções digitais têm se mostrado cada vez mais eficazes na otimização de processos e na melhoria do acesso a serviços essenciais. No contexto da saúde pública, a demanda por sistemas que facilitem o agendamento de consultas médicas é crescente, especialmente em Unidades de Pronto Atendimento (UPAs) , onde a procura por atendimentos é intensa e constante. Este trabalho propõe o desenvolvimento de uma solução de um sistema web e mobile voltado para o agendamento de consultas médicas em uma clínica de saúde pública, visando otimizar o processo e garantir maior acessibilidade e eficiência no atendimento.

## Problema

Atualmente, muitas clínicas públicas enfrentam dificuldades na gestão de agendamentos de consultas médicas, o que resulta em longas filas de espera, dificuldades para marcar consultas e, em alguns casos, na perda de atendimentos por falta de organização e transparência nos processos. O sistema de agendamento tradicional, que geralmente envolve telefonemas ou comparecimento presencial, apresenta várias limitações, como a indisponibilidade de horários, a falta de informações em tempo real e a sobrecarga dos profissionais administrativos. Essas dificuldades impactam diretamente a qualidade do atendimento prestado aos pacientes, que frequentemente enfrentam atrasos e complicações para conseguir uma consulta médica.

## Objetivos

### Objetivo geral:
Desenvolver uma solução web e mobile eficiente e acessível para o agendamento de consultas médicas em uma clínica pública, com o intuito de otimizar o processo de marcação, melhorar a gestão de horários e reduzir o tempo de espera dos pacientes.

### Objetivos específicos
1.	Identificar as necessidades dos usuários: Realizar uma análise das necessidades e expectativas dos pacientes e profissionais de saúde em relação ao sistema de agendamento, garantindo que a solução atenda aos requisitos práticos e usuais do público-alvo.

2.	Desenvolver uma interface amigável: Criar uma interface de usuário intuitiva e acessível, que facilite o uso do sistema por pessoas de diferentes idades e níveis de alfabetização digital, promovendo uma experiência positiva e eficiente.

3.	Implementar funcionalidades-chave: Integrar ao sistema funcionalidades essenciais, como a visualização em tempo real de horários disponíveis, a confirmação automática de agendamentos e o envio de lembretes para os pacientes, reduzindo o índice de absenteísmo.

4.	Testar e validar o sistema: Conduzir testes do sistema em um ambiente real, aplicando melhorias baseadas no feedback dos usuários, e assegurar que o sistema funcione de forma eficaz e confiável nas condições de uso previstas.

5.	Garantir a escalabilidade e segurança: Assegurar que a solução seja escalável para atender a diferentes volumes de usuários e que os dados dos pacientes sejam protegidos conforme as normas de segurança e privacidade vigentes.

## Justificativa

A implementação de uma solução web e mobile para o agendamento de consultas médicas em clínicas públicas justifica-se pela necessidade de modernizar e otimizar os processos de atendimento, que muitas vezes são ineficientes e onerosos tanto para os pacientes quanto para os profissionais de saúde. Além disso, a digitalização do processo de agendamento pode contribuir para a redução das filas de espera, facilitar o acesso às consultas e melhorar a gestão dos recursos disponíveis. A iniciativa também se alinha às diretrizes de modernização da administração pública e ao movimento global de incorporação de tecnologias no setor de saúde, buscando proporcionar um serviço mais eficiente, acessível e de qualidade à população.

## Público-Alvo

O público-alvo deste trabalho é composto principalmente por gestores e profissionais de saúde de clínicas públicas, que buscam soluções para melhorar a eficiência e a qualidade dos serviços prestados. Além disso, o sistema beneficiará diretamente os pacientes que utilizam os serviços da clínica, especialmente aqueles que enfrentam dificuldades para agendar consultas pelos meios tradicionais. O trabalho também pode interessar a desenvolvedores e pesquisadores da área de sistemas de informação e saúde pública, que desejam explorar novas abordagens para a digitalização de processos em ambientes de saúde.

# Especificações do Projeto

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir que o usuário cadastre tarefas | ALTA | 
|RF-002| Emitir um relatório de tarefas no mês   | MÉDIA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA | 
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |

Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

# Catálogo de Serviços

Descreva aqui todos os serviços que serão disponibilizados pelo seu projeto, detalhando suas características e funcionalidades.

# Arquitetura da Solução

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

![arq](https://github.com/user-attachments/assets/b9402e05-8445-47c3-9d47-f11696e38a3d)


## Tecnologias Utilizadas

Descreva aqui qual(is) tecnologias você vai usar para resolver o seu problema, ou seja, implementar a sua solução. Liste todas as tecnologias envolvidas, linguagens a serem utilizadas, serviços web, frameworks, bibliotecas, IDEs de desenvolvimento, e ferramentas.

Apresente também uma figura explicando como as tecnologias estão relacionadas ou como uma interação do usuário com o sistema vai ser conduzida, por onde ela passa até retornar uma resposta ao usuário.

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)