using gestor_cestas_api.Controllers;
using gestor_cestas_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using static gestor_cestas_api.Models.ILinkGenerator;


namespace TesteApiDistribuicaoCestas

{
    public class TesteBeneficiario
    {
        [TestFixture]
        public class BeneficiarioTeste
        {
            private AppDbContext _dbContext;
            private BeneficiariosController _controller;
            private readonly ILinkGenerator _linkGenerator;

            [SetUp]
            public void SetUp()
            {
                //Cria banco em memória para o teste
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

                // Cria uma instância do banco e do controlador para serem testatdos
                _dbContext = new AppDbContext(options);
                _controller = new BeneficiariosController(_dbContext, _linkGenerator);


            }

            [TearDown]
            public void TearDown()
            {
                //Serve para limpar o banco criado em memória após execução
                _dbContext.Database.EnsureDeleted();
                _dbContext.Dispose();
            }

            [Test]
            public async Task GetById_BeneficiarioEsperado()
            {//Declara um método assíncrono com retorno Task

                //Arrange
                //Define os dados do teste
                var id = 15;
                string actualNome = "Pietra Ester Ferreira";
                string actualCpf = "32989238697";

                var beneficiarioEsperado = new Beneficiario
                {
                    Id = id,
                    Nome = "Pietra Ester Ferreira",
                    Apelido = "Pietra",
                    RG = "123456",
                    CPF = "32989238697",
                    Telefone = "33997690408",
                    Logradouro = "Rua Carneirinho Antonio Soares 157",
                    Bairro = "Água Quente",
                    Numero = "838",
                    Cidade = "Nossa senhora Socorro",
                };
                //Adiciona o objeto ao conteto do banco e salva as alterações
                _dbContext.Beneficiarios.Add(beneficiarioEsperado);
                _dbContext.SaveChanges();

                var nullLinkGenerator = new NullLinkGenerator();
                var controller = new BeneficiariosController(_dbContext, nullLinkGenerator);


                //Act
                //Testa o método GetById
                var result = await _controller.GetById(id);


                //Assert
                //Verifica se o resultado da ação é um objeto
                //quando o resultado da ação é um HTTP '200 ok'
                Assert.IsInstanceOf<OkObjectResult>(result);
                var okResult = result as OkObjectResult;
                var actualModel = okResult.Value as Beneficiario;


                Assert.IsNotNull(actualModel);
                Assert.That(actualModel.Id, Is.EqualTo(beneficiarioEsperado.Id));
                Assert.That(actualNome, Is.EqualTo(beneficiarioEsperado.Nome));
                Assert.That(actualCpf, Is.EqualTo(beneficiarioEsperado.CPF));

            }
            [Test]
            public async Task GetAll()
            {
                //Arrange
                //Define os dados do teste
                var listaBeneficiario = new List<Beneficiario>
            {
               new Beneficiario {
                   Id = 15,
                    Nome = "Pietra Ester Ferreira",
                    Apelido = "Pietra",
                    RG = "123456",
                    CPF = "32989238697",
                    Telefone = "33997690408",
                    Logradouro = "Rua Carneirinho Antonio Soares 157",
                    Bairro = "Água Quente",
                    Numero = "838",
                    Cidade = "Nossa senhora Socorro",
               },
                new Beneficiario {
                    Id = 16,
                    Nome = "Camila Gabriela Luciana Baptista",
                    Apelido = "Mila" ,
                    RG = "7894521045",
                    CPF = "456789654",
                    Telefone = "33997456789",
                    Logradouro = "Rua Carneirinho Antonio Soares 157",
                    Bairro = "Água Quente",
                    Numero = "838",
                    Cidade = "Nossa senhora Socorro",
               },
            };

                _dbContext.Beneficiarios.AddRange(listaBeneficiario);
                _dbContext.SaveChanges();



                //Act
                var result = await _controller.GetAll();

                //Assert
                Assert.IsAssignableFrom<OkObjectResult>(result);
                var benefResult = ((OkObjectResult)result).Value as List<Beneficiario>;

                Assert.That(benefResult, Is.EqualTo(listaBeneficiario));

            }

            [Test]
            public async Task Create()
            {
                //Arrange
                //Define os dados do teste
                var beneficiario = new Beneficiario
                {
                    Nome = "Pietra Ester Ferreira",
                    Apelido = "Pietra",
                    RG = "123456",
                    CPF = "32989238697",
                    Telefone = "33997690408",
                    Logradouro = "Rua Carneirinho Antonio Soares 157",
                    Bairro = "Água Quente",
                    Numero = "838",
                    Cidade = "Nossa senhora Socorro",
                };

                //Act
                //Testa o método Create
                var result = await _controller.Create(beneficiario);


                //Assert
                //verifica se o resultado retornado pelo método é uma instância da classe CreatedAtActionResult 
                Assert.IsInstanceOf<CreatedAtActionResult>(result);

                //converte o resultado para que possamos acessar suas propriedades
                var okResult = result as CreatedAtActionResult;

                //compara o objeto criado com o valor da propriedade Value do resultado retornado
                Assert.That(okResult.Value, Is.EqualTo(beneficiario));

                //Verifica se o objeto está presente no banco de dados
                var savedObj = await _dbContext.Beneficiarios.FirstOrDefaultAsync(o => o.Id == beneficiario.Id);
                Assert.That(savedObj.Nome, Is.EqualTo(beneficiario.Nome));

            }

            [Test]
            public async Task Update()
            {
                //Arrange
                //Define os dados do teste
                int id = 15;

                var beneficiario = new Beneficiario
                {
                    Id = id,
                    Nome = "Pietra Ester Ferreira",
                    Apelido = "Pietra",
                    RG = "123456",
                    CPF = "32989238697",
                    Telefone = "33997690408",
                    Logradouro = "Rua Carneirinho Antonio Soares 157",
                    Bairro = "Água Quente",
                    Numero = "838",
                    Cidade = "Nossa senhora Socorro",
                };



                await _dbContext.Beneficiarios.AddAsync(beneficiario);
                await _dbContext.SaveChangesAsync();


                //Obtém a entidade updatedBeneficiario do banco de dados
                //Usando o método AsNoTracking()
                var updatedBeneficiario = await _dbContext.Beneficiarios.FindAsync(id);

                updatedBeneficiario.Nome = "Pietra Ester Andrade";
                updatedBeneficiario.CPF = "32989238697";

                // Desanexar qualquer instância existente da entidade com a mesma chave primária
                var existingEntity = _dbContext.ListaNecessidades.Local.FirstOrDefault(e => e.Id == updatedBeneficiario.Id);

                if (existingEntity != null)
                {
                    _dbContext.Entry(existingEntity).State = EntityState.Detached;
                };


                //Act
                var result = await _controller.Update(id, updatedBeneficiario);

                //Assert
                //Ação concluída com êxito, mas não há conteúdo para retornar
                Assert.IsInstanceOf<NoContentResult>(result);

                //Busca o objeto atualizado no banco de dados
                //Com chave primária especificada
                var beneficiarioAtualizado = await _dbContext.Beneficiarios.FindAsync(id);

                Assert.That(beneficiarioAtualizado.Nome, Is.EqualTo(updatedBeneficiario.Nome));
                Assert.That(beneficiarioAtualizado.CPF, Is.EqualTo(updatedBeneficiario.CPF));

            }

            [Test]
            public async Task Delete()
            {

                //Arrange
                //Define os dados do teste
                int id = 10;

                var beneficiario = new Beneficiario
                {
                    Id = id,
                    Nome = "Pietra Ester Ferreira",
                    Apelido = "Pietra",
                    RG = "123456",
                    CPF = "32989238697",
                    Telefone = "33997690408",
                    Logradouro = "Rua Carneirinho Antonio Soares 157",
                    Bairro = "Água Quente",
                    Numero = "838",
                    Cidade = "Nossa senhora Socorro",
                };

                await _dbContext.Beneficiarios.AddAsync(beneficiario);
                await _dbContext.SaveChangesAsync();

                //Act
                var result = await _controller.Delete(id);

                //Arrange
                //Ação concluída com êxito, mas não há conteúdo para retornar
                Assert.IsInstanceOf<NoContentResult>(result);

            }

        }
    }
}