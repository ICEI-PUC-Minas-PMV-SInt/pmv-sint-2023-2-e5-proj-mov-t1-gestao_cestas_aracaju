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
    internal class TesteRegistroCesta
    {

        [TestFixture]
        public class RegistroCestaTeste
        {
            private AppDbContext _dbContext;
            private RegistroCestaController _controller;


            [SetUp]
            public void SetUp()
            {
                //Cria banco em memória para o teste
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

                // Cria uma instância do banco e do controlador para serem testatdos
                _dbContext = new AppDbContext(options);
                _controller = new RegistroCestaController(_dbContext);


            }

            [TearDown]
            public void TearDown()
            {
                //Serve para limpar o banco criado em memória após execução
                _dbContext.Database.EnsureDeleted();
                _dbContext.Dispose();
            }

            [Test]
            public async Task GetById_RegistroCestaEsperado()
            {//Declara um método assíncrono com retorno Task

                //Arrange
                //Define os dados do teste
                var id = 15;
                int actualQuantidade = 1;


                var registroCestaEsperado = new RegistroCesta
                {
                    Id = id,
                    IdBeneficiario = 5,
                    IdVoluntario = 1,
                    QuantidadeCesta = actualQuantidade,
                    DataEntrega = new DateTime(1977, 01, 15),

                };
                //Adiciona o objeto ao conteto do banco e salva as alterações
                _dbContext.RegistroCestas.Add(registroCestaEsperado);
                _dbContext.SaveChanges();




                //Act
                //Testa o método GetById
                var result = await _controller.GetById(id);


                //Assert
                //Verifica se o resultado da ação é um objeto
                //quando o resultado da ação é um HTTP '200 ok'
                Assert.IsInstanceOf<OkObjectResult>(result);
                var okResult = result as OkObjectResult;
                var actualModel = okResult.Value as RegistroCesta;


                Assert.IsNotNull(actualModel);
                Assert.That(actualModel.Id, Is.EqualTo(registroCestaEsperado.Id));
                Assert.That(actualQuantidade, Is.EqualTo(registroCestaEsperado.QuantidadeCesta));


            }
            [Test]
            public async Task GetAll()
            {
                //Arrange
                //Define os dados do teste
                var listaRegistroCesta = new List<RegistroCesta>
            {
               new RegistroCesta {
                   Id = 15,
                    IdBeneficiario = 5,
                    IdVoluntario = 1,
                    QuantidadeCesta = 1,
                    DataEntrega = new DateTime(1977, 01, 15),
               },

                   new RegistroCesta {
                    Id = 16,
                    IdBeneficiario = 5,
                    IdVoluntario = 1,
                    QuantidadeCesta = 2,
                    DataEntrega = new DateTime(),
               }
            };

                _dbContext.RegistroCestas.AddRange(listaRegistroCesta);
                _dbContext.SaveChanges();



                //Act
                var result = await _controller.GetAll();

                //Assert
                Assert.IsAssignableFrom<OkObjectResult>(result);
                var registroResult = ((OkObjectResult)result).Value as List<RegistroCesta>;

                Assert.That(registroResult, Is.EqualTo(listaRegistroCesta));

            }

            [Test]
            public async Task Create()
            {
                //Arrange
                //Define os dados do teste
                var registroCesta = new RegistroCesta
                {
                    Id = 15,
                    IdBeneficiario = 5,
                    IdVoluntario = 1,
                    QuantidadeCesta = 2,
                    DataEntrega = new DateTime(),
                };

                //Act
                //Testa o método Create
                var result = await _controller.Create(registroCesta);


                //Assert
                //verifica se o resultado retornado pelo método é uma instância da classe CreatedAtActionResult 
                Assert.IsInstanceOf<CreatedAtActionResult>(result);

                //converte o resultado para que possamos acessar suas propriedades
                var okResult = result as CreatedAtActionResult;

                //compara o objeto criado com o valor da propriedade Value do resultado retornado
                Assert.That(okResult.Value, Is.EqualTo(registroCesta));

                //Verifica se o objeto está presente no banco de dados
                var savedObj = await _dbContext.RegistroCestas.FirstOrDefaultAsync(o => o.Id == registroCesta.Id);
                Assert.That(savedObj.IdBeneficiario, Is.EqualTo(registroCesta.IdBeneficiario));

            }

            [Test]
            public async Task Update()
            {
                //Arrange
                //Define os dados do teste
                int id = 15;

                var registroCesta = new RegistroCesta
                {
                    Id = id,
                    IdBeneficiario = 5,
                    IdVoluntario = 1,
                    QuantidadeCesta = 2,
                    DataEntrega = new DateTime(),
                };


                await _dbContext.RegistroCestas.AddAsync(registroCesta);
                await _dbContext.SaveChangesAsync();


                //Obtém a entidade updatedBeneficiario do banco de dados
                //Usando o método AsNoTracking()
                var updatedCesta = await _dbContext.RegistroCestas.FindAsync(id);

                updatedCesta.QuantidadeCesta = 2;

                // Desanexar qualquer instância existente da entidade com a mesma chave primária
                var existingEntity = _dbContext.RegistroCestas.Local.FirstOrDefault(e => e.Id == updatedCesta.Id);

                if (existingEntity != null)
                {
                    _dbContext.Entry(existingEntity).State = EntityState.Detached;
                }

                //Act
                var result = await _controller.Update(id, updatedCesta);

                //Assert
                //Ação concluída com êxito, mas não há conteúdo para retornar
                Assert.IsInstanceOf<NoContentResult>(result);

                //Busca o objeto atualizado no banco de dados
                //Com chave primária especificada
                var cestaAtualizada = await _dbContext.RegistroCestas.FindAsync(id);

                Assert.That(cestaAtualizada.QuantidadeCesta, Is.EqualTo(updatedCesta.QuantidadeCesta));


            }

            [Test]
            public async Task Delete()
            {

                //Arrange
                //Define os dados do teste
                int id = 10;

                var registroCesta = new RegistroCesta
                {
                    Id = 15,
                    IdBeneficiario = 5,
                    IdVoluntario = 1,
                    QuantidadeCesta = 2,
                    DataEntrega = new DateTime(),
                };

                await _dbContext.RegistroCestas.AddAsync(registroCesta);
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
