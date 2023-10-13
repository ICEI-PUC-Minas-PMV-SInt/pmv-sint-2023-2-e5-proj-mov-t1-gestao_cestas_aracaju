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
    internal class TesteDependente
    {

        [TestFixture]
        public class DependenteTeste
        {
            private AppDbContext _dbContext;
            private DependentesController _controller;


            [SetUp]
            public void SetUp()
            {
                //Cria banco em memória para o teste
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

                // Cria uma instância do banco e do controlador para serem testatdos
                _dbContext = new AppDbContext(options);
                _controller = new DependentesController(_dbContext);


            }

            [TearDown]
            public void TearDown()
            {
                //Serve para limpar o banco criado em memória após execução
                _dbContext.Database.EnsureDeleted();
                _dbContext.Dispose();
            }

            [Test]
            public async Task GetById_DependenteEsperado()
            {//Declara um método assíncrono com retorno Task

                //Arrange
                //Define os dados do teste
                var id = 15;
                string actualNome = "Pietra Ester Ferreira";
                string actualCpf = "32989238697";

                var dependenteEsperado = new Dependente
                {
                    Id = id,
                    IdBeneficiario = 5,
                    Nome = "Pietra Ester Ferreira",
                    Parentesco = "Filha",
                    CPF = "32989238697",

                };
                //Adiciona o objeto ao conteto do banco e salva as alterações
                _dbContext.Dependentes.Add(dependenteEsperado);
                _dbContext.SaveChanges();




                //Act
                //Testa o método GetById
                var result = await _controller.GetById(id);


                //Assert
                //Verifica se o resultado da ação é um objeto
                //quando o resultado da ação é um HTTP '200 ok'
                Assert.IsInstanceOf<OkObjectResult>(result);
                var okResult = result as OkObjectResult;
                var actualModel = okResult.Value as Dependente;


                Assert.IsNotNull(actualModel);
                Assert.That(actualModel.Id, Is.EqualTo(dependenteEsperado.Id));
                Assert.That(actualNome, Is.EqualTo(dependenteEsperado.Nome));
                Assert.That(actualCpf, Is.EqualTo(dependenteEsperado.CPF));

            }
            [Test]
            public async Task GetAll()
            {
                //Arrange
                //Define os dados do teste
                var listaDependente = new List<Dependente>
            {
               new Dependente {
                   Id = 15,
                    IdBeneficiario = 5,
                    Nome = "Pietra Ester Ferreira",
                    Parentesco = "Filha",
                    CPF = "32989238697",
               },
                new Dependente {
                    Id = 16,
                    IdBeneficiario = 5,
                    Nome = "José Ferreira",
                    Parentesco = "Marido",
                    CPF = "4561389759",
               },
            };

                _dbContext.Dependentes.AddRange(listaDependente);
                _dbContext.SaveChanges();



                //Act
                var result = await _controller.GetAll();

                //Assert
                Assert.IsAssignableFrom<OkObjectResult>(result);
                var dependenteResult = ((OkObjectResult)result).Value as List<Dependente>;

                Assert.That(dependenteResult, Is.EqualTo(listaDependente));

            }

            [Test]
            public async Task Create()
            {
                //Arrange
                //Define os dados do teste
                var dependente = new Dependente
                {
                    Id = 15,
                    IdBeneficiario = 5,
                    Nome = "Pietra Ester Ferreira",
                    Parentesco = "Primo",
                    CPF = "32989238697",
                };

                //Act
                //Testa o método Create
                var result = await _controller.Create(dependente);


                //Assert
                //verifica se o resultado retornado pelo método é uma instância da classe CreatedAtActionResult 
                Assert.IsInstanceOf<CreatedAtActionResult>(result);

                //converte o resultado para que possamos acessar suas propriedades
                var okResult = result as CreatedAtActionResult;

                //compara o objeto criado com o valor da propriedade Value do resultado retornado
                Assert.That(okResult.Value, Is.EqualTo(dependente));

                //Verifica se o objeto está presente no banco de dados
                var savedObj = await _dbContext.Dependentes.FirstOrDefaultAsync(o => o.Id == dependente.Id);
                Assert.That(savedObj.Nome, Is.EqualTo(dependente.Nome));

            }

            [Test]
            public async Task Update()
            {
                //Arrange
                //Define os dados do teste
                int id = 15;

                var dependente = new Dependente
                {
                    Id = id,
                    IdBeneficiario = 5,
                    Nome = "Pietra Ester Ferreira",
                    Parentesco = "Filha",
                    CPF = "32989238697",
                };


                await _dbContext.Dependentes.AddAsync(dependente);
                await _dbContext.SaveChangesAsync();


                //Obtém a entidade updatedBeneficiario do banco de dados
                //Usando o método AsNoTracking()
                var updatedDependente = await _dbContext.Dependentes.FindAsync(id);

                updatedDependente.Nome = "Pietra Ester";
                updatedDependente.CPF = "32989238697";


                // Desanexar qualquer instância existente da entidade com a mesma chave primária
                var existingEntity = _dbContext.ListaNecessidades.Local.FirstOrDefault(e => e.Id == updatedDependente.Id);

                if (existingEntity != null)
                {
                    _dbContext.Entry(existingEntity).State = EntityState.Detached;
                }

                //Act
                var result = await _controller.Update(id, updatedDependente);

                //Assert
                //Ação concluída com êxito, mas não há conteúdo para retornar
                Assert.IsInstanceOf<NoContentResult>(result);

                //Busca o objeto atualizado no banco de dados
                //Com chave primária especificada
                var dependenteAtualizado = await _dbContext.Dependentes.FindAsync(id);

                Assert.That(dependenteAtualizado.Nome, Is.EqualTo(updatedDependente.Nome));
                Assert.That(dependenteAtualizado.CPF, Is.EqualTo(updatedDependente.CPF));

            }

            [Test]
            public async Task Delete()
            {

                //Arrange
                //Define os dados do teste
                int id = 10;

                var dependente = new Dependente
                {
                    Id = 15,
                    IdBeneficiario = 5,
                    Nome = "Pietra Ester Ferreira",
                    Parentesco = "Irmã",
                    CPF = "32989238697",
                };

                await _dbContext.Dependentes.AddAsync(dependente);
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
