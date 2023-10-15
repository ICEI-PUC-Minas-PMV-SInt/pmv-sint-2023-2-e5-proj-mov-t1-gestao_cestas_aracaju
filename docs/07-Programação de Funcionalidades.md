# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>


O projeto do Sistema para gerenciamento de entrega de cestas está implementado com as funcionalidades específicas de CRUD para inserção, pesquisa, atualização e remoção de dados no banco.

A API Restful funciona por meio de requisição e respostas HTTP, transportando os dados entre a camada do servidor de banco e a interface do usuário.

Os artefatos gerados caracterizam-se pelas classes de entidades principais, como as de Voluntários e Beneficiários, e classes dependentes, como as de Dependentes, Registro de Cesta e Lista de Necessidades. Essas classes estão conectadas com a entidade do Beneficiário por meio de links gerados, o que facilita a pesquisa e edição de dados específicos de cada cadastro.

**RF-004 Permitir Cadastro de beneficiários**

Método Post para inserção de cadastro de beneficiários no banco de dados.
```
[HttpPost]
        public async Task<ActionResult> Create(Beneficiario model)
        {
            _context.Beneficiarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
```

*Estrutura dos dados*

```
  "id": 0,
  "nome": "string",
  "apelido": "string",
  "rg": "string",
  "cpf": "string",
  "telefone": "string",
  "logradouro": "string",
  "bairro": "string",
  "numero": "string",
  "cidade": "string",
  "foto": "string"
```

<hr>

**RF005 - Consultar por Beneficiário**

Método GetById para pesquisa e consulta de cadastro de beneficiários no banco de dados.
```
  [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Beneficiarios
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            GerarLinks(model);
            return Ok(model);
        }
```
<hr>

**RF006- Permitir atualização dos daos cadstrados dos beneficiários**

Método Put para atualização de cadastro de beneficiários no banco de dados.
```
[HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Beneficiario model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Beneficiarios.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Beneficiarios.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
```
<hr>

**RF-007- Permitir exclusão dos dados cadastrados de beneficiários**

Método Delete para remocção de cadastro específico no banco de dados.
```
[HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Beneficiarios.FindAsync(id);

            if (model == null) NotFound();

            if (model != null)
            {
                _context.Beneficiarios.Remove(model);
                await _context.SaveChangesAsync();
            }


            return NoContent();

        }
```
<hr>

**RF008- Permitir inserção de itens na lista de necessidades essenciais**

Método Post para inserção de lista de necessidades no banco de dados.
```
[HttpPost]
        public async Task<ActionResult> Create(ListaNecessidade model)
        {
            _context.ListaNecessidades.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
```
*Estrutura dos dados:*
```
  "id": 0,
  "idBeneficiario": 0,
  "listaNecessidades": "string"
```

<hr>

**RF009- Permitir edição das listas de necessidades**

Método Put para atualização da lista de necessidades no banco de dados.
```
[HttpPut("{id}")]

        public async Task<ActionResult> Update(int id, ListaNecessidade model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.ListaNecessidades.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.ListaNecessidades.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
```
<hr>

**RF010- Registrar a entrega das cestas**

Método Post para inserção de registro no banco de dados.
```
[HttpPost]
        public async Task<ActionResult> Create(RegistroCesta model)
        {
            _context.RegistroCestas.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
```
*Estrutura dos dados:*

```
  "id": 0,
  "idBeneficiario": 0,
  "idVoluntario": 0,
  "quantidadeCesta": 0,
  "dataEntrega": "2023-10-15T20:48:12.346Z"
```



> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
