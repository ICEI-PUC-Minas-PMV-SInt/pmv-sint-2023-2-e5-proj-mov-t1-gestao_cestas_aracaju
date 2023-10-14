# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Relatório com as evidências dos testes de software realizados no sistema pela equipe, baseado em um plano de testes pré-definido.

## Avaliação

Os testes que correspondem às classes de beneficiários e voluntários apresentaram algumas falhas no decorrer do desenvolvimento. Devido à existência de links entre os dependentes, a lista de necessidades e o registro de cesta, tivemos que anular a busca pelos links no teste e reduzir a carga de dados. Para superar essas falhas, implementamos uma interface para a geração de links no teste, evitando que o mesmo fosse chamado e surgisse um erro no final. As classes de dependentes, registro de cesta e lista de necessidades seguiram um desenvolvimento mais enxuto, sem a necessidade de anular os links.</br>
Em todos os testes, ocorreu a avaliação dos métodos de HTTP Restful, como Get All, Put, Post, Get by Id e Delete. Ao final da implementação do código, os testes registraram o resultado esperado.

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
