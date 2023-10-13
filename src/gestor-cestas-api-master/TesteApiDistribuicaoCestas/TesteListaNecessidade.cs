using gestor_cestas_api.Controllers;
using gestor_cestas_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApiDistribuicaoCestas
{
    internal class TesteListaNecessidade
    {

        [TestFixture]
        public class RegistroCestaTeste
        {
            private AppDbContext _dbContext;
            private ListaNecessidadesController _controller;


            [SetUp]
            public void SetUp()
            {
                //Cria banco em memória para o teste
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

                // Cria uma instância do banco e do controlador para serem testatdos
                _dbContext = new AppDbContext(options);
                _controller = new ListaNecessidadesController(_dbContext);


            }

            [TearDown]
            public void TearDown()
            {
                //Serve para limpar o banco criado em memória após execução
                _dbContext.Database.EnsureDeleted();
                _dbContext.Dispose();
            }

            [Test]
            public async Task GetById_ListaNecessidadeEsperado()
            {//Declara um método assíncrono com retorno Task

                //Arrange
                //Define os dados do teste
                var id = 15;
                int actualIdBeneficiario = 5;


                var listaNecessidadeEsperado = new ListaNecessidade
                {
                    Id = id,
                    IdBeneficiario = 5,
                    ListaNecessidades = "Fogão",

                };
                //Adiciona o objeto ao conteto do banco e salva as alterações
                _dbContext.ListaNecessidades.Add(listaNecessidadeEsperado);
                _dbContext.SaveChanges();




                //Act
                //Testa o método GetById
                var result = await _controller.GetById(id);


                //Assert
                //Verifica se o resultado da ação é um objeto
                //quando o resultado da ação é um HTTP '200 ok'
                Assert.IsInstanceOf<OkObjectResult>(result);
                var okResult = result as OkObjectResult;
                var actualModel = okResult.Value as ListaNecessidade;


                Assert.IsNotNull(actualModel);
                Assert.That(actualModel.Id, Is.EqualTo(listaNecessidadeEsperado.Id));
                Assert.That(actualIdBeneficiario, Is.EqualTo(listaNecessidadeEsperado.IdBeneficiario));


            }
            [Test]
            public async Task GetAll()
            {
                //Arrange
                //Define os dados do teste
                var listaNecessidade = new List<ListaNecessidade>
            {
               new ListaNecessidade {
                   Id = 15,
                    IdBeneficiario = 5,
                    ListaNecessidades = "Fogão",
               },

                   new ListaNecessidade {
                    Id = 16,
                   IdBeneficiario = 7,
                    ListaNecessidades = "Mesa",
               }
            };

                _dbContext.ListaNecessidades.AddRange(listaNecessidade);
                _dbContext.SaveChanges();



                //Act
                var result = await _controller.GetAll();

                //Assert
                Assert.IsAssignableFrom<OkObjectResult>(result);
                var listaResult = ((OkObjectResult)result).Value as List<ListaNecessidade>;

                Assert.That(listaResult, Is.EqualTo(listaNecessidade));

            }

            [Test]
            public async Task Create()
            {
                //Arrange
                //Define os dados do teste
                var listaNecessidade = new ListaNecessidade
                {
                    Id = 15,
                    IdBeneficiario = 5,
                    ListaNecessidades = "Fogão",
                };

                //Act
                //Testa o método Create
                var result = await _controller.Create(listaNecessidade);


                //Assert
                //verifica se o resultado retornado pelo método é uma instância da classe CreatedAtActionResult 
                Assert.IsInstanceOf<CreatedAtActionResult>(result);

                //converte o resultado para que possamos acessar suas propriedades
                var okResult = result as CreatedAtActionResult;

                //compara o objeto criado com o valor da propriedade Value do resultado retornado
                Assert.That(okResult.Value, Is.EqualTo(listaNecessidade));

                //Verifica se o objeto está presente no banco de dados
                var savedObj = await _dbContext.ListaNecessidades.FirstOrDefaultAsync(o => o.Id == listaNecessidade.Id);
                Assert.That(savedObj.IdBeneficiario, Is.EqualTo(listaNecessidade.IdBeneficiario));

            }

            [Test]
            public async Task Update()
            {
                // Arrange
                int id = 10;
                {
                    var listaNecessidade = new ListaNecessidade
                    {
                        Id = id,
                        IdBeneficiario = 5,
                        ListaNecessidades = "Fogão",
                    };

                    _dbContext.ListaNecessidades.Add(listaNecessidade);
                    _dbContext.SaveChanges();

                    var updatedListaNecessidade = new ListaNecessidade
                    {
                        Id = id,
                        IdBeneficiario = 5,
                        ListaNecessidades = "Geladeira",
                    };

                    // Desanexar qualquer instância existente da entidade com a mesma chave primária
                    var existingEntity = _dbContext.ListaNecessidades.Local.FirstOrDefault(e => e.Id == updatedListaNecessidade.Id);

                    if (existingEntity != null)
                    {
                        _dbContext.Entry(existingEntity).State = EntityState.Detached;
                    }

                    // Act
                    var controller = new ListaNecessidadesController(_dbContext);
                    var result = await controller.Update(id, updatedListaNecessidade);

                    // Assert
                    Assert.IsInstanceOf<NoContentResult>(result);

                    // Busca o objeto atualizado no banco de dados
                    // Com chave primária especificada
                    var listaAtualizado = await _dbContext.ListaNecessidades.FindAsync(id);

                    Assert.That(listaAtualizado.IdBeneficiario, Is.EqualTo(updatedListaNecessidade.IdBeneficiario));
                    Assert.That(listaAtualizado.ListaNecessidades, Is.EqualTo(updatedListaNecessidade.ListaNecessidades));
                }
            }


            [Test]
            public async Task Delete()
            {

                //Arrange
                //Define os dados do teste
                int id = 10;

                var listaNecessidade = new ListaNecessidade
                {
                    Id = 15,
                    IdBeneficiario = 5,
                    ListaNecessidades = "Fogão",
                };

                await _dbContext.ListaNecessidades.AddAsync(listaNecessidade);
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
