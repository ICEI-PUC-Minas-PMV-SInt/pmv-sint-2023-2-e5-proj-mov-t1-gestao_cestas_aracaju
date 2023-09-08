# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

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

Apresente aqui os problemas existentes que viabilizam sua proposta. Apresente o modelo do sistema como ele funciona hoje. Caso sua proposta seja inovadora e não existam processos claramente definidos, apresente como as tarefas que o seu sistema pretende implementar são executadas atualmente, mesmo que não se utilize tecnologia computacional. 

### Descrição Geral da Proposta

Apresente aqui uma descrição da sua proposta abordando seus limites e suas ligações com as estratégias e objetivos do negócio. Apresente aqui as oportunidades de melhorias.

### Processo 1 – NOME DO PROCESSO

Apresente aqui o nome e as oportunidades de melhorias para o processo 1. Em seguida, apresente o modelo do processo 1, descrito no padrão BPMN. 

![Processo 1](img/02-bpmn-proc1.png)

### Processo 2 – NOME DO PROCESSO

Apresente aqui o nome e as oportunidades de melhorias para o processo 2. Em seguida, apresente o modelo do processo 2, descrito no padrão BPMN.

![Processo 2](img/02-bpmn-proc2.png)

## Indicadores de Desempenho

Apresente aqui os principais indicadores de desempenho e algumas metas para o processo. Atenção: as informações necessárias para gerar os indicadores devem estar contempladas no diagrama de classe. Colocar no mínimo 5 indicadores. 

Usar o seguinte modelo: 

![Indicadores de Desempenho](img/02-indic-desemp.png)
Obs.: todas as informações para gerar os indicadores devem estar no diagrama de classe a ser apresentado a posteriori. 

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
|02| O sistema deve atender às necessidades e expectativas dos usuários        |
|03| O sistema deve atender às leis e a regulamentos aplicáveis, como a LGPD        |


## Diagrama de Casos de Uso

![Diagrama caso de uso](img/diagrama_caso_uso.png)


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

![Simple Project Timeline](img/02-project-timeline.png)

## Gestão de Orçamento

O custo se baseou na dedicação de horas necessárias ao desenvolvimento da aplicação, não sendo necessário recursos de hardware, software e rede.

![Orçamento](img/gerenciamento_custo01.png)
