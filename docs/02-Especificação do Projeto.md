# Especificações do Projeto

A idealização do projeto foi baseada em pesquisas com entrevistas, que foram importantes para a caracterização das personas e, consequentemente, das histórias de usuários. O processo de criação se baseia no usuário, de modo que ele possa usufruir da ferramenta proposta de forma simples e intuitiva.

No desenvolvimento do projeto, a metodologia escolhida foi o Scrum, que se desenvolve por meio de sprints. Dessa forma, há a possibilidade de iteração do projeto e elicitação dos requisitos, tanto funcionais quanto não funcionais.

Para a gestão do projeto, utilizamos o gráfico de Gantt para a gestão do tempo de desenvolvimento e o Trello para a gestão da equipe e suas atividades.<br>

O gerenciamento da documentação e do código-fonte do projeto, ocorrerá atraveś do Git e GitHub.


## Personas
<table>
  <tr>
    <th>Foto</th>
    <th>Nome</th>
    <th>Descrição</th>
    <th>Aplicativos</th>
    <th>Motivações</th>
    <th>Frustrações</th>
    <th>Hobbies</th>
  </tr
        <tr>
    <td><img title="Maria Aparecida" src="https://images.unsplash.com/photo-1626668011687-8a114cf5a34c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80"/></td>
    <td>Maria Aparecida</td>
    <td>
      <ul>
        <li>68 anos</li>
        <li>Aposentada</li>
        <li>Mora em uma casa de taipa em Maruim/SE.</li>
      </ul>
    </td>
    <td>
      <ul>
        <li>Não usa redes sociais</li>
         </ul>
    </td>
    <td>
      <ul>
        <li>Cuidar da família</li>
        <li>Prover a subsistência dos filhos</li>
      </ul>
    </td>
    <td>
      <li>Não terminou o ensino fundamental</li>
      <li>Possui filhos desempregados</li>
    </td>
    <td>
      <li>Ver novelas</li>
      <li>Costurar</li
    </td>
  </tr>
  <tr>
      <td><img title="Gisele" src="https://images.unsplash.com/photo-1602184572201-89c7deeddf3c?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=387&q=80"/></td>
    <td>Gisele Pereira</td>
    <td>
      <ul>
        <li>36 anos</li>
        <li>Advogada</li>
        <li>Mora em Recife/SE.</li>
      </ul>
    </td>
    <td>
      <ul>
        <li>É familiar com todas as rede sociais</li>
      </ul>
    </td>
    <td>
      <ul>
        <li> Finalizar seu mestrado.</li>
        <li> Contribuir em projetos sociais.</li>
      </ul>
    </td>
    <td>
      <li> Dificuldades no processo operacional na entrega de cestas do projeto social em que é voluntária. </li>
     </td>
    <td>
      <li> Ler livros.</li>
      <li>Cozinhar com o filho</li>
    </td>
  </tr>
    <tr>
    <td><img title="Túlio Almeida" src="https://images.unsplash.com/photo-1599256621730-535171e28e50?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=371&q=80" /></td>
      <td>Túlio Almeida</td>
    <td>
      <ul>
        <li>31 anos</li>
        <li>Engenheiro Químico</li>
        <li>Mora em Recife/SE.</li>
      </ul>
    </td>
    <td>
      <ul>
        <li>Familiar com todas as redes sociais.</li
        </ul>
    </td>
    <td>
      <ul>
        <li> Contribuir no gerenciamento de coleta e entrega de cestas básicas à comunidades carentes.</li>
      </ul>
    </td>
    <td>
      <li> Dificuldades em identificar a população carente atendinda devido a limitação da identificação apenas por Rg ou cpf(pois muitas não apresentam ou não tem documento).</li>
         </td>
    <td>
      <li> Política</li>
      <li> Música</li>
    </td>
  </tr>
  <tr>
     <td><img title="Manoel Martins" src="https://images.unsplash.com/photo-1545167622-3a6ac756afa4?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=412&q=80"/></td>
    <td>Manoel Martins</td>
    <td>
      <ul>
        <li>31 anos</li>
        <li>Vendedor</li>
        <li>Mora em Recife/SE</li>
      </ul>
    </td>
    <td>
      <ul>
        <li> Usa apenas redes sociais essesnciais como Whatssap, gmail.</li> 
      </ul>
    </td>
    <td>
      <ul>
        <li> Continuar ajudando famílias carentes da região.</li>
      </ul>
    </td>
    <td>
      <li> Atualização mensal dos dados em tabelas (no excel) referente a entrega de cestas.</li>
        </td>
    <td>
      <li> Participar do Grupo Espríta.</li>
    </td>
  </tr>
  <tr>
</table>


## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Diretor do projeto | Gerenciar as entregas do mês           | Permitir o controle das doações               |
|Voluntário/usuário       | Cadastrar as famílias                 | Permitir que os beneficiários aptos sejam inseridos no sistema do programa |
|Voluntário/usuário       | Atualizar cadastro do beneficiado                 | Permitir que os dados cadastrais dos beneficiários sejam atualizados inseridos no sistema do programa |
|Voluntário/usuário       | Registrar entrega da cesta                 | Permitir o registro de entrega da cesta do mês |
|Voluntário/usuário       | Registrar as necessidades essenciais                 | Permitir o registro de listas de necessidades essenciais atreladas a cada família |
|Voluntário/usuário       | Consultar histórico do beneficiado                 | Permitir que o usuário possa identificar possíveis mudanças no fluxo das entregas passadas |
|Voluntário/usuário       | Gerar relatório de entrega das cestas                 | Permitir que um relatório seja gerado com informações sobre a entrega daquele período |



## Modelagem do Processo de Negócio 

### Análise da Situação Atual

Atualmente todo o processo é realizado através da ferramenta Excel. O cadastro de Beneficiários, a solicitação de cestas, e o registro de entrega de cestas ocorrem através de planilha impressa, que depois é atualizada na planilha digital do excel. Os principais desafios relatados estão relacionados a limitação da planilha impressa  que:
* não permite o cadastro de mais de um dependende, 
* dificulta encontrar os dados dos beneficiários e dependentes na hora da entrega da cestas, já que são mais de 100 famílias atendidas.
* dificulta a anotação de outras necessidades das famílias atendidas.

### Descrição Geral da Proposta

A proposta é criar um aplicativo mobile que sane as principais dificuldades do cliente. O aplicativo permitirá o cadastro de beneficiários e sua consulta por nome ou cpf otimizando o tempo de enetrega das cestas. 

Também sera possível realizar o cadastro de quantos dependentes forem necessários, ampliando a possibilidade de entrega das cestas, pois atualmente a cesta é entregue  para a matriarca da família ou o único dependente cadastrado, ocorrendo muitas vezes da cesta não ser entregue caso ambos não estejam para recebe-lá.

Haverá também um campo para adicionar as necessidades extras que as famílias necessiatam, criando um registro organizado com a "necessidade" e "para quem" deve ser providenciada. 


### Processo Atual – Cadastro de Beneficiário, Solicitação e Entrega de Cestas

-Pontos Negativos:

* Cadastro em planilha do excel;
* Registro de entrega de cestas em planilha do excel impressa;
* Gasto honeroso de tempo na procura dos dados dos beneficiados na lista impressa;
* Apenas um dependente cadastrado devido a limtação da lista impressa;
* Dificuldade de registro de necessidades adicionais das famílias beneficiadas devido a limitação da lista impressa.
* Necessidade de atualização mensal das entregas e cadastros na planilha do excel.
                     
![Processo 1](img/processo_bpmn.png)

### Processo Futuro – Cadastro de Beneficiário, Solicitação e Entrega de Cestas

Melhorias propostas: 

-Processo de Cadastro: 
* Cadastro automatizado via aplicativo mobile   
* Cadastro de mais de um dependente. 

-Processo de Entrega: 
* Consulta por nome ou cpf do beneficiário e dependentes no app.
* Registro e histórico de entrega de cestas por beneficiário no app.
* Campo com possibilidade de registro de necessidades a serem providenciadas para o beneficiário no app.

  Houve pouca diminuição da quantidade de processos. O objetivo era otimizar o tempo gasto com a limitação da lista impressa e facilitar os processos de cadastro, pesquisa de beneficiados, entrega e registros de cestas.

  ![Processo 1](img/processo_bpmn_futuro.png)

## Indicadores de Desempenho

![Indicadores de Desempenho](img/indicadores_desempenho.png)


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir login dos usuários | ALTA | 
|RF-002| O sistema deve exigir autenticação para login| ALTA 
|RF-003| Permitir logoff dos usuários   | ALTA |
|RF-004| Permitir cadastro de beneficiários | ALTA | 
|RF-005| Consultar por beneficiários  | ALTA |
|RF-006| Permitir atualização dos dados cadastrados dos beneficiários | ALTA | 
|RF-007| Permitir a exclusão dos dados cadastrados de beneficiários   | ALTA |
|RF-008| Permitir a inserção de itens na lista de necessidades essenciais | ALTA | 
|RF-009| Permitir edição das listas de necessidades  | ALTA|
|RF-010| Registrar a entrega das cestas | ALTA | 
|RF-011| Gerar histórico dos beneficiários   | ALTA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser desenvolvido para dispositivo móvel | ALTA | 
|RNF-002| O sistema deve ser desenvolvido em JavaScript (framework React Native) |  MÉDIA| 
|RNF-003| O sistema deve está disponível online e offline | ALTA | 
|RNF-004| O sistema deve ser de fácil usabilidade |  ALTA |
|RNF-005| O sistema deve conter mensagens de erro | ALTA|



## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| O sistema deverá ser desenlvovido baseado nas necessidades dos usuários        |
|03| O sistema deve atender às leis e a regulamentos aplicáveis, como a LGPD        |


## Diagrama de Casos de Uso


![Diagrama caso de uso](img/Projeto_cestas_aracaju_caso_uso.png)

Caso de Uso: Login do usuário. <br>
Atores: Usuário.<br>
Pré-condições: O usuário deve ter um cadastro no sistema.<br>
Pós-condições: O usuário deve ter acesso ao sistema.<br>
Estende: Senha incorreta / Alterar senha.

Caso de Uso: Cadastrar Beneficiário.<br>
Atores: Usuário.<br>
Pré-condições: O usuário deve ter um cadastro no sistema.<br>
Pós-condições: O beneficiário deve ser cadastrado no sistema.<br>
Inclui: Validar dados do beneficiário / Salvar dados do beneficiário.<br>
Estende: Erro ao cadastrar

Caso de Uso: Salvar Dados do Beneficiário.<br>
Atores: Sistema.<br>
Pré-condições: Os dados do beneficiário devem ser validados.<br>
Pós-condições: Os dados do beneficiário devem ser salvos no sistema.<br>
Estende: registrar lista de necessidades.

Caso de Uso: Pesquisar Beneficiários.<br>
Atores: Usuário.<br>
Pré-condições: O usuário deve ter um cadastro no sistema.<br>
Pós-condições: O usuário deve ter encontrado o beneficiário que está 
procurando.

Caso de Uso: Alterar cadastro do Beneficiário.<br>
Atores: Usuário.<br>
Pré-condições: O usuário deve ter um cadastro no sistema.<br>
Pós-condições: O usuário deve ter atualizado os dados beneficiário que está 
procurando.<br>
Estende: Atualizar dados do beneficiário.

Caso de Uso: Remover Beneficiários.<br>
Atores: Usuário.<br>
Pré-condiçoes: O usuário deve ter um cadastro no sistema.<br>
Pós-condiçoes: O beneficiário deve ser removido do sistema.<br>
Inclui: Excluir os dados do beneficiário.

Caso de Uso: Registrar entrega de cestas.<br>
Atores: Usuário.<br>
Pré-condições: O usuário deve ter um cadastro no sistema.<br>
Pós-condição: O registro deve está presente no histórico do beneficiário.<br>
Inclui: Gerar relatório das entregas.
___


# Matriz de Rastreabilidade

![Matriz de Rastreabilidade](img/matriz_rastreabilidade01.png)


# Gerenciamento de Projeto

De acordo com o PMBoK v6 as dez áreas que constituem os pilares para gerenciar projetos, e que caracterizam a multidisciplinaridade envolvida, são: Integração, Escopo, Cronograma (Tempo), Custos, Qualidade, Recursos, Comunicações, Riscos, Aquisições, Partes Interessadas. Para desenvolver projetos um profissional deve se preocupar em gerenciar todas essas dez áreas. Elas se complementam e se relacionam, de tal forma que não se deve apenas examinar uma área de forma estanque. É preciso considerar, por exemplo, que as áreas de Escopo, Cronograma e Custos estão muito relacionadas. Assim, se eu amplio o escopo de um projeto eu posso afetar seu cronograma e seus custos.


## Gerenciamento de Tempo

Diagrama de rede representando o sequenciamento de atividades a serem realizadas.

![Diagrama de rede](img/diagrama_rede.png)

O gráfico de Gantt listando as tarefas e o tempo necessário para de execução das atividades do Projeto Cestas Aracaju.

![Gráfico de Gantt](img/grafico_gantt.png)

## Gerenciamento de Equipe

O gerenciamento adequado de tarefas contribuirá para que o projeto alcance altos níveis de produtividade. Por isso, é fundamental que ocorra a gestão de tarefas e de pessoas, de modo que os times envolvidos no projeto possam ser facilmente gerenciados.

A equipe utiliza metodologias ágeis, tendo escolhido o Scrum como base para definição do processo de desenvolvimento.

A equipe está organizada da seguinte maneira:

Scrum Master: Elaine Souza Melo;<br>
Product Owner: Amanda Paloma Lourenço;<br>
Equipe de Desenvolvimento: Amanda Paloma Lourenço e Elaine Souza Melo;

O quadro Kanban é uma ferramenta visual que relaciona as atividades de um projeto por etapas, descrevendo o que deverá ser contemplado em cada entrega e quais os participantes de cada atividade. Ele também mostra quais etapas estão sendo desenvolvidas, quais estão para começar o desenvolvimento e quais foram concluídas.

![Simple Project Timeline](img/equipe.png)

## Gestão de Orçamento

O custo se baseou na dedicação de horas necessárias ao desenvolvimento da aplicação, não sendo necessário recursos de hardware, software e rede.

![Orçamento](img/gerenciamento_custo01.png)
