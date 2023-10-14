# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

RF-004 Permitir Cadastro de beneficiários

```
[HttpPost]
        public async Task<ActionResult> Create(Beneficiario model)
        {
            _context.Beneficiarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
```
<hr>

RF005 - Consultar por Beneficiário
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

RF006- Permitir atualização dos daos cadstrados dos beneficiários
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

RF-007- Permitir exclusão dos dados cadastrados de beneficiários
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

RF008- Permitir inserção de itens na listaa de necessidades essenciais
```
[HttpPost]
        public async Task<ActionResult> Create(ListaNecessidade model)
        {
            _context.ListaNecessidades.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
```
<hr>

RF009- Permitir edição das listas de necessidades
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

RF010- Registrar a entrega das cestas
```
[HttpPost]
        public async Task<ActionResult> Create(RegistroCesta model)
        {
            _context.RegistroCestas.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
```



> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
