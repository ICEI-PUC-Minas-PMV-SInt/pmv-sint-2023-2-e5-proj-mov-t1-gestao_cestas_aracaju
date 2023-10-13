using gestor_cestas_api.Controllers;
using gestor_cestas_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static gestor_cestas_api.Models.ILinkGenerator;

namespace TesteApiDistribuicaoCestas
{
    internal class TesteVoluntario
    {


        [TestFixture]
        public class VoluntarioTeste
        {
            private AppDbContext _dbContext;
            private VoluntarioController _controller;
            private readonly ILinkGenerator _linkGenerator;

            [SetUp]
            public void SetUp()
            {
                //Cria banco em memória para o teste
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

                // Cria uma instância do banco e do controlador para serem testatdos
                _dbContext = new AppDbContext(options);
                _controller = new VoluntarioController(_dbContext, _linkGenerator);


            }

            [TearDown]
            public void TearDown()
            {
                //Serve para limpar o banco criado em memória após execução
                _dbContext.Database.EnsureDeleted();
                _dbContext.Dispose();
            }

            [Test]
            public async Task GetById_VoluntarioEsperado()
            {//Declara um método assíncrono com retorno Task

                //Arrange
                //Define os dados do teste
                var id = 15;
                string actualNome = "João Paulo Araujo";
                string actualCpf = "32989238697";

                var voluntarioEsperado = new Voluntario
                {
                    Id = id,
                    Nome = "João Paulo Araujo",
                    CPF = "32989238697",
                    Email = "joao@hotmail.com",
                    Password = "123456",
                    Logradouro = "Rua Rio de Janeiro",
                    Bairro = "Luzia",
                    Numero = "45",
                    Cidade = "Aracaju",
                };
                //Adiciona o objeto ao conteto do banco e salva as alterações
                _dbContext.Voluntarios.Add(voluntarioEsperado);
                _dbContext.SaveChanges();

                var nullLinkGenerator = new NullLinkGenerator();
                var controller = new VoluntarioController(_dbContext, nullLinkGenerator);


                //Act
                //Testa o método GetById
                var result = await _controller.GetById(id);


                //Assert
                //Verifica se o resultado da ação é um objeto
                //quando o resultado da ação é um HTTP '200 ok'
                Assert.IsInstanceOf<OkObjectResult>(result);
                var okResult = result as OkObjectResult;
                var actualModel = okResult.Value as Voluntario;


                Assert.IsNotNull(actualModel);
                Assert.That(actualModel.Id, Is.EqualTo(voluntarioEsperado.Id));
                Assert.That(actualNome, Is.EqualTo(voluntarioEsperado.Nome));
                Assert.That(actualCpf, Is.EqualTo(voluntarioEsperado.CPF));

            }
            [Test]
            public async Task GetAll()
            {
                //Arrange
                //Define os dados do teste
                var listaVoluntario = new List<Voluntario>
            {
               new Voluntario {
                   Id = 15,
                    Nome = "João Paulo Araujo",
                    CPF = "32989238697",
                    Email = "joao@hotmail.com",
                    Password = "123456",
                    Logradouro = "Rua Rio de Janeiro",
                    Bairro = "Luzia",
                    Numero = "45",
                    Cidade = "Aracaju",
               },
                new Voluntario {
                    Id = 16,
                    Nome = "João Paulo Araujo",
                    CPF = "32989238697",
                    Email = "joao@hotmail.com",
                    Password = "123456",
                    Logradouro = "Rua Rio de Janeiro",
                    Bairro = "Luzia",
                    Numero = "45",
                    Cidade = "Aracaju",
               },
            };

                _dbContext.Voluntarios.AddRange(listaVoluntario);
                _dbContext.SaveChanges();



                //Act
                var result = await _controller.GetAll();

                //Assert
                Assert.IsAssignableFrom<OkObjectResult>(result);
                var voluntarioResult = ((OkObjectResult)result).Value as List<Voluntario>;

                Assert.That(voluntarioResult, Is.EqualTo(listaVoluntario));

            }

            [Test]
            public async Task Create()
            {
                //Arrange
                //Define os dados do teste
                var voluntario = new Voluntario
                {
                    Nome = "João Paulo Araujo",
                    CPF = "32989238697",
                    Email = "joao@hotmail.com",
                    Password = "123456",
                    Logradouro = "Rua Rio de Janeiro",
                    Bairro = "Luzia",
                    Numero = "45",
                    Cidade = "Aracaju",
                };

                //Act
                //Testa o método Create
                var result = await _controller.Create(voluntario);


                //Assert
                //verifica se o resultado retornado pelo método é uma instância da classe CreatedAtActionResult 
                Assert.IsInstanceOf<CreatedAtActionResult>(result);

                //converte o resultado para que possamos acessar suas propriedades
                var okResult = result as CreatedAtActionResult;

                //compara o objeto criado com o valor da propriedade Value do resultado retornado
                Assert.That(okResult.Value, Is.EqualTo(voluntario));

                //Verifica se o objeto está presente no banco de dados
                var savedObj = await _dbContext.Voluntarios.FirstOrDefaultAsync(o => o.Id == voluntario.Id);
                Assert.That(savedObj.Nome, Is.EqualTo(voluntario.Nome));

            }

            [Test]
            public async Task Update()
            {
                //Arrange
                //Define os dados do teste
                int id = 1;

                var voluntario = new Voluntario
                {
                    Id = id,
                    Nome = "João Paulo Araujo",
                    CPF = "32989238697",
                    Email = "joao@hotmail.com",
                    Password = "123456",
                    Logradouro = "Rua Rio de Janeiro",
                    Bairro = "Luzia",
                    Numero = "45",
                    Cidade = "Aracaju",
                };


                await _dbContext.Voluntarios.AddAsync(voluntario);
                await _dbContext.SaveChangesAsync();


                //Obtém a entidade updatedBeneficiario do banco de dados
                //Usando o método AsNoTracking()
                var updatedVoluntario = await _dbContext.Voluntarios.FindAsync(id);

                updatedVoluntario.Nome = "Pietra Ester";
                updatedVoluntario.CPF = "32989238697";

                // Desanexar qualquer instância existente da entidade com a mesma chave primária
                var existingEntity = _dbContext.Voluntarios.Local.FirstOrDefault(e => e.Id == updatedVoluntario.Id);

                if (existingEntity != null)
                {
                    _dbContext.Entry(existingEntity).State = EntityState.Detached;
                };


                //Act
                var result = await _controller.Update(id, updatedVoluntario);

                //Assert
                //Ação concluída com êxito, mas não há conteúdo para retornar
                Assert.IsInstanceOf<NoContentResult>(result);

                //Busca o objeto atualizado no banco de dados
                //Com chave primária especificada
                var voluntarioAtualizado = await _dbContext.Voluntarios.FindAsync(id);

                Assert.That(voluntarioAtualizado.Nome, Is.EqualTo(updatedVoluntario.Nome));
                Assert.That(voluntarioAtualizado.CPF, Is.EqualTo(updatedVoluntario.CPF));

            }

            [Test]
            public async Task Delete()
            {

                //Arrange
                //Define os dados do teste
                int id = 10;

                var voluntario = new Voluntario
                {
                    Id = id,
                    Nome = "João Paulo Araujo",
                    CPF = "32989238697",
                    Email = "joao@hotmail.com",
                    Password = "123456",
                    Logradouro = "Rua Rio de Janeiro",
                    Bairro = "Luzia",
                    Numero = "45",
                    Cidade = "Aracaju",
                };

                await _dbContext.Voluntarios.AddAsync(voluntario);
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
